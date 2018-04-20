import { NgModule } from '@angular/core';
import { MaterialModule } from './material/material.module';
import { PanelWidgetComponent } from './components/panel-widget/panel-widget.component';
import { AuthenticationService } from './services/authentication.service';
import { AuthorizationGuardService } from './services/authorization-guard.service';
import { AppHttpInterceptor } from './interceptors/app-http-interceptor';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

@NgModule({
  imports:[
    MaterialModule,
    HttpClientModule
  ],
  exports:[
    MaterialModule,
    PanelWidgetComponent,
  ],
  declarations: [PanelWidgetComponent],
  providers:[
    AuthenticationService,
    AuthorizationGuardService,
    {provide: HTTP_INTERCEPTORS, useClass: AppHttpInterceptor, multi: true}
  ]
})
export class SharedModule { }
