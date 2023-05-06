import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginRequest } from '../models/request/login-request';
import { LoginResponse } from '../models/response/login-response';
import { HttpRequestApi } from 'src/app/infrastructure/helpers/http-request';
import { AccountEndpoints } from '../models/constants/account-endpoints';
import { CreateUserRequest } from '../models/request/create-user.request';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(private http: HttpClient) {

  }

  login(credentials: LoginRequest ): Observable<LoginResponse> {
    return this.http
      .post<LoginResponse>(HttpRequestApi.getUrlApi(AccountEndpoints.LOGIN), credentials);
  }

  create(user: CreateUserRequest ): Observable<number> {
    return this.http
      .post<number>(HttpRequestApi.getUrlApi(AccountEndpoints.CREATE_USER), user);
  }

}
