import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RolesDetailsComponent } from './roles/roles-details/roles-details.component';

const rolesRoutes: Routes = [
  { path: 'roles', component: RolesDetailsComponent },
];

@NgModule({
  imports: [
    RouterModule.forRoot(
      rolesRoutes,
    )
  ],
  exports: [
    RouterModule
  ]
})
export class AdminRoutingModule { }
