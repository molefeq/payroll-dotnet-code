import { NgModule } from '@angular/core';
import { MaterialModule } from './material/material.module';
import { PanelWidgetComponent } from './components/panel-widget/panel-widget.component';

@NgModule({
  imports:[
    MaterialModule,
  ],
  exports:[
    MaterialModule,
    PanelWidgetComponent,
  ],
  declarations: [PanelWidgetComponent]
})
export class SharedModule { }
