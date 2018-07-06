import { NgModule } from '@angular/core';
import { SecurityModule } from './security/security.module';
import { SharedModule } from '../shared/shared.module';
import { HomeComponent } from './home/home.component';
import { ComponentsRoutingModule } from './components-routing.module';
import { AdminModule } from './admin/admin.module';
import { OrganisationDetailsComponent } from './organisation/organisation-details.component';
import { OrganisationFormComponent } from './organisation/organisation-form/organisation-form.component';
import { OrganisationDetailsService } from './organisation/organisation-details.service';

@NgModule({
  imports: [
    SecurityModule,
    AdminModule,
    ComponentsRoutingModule,
    SharedModule
  ],
  providers:[
    OrganisationDetailsService
  ],
  entryComponents: [OrganisationFormComponent],
  declarations: [HomeComponent, OrganisationDetailsComponent, OrganisationFormComponent]
})
export class ComponentsModule { }
