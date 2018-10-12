import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { AuthenticationService } from '../services/authentication.service';
import 'rxjs/add/operator/do';
import { HttpResponse } from 'selenium-webdriver/http';
import { Router } from '@angular/router';
import { ServerValidationService } from '../services/server-validation.service';
import { mockBackEndService } from '../mock-backend/mock-back-end-service';

/** Pass untouched request through to the next request handler. */
@Injectable()
export class AppHttpInterceptor implements HttpInterceptor {
    constructor(private router: Router,
        private authenticationService: AuthenticationService,
        private serverValidationService: ServerValidationService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        let authRequest = request;
        const url: string = request.url;
        const method: string = request.method;

        if (this.authenticationService.user && this.authenticationService.user.token) {
            authRequest = request.clone({
                headers: request.headers.set('Authorization', this.authenticationService.user.token)
            });
        }

        return mockBackEndService(url, method, request) ||
            next.handle(authRequest).do(
                (response: any) => {
                    // Do notthing
                },
                (error: any) => {
                    if (error instanceof HttpErrorResponse) {
                        if (error.status === 0) {
                            console.log(error);
                            this.serverValidationService.setServerErrors('Error with status 0 occurred.');
                            return;
                        }

                        if (error.status === 422) {
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
