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
import { ValidationMessagesComponent } from './components/validation-messages/validation-messages.component';

@NgModule({
  imports:[
    MaterialModule,
    HttpClientModule,    
    ReactiveFormsModule,
  ],
  exports:[
    MaterialModule,
    ReactiveFormsModule,
    PanelWidgetComponent,
    FormValidatorDirective,
    ValidationMessagesComponent,
  ],
  declarations: [
    PanelWidgetComponent, 
    FormValidatorDirective, 
    ValidationMessagesComponent,
  ],
  providers:[
    AuthenticationService,
    AuthorizationGuardService,
    ServerValidationService,
    {provide: HTTP_INTERCEPTORS, useClass: AppHttpInterceptor, multi: true}
  ]
})
export class SharedModule { }
