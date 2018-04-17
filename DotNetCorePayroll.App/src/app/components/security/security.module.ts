import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { SecurityRoutingModule } from './security-routing.module';
import { SharedModule } from '../../shared/shared.module';

@NgModule({
  imports: [
    // The module that includes all the basic Angular directives like NgIf, NgForOf, ...
    CommonModule,
    SecurityRoutingModule,
    SharedModule,
  ],
  exports: [
    LoginComponent
  ],
  declarations: [LoginComponent]
})
export class SecurityModule { }
