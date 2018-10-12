import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RolesDetailsComponent } from './roles/roles-details/roles-details.component';
import { RolesFormComponent } from './roles/roles-form/roles-form.component';
import { AdminRoutingModule } from './admin-routing.module';
import { SharedModule } from '../../shared/shared.module';
import { AdminRoleService } from './roles/admin-role.service';
import { UserDetailsComponent } from './users/user-details/user-details.component';
import { AdminUserService } from './users/admin-user.service';
import { UserFormComponent } from './users/user-form/user-form.component';

@NgModule({
  imports: [
    CommonModule,
    AdminRoutingModule,
    SharedModule
  ],
  exports: [
    RolesDetailsComponent
  ],
  entryComponents: [
    RolesFormComponent,
    UserFormComponent
  ],
  declarations: [
    RolesDetailsComponent,
    RolesFormComponent,
    UserDetailsComponent,
    UserFormComponent
  ],
  providers: [
    AdminRoleService,
    AdminUserService
  ]
})
export class AdminModule { }
