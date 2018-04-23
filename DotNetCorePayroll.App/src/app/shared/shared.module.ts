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
import { ApiModule } from './generated';

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
  ],
  declarations: [
    PanelWidgetComponent,
    FormValidatorDirective,
    AppValidationMessageDirective,
  ],
  providers: [
    AuthenticationService,
    AuthorizationGuardService,
    ServerValidationService,
    { provide: HTTP_INTERCEPTORS, useClass: AppHttpInterceptor, multi: true }
  ]
})
export class SharedModule { }
