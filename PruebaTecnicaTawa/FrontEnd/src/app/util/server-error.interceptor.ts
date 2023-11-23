import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

@Injectable()
export class ServerErrorInterceptor implements HttpInterceptor {

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
      debugger;
        return next.handle(request).pipe(
            retry(1),
            catchError((error: HttpErrorResponse) => {
                if (error.status === 401) {
                    return throwError('Su sesión ha terminado. Por favor vuelva a iniciar sesión..');
                } else {
                    return throwError(error);
                }
            })
        );
    }
}
