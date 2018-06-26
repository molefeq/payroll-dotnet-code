import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RolesDetailsComponent } from './roles/roles-details/roles-details.component';
import { RolesFormComponent } from './roles/roles-form/roles-form.component';
import { AdminRoutingModule } from './admin-routing.module';
import { SharedModule } from '../../shared/shared.module';
import { AdminRoleService } from './roles/admin-role.service';

@NgModule({
  imports: [
    CommonModule,
    AdminRoutingModule,
    SharedModule
  ],
  exports: [
    RolesDetailsComponent
  ],
  entryComponents: [RolesFormComponent],
  declarations: [RolesDetailsComponent, RolesFormComponent],
  providers:[
    AdminRoleService
  ]
})
export class AdminModule { }
