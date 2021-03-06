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
import { AppReferenceDataService } from './services/app-reference-data-service';
import { AppStartUpService } from './services/app-startup-service';
import { LogoComponent } from './components/logo/logo.component';
import { FileUploadModule } from 'ng2-file-upload';
import { AppAsyncDropdownlistComponent } from './components/app-async-dropdownlist/app-async-dropdownlist.component';

@NgModule({
  imports: [
    MaterialModule,
    HttpClientModule,
    ReactiveFormsModule,
    ApiModule,
    FileUploadModule
  ],
  exports: [
    MaterialModule,
    ReactiveFormsModule,
    PanelWidgetComponent,
    FormValidatorDirective,
    AppValidationMessageDirective,
    AppHttpServerErrorComponent,
    SummaryValidationMessagesComponent,
    LogoComponent,
    AppAsyncDropdownlistComponent,
  ],
  declarations: [
    PanelWidgetComponent,
    FormValidatorDirective,
    AppValidationMessageDirective,
    AppHttpServerErrorComponent,
    ServerErrorDailogComponent,
    SummaryValidationMessagesComponent,
    LogoComponent,
    AppAsyncDropdownlistComponent,
  ],
  entryComponents: [
    ServerErrorDailogComponent
  ],
  providers: [
    AuthenticationService,
    AuthorizationGuardService,
    ServerValidationService,
    AppReferenceDataService,
    AppStartUpService,
    {
      provide: BASE_PATH, useValue: environment.basePath,
    },
    { provide: HTTP_INTERCEPTORS, useClass: AppHttpInterceptor, multi: true }
  ]
})
export class SharedModule { }
