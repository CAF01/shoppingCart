import { Component, OnDestroy, OnInit } from '@angular/core';
import { ArticleService } from '../../article/services/article.service';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';
import { ArticleResponse } from '../../article/models/response/article.response';
import { MatDialog } from '@angular/material/dialog';
import { ImgViewComponent } from 'src/app/shared/controls/img-view/img-view.component';
import { Resume } from '../models/resume';
import { PayComponent } from '../pay/pay.component';
import { NotificationService } from 'src/app/infrastructure/services/notification.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit, OnDestroy {
  displayedColumns: string[] = ['Photo', 'Code', 'Description', 'Price', 'Stock', 'Actions'];

  subscription: any;

  articles: ArticleResponse[] = [];

  shoopingCart: ArticleResponse[] = [];

  resume: Resume[] = [];

  constructor(private articleService: ArticleService,
    private authService: AuthService,
    public dialog: MatDialog,
    private alertService: NotificationService) {
    this.getArticles();
  }

  ngOnInit(): void {
    this.subscription = this.authService.onChangeStore
      .subscribe(item => this.getArticles());
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  getArticles(): void {
    this.articleService.getArticles(this.authService.currentStore.idStore)
      .subscribe({ next: (response) => this.articles = response });
  }

  view(article: ArticleResponse): void {
    let dialogRef = this.dialog.open(ImgViewComponent);

    dialogRef.componentInstance.img = article.image;
  }

  operationCard(article: ArticleResponse, item: number): void {

    const currentRow = this.shoopingCart.find((x) => x.idArticle === article.idArticle);

    if (item === -1 && currentRow) {
      const index = this.shoopingCart.indexOf(currentRow);
      this.shoopingCart.splice(index, 1);
      article.stock += 1;
    } else if (item === 1 && article.stock > 0) {
      this.shoopingCart.push(article);
      article.stock -= 1;
    }

  }

  pay(): void {

    this.resume = [];

    const distinctArray = this.shoopingCart.filter((n, i) => this.shoopingCart.indexOf(n) === i);

    for (const article of distinctArray) {
      let current = this.shoopingCart.filter(i => i.idArticle === article.idArticle);

      let count = current.length;

      this.resume.push(new Resume(article.code, count, article.price * count));
    }

    this.resume.push(new Resume('Total', this.resume.length, this.resume.map(x => x.total).reduce((a, b) => a + b, 0)));

    let dialogRef = this.dialog.open(PayComponent);

    dialogRef.componentInstance.resume = this.resume;

    dialogRef.afterClosed().subscribe(response => {
      if (response) {
        this.setShoppingCart();
      }
    });

  }

  setShoppingCart(): void {

    const idClient = this.authService.credentials.idClient;

    this.articleService
      .shoppingCart(this.shoopingCart.map(x => ({ idClient, idArticle: x.idArticle })))
      .subscribe({
        next: (response: number) => {
          if (response && response > 0) {
            this.shoopingCart = [];
            this.resume = [];

            this.alertService.open('Shopping Success', 'Success');
          }
        }
      });
  }


}
