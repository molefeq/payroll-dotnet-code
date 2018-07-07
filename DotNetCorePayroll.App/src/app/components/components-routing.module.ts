import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AuthorizationGuardService } from '../shared/services/authorization-guard.service';
import { OrganisationDetailsComponent } from './organisation/organisation-details.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent, canActivate: [AuthorizationGuardService] },
  { path: 'organisations', component: OrganisationDetailsComponent, canActivate: [AuthorizationGuardService] },
];

@NgModule({
  imports: [
    RouterModule.forRoot(
      routes,
    )
  ],
  exports: [
    RouterModule
  ]
})
export class ComponentsRoutingModule { }
