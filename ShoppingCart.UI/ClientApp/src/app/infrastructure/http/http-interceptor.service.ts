import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { AuthService } from '../auth/auth.service';
import { catchError, map } from 'rxjs/operators';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';


@Injectable({
    providedIn: 'root'
})
export class HttpInterceptorService implements HttpInterceptor {

    constructor(
        private authService: AuthService,
        private router: Router,
        private spiner: NgxSpinnerService
    ) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        this.spiner.show();

        if (this.authService.credentials) {
            req = req.clone({
                setHeaders: {
                    Authorization: `Bearer ${this.authService.credentials.token}`
                }
            });

        }

        return next.handle(req)
            .pipe(catchError(error => this.errorHandler(error)))
            .pipe(map<HttpEvent<any>, any>((evt: HttpEvent<any>) => {
                if (evt instanceof HttpResponse) {
                    this.spiner.hide();
                }
                return evt;
            }));;

    }

    private errorHandler(response: HttpErrorResponse): Observable<HttpEvent<any>> {
        
        this.spiner.hide();
        let errs: any[] = [];

        switch (response.status) {
            case 400:
                console.log('Error', response.status);
                break;
            case 401:
                this.router.navigateByUrl('/auth', { replaceUrl: true });
                break;
            case 404:
                errs.push(response.message);
                break;
            case 406:
            case 409:
            case 500:
                console.log('Ocorreu um erro inesperado de servidor.');
                break;
        }

       

        return throwError(() => response);
    }

}
