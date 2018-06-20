import { NgModule } from '@angular/core';
import { SecurityModule } from './security/security.module';
import { SharedModule } from '../shared/shared.module';
import { HomeComponent } from './home/home.component';
import { ComponentsRoutingModule } from './components-routing.module';
import { AdminModule } from './admin/admin.module';

@NgModule({
  imports: [
    SecurityModule,
    AdminModule,
    ComponentsRoutingModule,
    SharedModule,
  ],
  declarations: [HomeComponent]
})
export class ComponentsModule { }
