import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RolesDetailsComponent } from './roles/roles-details/roles-details.component';
import { UserDetailsComponent } from './users/user-details/user-details.component';

const adminRoutes: Routes = [
  { path: 'roles', component: RolesDetailsComponent },
  { path: 'users', component: UserDetailsComponent },
];

@NgModule({
  imports: [
    RouterModule.forRoot(
      adminRoutes,
    )
  ],
  exports: [
    RouterModule
  ]
})
export class AdminRoutingModule { }
