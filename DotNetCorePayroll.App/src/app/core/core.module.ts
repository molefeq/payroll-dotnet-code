import { NgModule } from '@angular/core';
import { FooterComponent } from './footer/footer.component';
import { HeaderComponent } from './header/header.component';
import { SharedModule } from '../shared/shared.module';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';

@NgModule({
  imports:[
    SharedModule
  ],
  declarations: [
    FooterComponent,
    HeaderComponent,
    PageNotFoundComponent,
  ], 
  exports: [
    FooterComponent,
    HeaderComponent,
    PageNotFoundComponent]
})
export class CoreModule { }
