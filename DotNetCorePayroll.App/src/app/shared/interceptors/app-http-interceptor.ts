import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { AuthenticationService } from '../services/authentication.service';
import 'rxjs/add/operator/do';
import { HttpResponse } from 'selenium-webdriver/http';
import { Router } from '@angular/router';
import { ServerValidationService } from '../services/server-validation.service';

/** Pass untouched request through to the next request handler. */
@Injectable()
export class AppHttpInterceptor implements HttpInterceptor {
    constructor(private router: Router, private authenticationService: AuthenticationService, private serverValidationService: ServerValidationService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const authRequest = request.clone({
            headers: request.headers.set('Authorization', this.authenticationService.user.token)
        });

        return next.handle(authRequest).do(
            (response: any) => {
                //Do notthing
            },
            (error: any) => {
                if (error instanceof HttpErrorResponse) {
                    if (error.status === 442) {
                        this.serverValidationService.setErrors(error.error);
                        return;
                    }

                    if (error.status === 401) {
                        this.router.navigate(['/login']);
                        return;
                    }
                }
            }
        );
    }
}
