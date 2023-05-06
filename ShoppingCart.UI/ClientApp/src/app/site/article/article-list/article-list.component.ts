import { Component, OnDestroy, OnInit } from '@angular/core';
import { ArticleResponse } from '../models/response/article.response';
import { MatDialog } from '@angular/material/dialog';
import { CreateArticleComponent } from '../create-article/create-article.component';
import { ArticleService } from '../services/article.service';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';

@Component({
  selector: 'app-article-list',
  templateUrl: './article-list.component.html',
  styleUrls: ['./article-list.component.scss']
})
export class ArticleListComponent implements OnInit, OnDestroy {

  subscription: any;

  displayedColumns: string[] = ['photo', 'code', 'description', 'price', 'stock', 'branch'];

  articles: ArticleResponse[] = [];

  constructor(public dialog: MatDialog,
    private articleService: ArticleService,
    private authService: AuthService) { 
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

  add(): void {
    const dialogRef = this.dialog.open(CreateArticleComponent, {
      disableClose: true
    });

    dialogRef.afterClosed().subscribe({
      next: (response: ArticleResponse) => {
        if (response && response.idStore === this.authService.currentStore.idStore) {
          this.articles = [...this.articles, response];
        }
      }
    });

  }


}
