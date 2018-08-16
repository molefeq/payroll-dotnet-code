import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AuthorizationGuardService } from '../shared/services/authorization-guard.service';
import { OrganisationDetailsComponent } from './organisation/organisation-details.component';
import { CompanyDetailsComponent } from './company/company-details.component';
import { OrganisationFormComponent } from './organisation/organisation-form/organisation-form.component';
import { CompanyFormComponent } from './company/company-form/company-form.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent, canActivate: [AuthorizationGuardService] },
  { path: 'organisations', component: OrganisationDetailsComponent, canActivate: [AuthorizationGuardService] },
  { path: 'organisation/:organisationId', component: OrganisationFormComponent, canActivate: [AuthorizationGuardService] },
  { path: 'organisation', component: OrganisationFormComponent, canActivate: [AuthorizationGuardService] },
  { path: 'companies/:organisationId', component: CompanyDetailsComponent, canActivate: [AuthorizationGuardService] },
  { path: 'company/:companyId', component: CompanyFormComponent, canActivate: [AuthorizationGuardService] },
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
