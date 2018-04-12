import { NgModule } from '@angular/core';
import { MaterialModule } from './material/material.module';

@NgModule({
  exports:[
    MaterialModule,
  ],
  declarations: []
})
export class SharedModule { }
