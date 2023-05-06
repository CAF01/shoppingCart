import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject, takeUntil } from 'rxjs';
import { ArticlesEndpoints } from '../models/constants/article-endpoints';
import { HttpRequestApi } from 'src/app/infrastructure/helpers/http-request';
import { CreateArticleRequest } from '../models/request/create-article.request';
import { ArticleResponse } from '../models/response/article.response';
import { ShoppingCartRequest } from '../models/request/shopping-cart.request';

@Injectable({
  providedIn: 'root'
})
export class ArticleService {

  constructor(private http: HttpClient) { }


  getArticles(idStore: number): Observable<ArticleResponse[]> {
    return this.http
      .get<ArticleResponse[]>(HttpRequestApi.getUrlApi(ArticlesEndpoints.GET_ARTICLES.replace('{0}', idStore.toString())));
  }

  createArticle(article: CreateArticleRequest): Observable<number> {
    return this.http
      .post<number>(HttpRequestApi.getUrlApi(ArticlesEndpoints.CREATE_ARTICLE), article);
  }

  uploadFile(data: File): Observable<string> {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'multipart/form-data');

    const formData = new FormData();
    formData.append('formFile', data);

    return this.http
      .post<string>(HttpRequestApi.getUrlApi(ArticlesEndpoints.UPLOAD_IMAGE), formData, { headers: headers });
  }

  shoppingCart(request: ShoppingCartRequest[]): Observable<number> {
    return this.http
      .post<number>(HttpRequestApi.getUrlApi(ArticlesEndpoints.SHOPPING_CART), request);
  }

}
