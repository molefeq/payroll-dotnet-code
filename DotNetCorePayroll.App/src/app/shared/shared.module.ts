import { NgModule } from '@angular/core';
import { MaterialModule } from './material/material.module';

import { PanelWidgetComponent } from './components/panel-widget/panel-widget.component';
import { AuthenticationService } from './services/authentication.service';
import { AuthorizationGuardService } from './services/authorization-guard.service';
import { AppHttpInterceptor } from './interceptors/app-http-interceptor';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { FormValidatorDirective } from './directives/form-validator.directive';
import { ServerValidationService } from './services/server-validation.service';
import { AppValidationMessageDirective } from './directives/app-validation-message.directive';
import { ApiModule, BASE_PATH } from './generated';
import { AppHttpServerErrorComponent } from './components/app-http-server-error/app-http-server-error.component';
import { ServerErrorDailogComponent } from './components/app-http-server-error/server-error-dailog/server-error-dailog.component';
import { environment } from '../../environments/environment';
import { SummaryValidationMessagesComponent } from './components/summary-validation-messages/summary-validation-messages.component';

@NgModule({
  imports: [
    MaterialModule,
    HttpClientModule,
    ReactiveFormsModule,
    ApiModule
  ],
  exports: [
    MaterialModule,
    ReactiveFormsModule,
    PanelWidgetComponent,
    FormValidatorDirective,
    AppValidationMessageDirective,
    AppHttpServerErrorComponent,
  ],
  declarations: [
    PanelWidgetComponent,
    FormValidatorDirective,
    AppValidationMessageDirective,
    AppHttpServerErrorComponent,
    ServerErrorDailogComponent,
    SummaryValidationMessagesComponent,
  ],
  entryComponents: [
    ServerErrorDailogComponent
  ],
  providers: [
    AuthenticationService,
    AuthorizationGuardService,
    ServerValidationService,
    {
      provide: BASE_PATH, useValue: environment.basePath,
    },
    { provide: HTTP_INTERCEPTORS, useClass: AppHttpInterceptor, multi: true }
  ]
})
export class SharedModule { }
