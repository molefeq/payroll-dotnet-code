import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RolesDetailsComponent } from './roles/roles-details/roles-details.component';
import { RolesFormComponent } from './roles/roles-form/roles-form.component';
import { AdminRoutingModule } from './admin-routing.module';
import { SharedModule } from '../../shared/shared.module';

@NgModule({
  imports: [
    CommonModule,
    AdminRoutingModule,
    SharedModule
  ],
  exports: [
    RolesDetailsComponent
  ],
  declarations: [RolesDetailsComponent, RolesFormComponent]
})
export class AdminModule { }
