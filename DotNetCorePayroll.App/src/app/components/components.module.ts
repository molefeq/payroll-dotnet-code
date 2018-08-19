import { NgModule } from '@angular/core';
import { SecurityModule } from './security/security.module';
import { SharedModule } from '../shared/shared.module';
import { HomeComponent } from './home/home.component';
import { ComponentsRoutingModule } from './components-routing.module';
import { AdminModule } from './admin/admin.module';
import { OrganisationDetailsComponent } from './organisation/organisation-details.component';
import { OrganisationFormComponent } from './organisation/organisation-form/organisation-form.component';
import { OrganisationDetailsService } from './organisation/organisation-details.service';
import { CompanyDetailsComponent } from './company/company-details.component';
import { CompanyDetailsService } from './company/company-details.service';
import { CompanyFormComponent } from './company/company-form/company-form.component';
import { CompanyAddressFormComponent } from './company/company-form/company-address-form/company-address-form.component';

@NgModule({
  imports: [
    SecurityModule,
    AdminModule,
    ComponentsRoutingModule,
    SharedModule
  ],
  providers: [
    OrganisationDetailsService,
    CompanyDetailsService
  ],
  entryComponents: [],
  declarations: [
    HomeComponent,
    OrganisationDetailsComponent,
    OrganisationFormComponent,
    CompanyDetailsComponent,
    CompanyFormComponent,
    CompanyAddressFormComponent,
  ]
})
export class ComponentsModule { }
