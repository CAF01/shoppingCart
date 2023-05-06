using Microsoft.EntityFrameworkCore;
using ShoppingCart.Entitys.POCOs;

namespace ShoppingCart.Data.EFC.DataContext
{
    public class ShoppingCartContext : DbContext
    {
        public ShoppingCartContext()
        {
        }

        public ShoppingCartContext(DbContextOptions<ShoppingCartContext> options)
            : base(options) { }

        public virtual DbSet<Article> Articles { get; set; }

        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<RelArticlesInStore> RelArticlesInStores { get; set; }

        public virtual DbSet<RelClientArticle> RelClientArticles { get; set; }

        public virtual DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>(entity =>
            {
                entity.HasKey(e => e.IdArticle);

                entity.HasIndex(e => e.Code, "IX_Articles").IsUnique();

                entity.Property(e => e.Code)
                    .HasMaxLength(30)
                    .IsUnicode(false);
                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .IsUnicode(false);
                entity.Property(e => e.Image)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.IdClient);

                entity.HasIndex(e => e.Email, "IX_Clients").IsUnique();

                entity.Property(e => e.Address)
                    .HasMaxLength(150)
                    .IsUnicode(false);
                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RelArticlesInStore>(entity =>
            {
                entity.HasKey(e => e.IdRelArticlesInStore);

                entity.ToTable("RelArticlesInStore");

                entity.Property(e => e.Date)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdArticleNavigation).WithMany(p => p.RelArticlesInStores)
                    .HasForeignKey(d => d.IdArticle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RelArticlesInStore_Articles");

                entity.HasOne(d => d.IdStoreNavigation).WithMany(p => p.RelArticlesInStores)
                    .HasForeignKey(d => d.IdStore)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RelArticlesInStore_Stores");
            });

            modelBuilder.Entity<RelClientArticle>(entity =>
            {
                entity.HasKey(e => e.IdRelClientArticle);

                entity.ToTable("RelClientArticle");

                entity.Property(e => e.Date)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdArticleNavigation).WithMany(p => p.RelClientArticles)
                    .HasForeignKey(d => d.IdArticle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RelClientArticle_Articles");

                entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.RelClientArticles)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RelClientArticle_Clients");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.IdStore);

                entity.Property(e => e.Address)
                    .HasMaxLength(150)
                    .IsUnicode(false);
                entity.Property(e => e.Branch)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            base.OnModelCreating(modelBuilder);
        }





    }
}
