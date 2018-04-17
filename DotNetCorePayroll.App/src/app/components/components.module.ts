import { NgModule } from '@angular/core';
import { SecurityModule } from './security/security.module';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  imports: [
    SecurityModule,
  ],
  declarations: []
})
export class ComponentsModule { }
