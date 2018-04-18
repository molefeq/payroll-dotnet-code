import { NgModule } from '@angular/core';
import { SecurityModule } from './security/security.module';
import { SharedModule } from '../shared/shared.module';
import { HomeComponent } from './home/home.component';
import { ComponentsRoutingModule } from './components-routing.module';

@NgModule({
  imports: [
    SecurityModule,
    ComponentsRoutingModule,
    SharedModule,
  ],
  declarations: [HomeComponent]
})
export class ComponentsModule { }
