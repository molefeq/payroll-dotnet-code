import { NgModule } from '@angular/core';
import { MaterialModule } from './material/material.module';
import { PanelWidgetComponent } from './components/panel-widget/panel-widget.component';
import { AuthenticationService } from './services/authentication.service';
import { AuthorizationGuardService } from './services/authorization-guard.service';

@NgModule({
  imports:[
    MaterialModule,
  ],
  exports:[
    MaterialModule,
    PanelWidgetComponent,
  ],
  declarations: [PanelWidgetComponent],
  providers:[
    AuthenticationService,
    AuthorizationGuardService
  ]
})
export class SharedModule { }
