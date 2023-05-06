import { HttpClient } from '@angular/common/http';
import { EventEmitter, Injectable } from '@angular/core';
import { CreateStoreRequest } from '../models/request/create-store.request';
import { Observable } from 'rxjs';
import { HttpRequestApi } from 'src/app/infrastructure/helpers/http-request';
import { StoreEndpoints } from '../models/constants/store-endpoints';
import { StoreResponse } from '../models/response/store.response';

@Injectable({
  providedIn: 'root'
})
export class StoreService {

  public onChangeStore: EventEmitter<StoreResponse> = new EventEmitter();

  constructor(private http: HttpClient) { }

  getStores(): Observable<StoreResponse[]> {
    return this.http
      .get<StoreResponse[]>(HttpRequestApi.getUrlApi(StoreEndpoints.GET_STORES));
  }

  createStore(store: CreateStoreRequest): Observable<number> {
    return this.http
      .post<number>(HttpRequestApi.getUrlApi(StoreEndpoints.CREATE_STORE), store);
  }
}
