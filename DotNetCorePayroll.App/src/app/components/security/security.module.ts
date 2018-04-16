import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { SecurityRoutingModule } from './security-routing.module';

@NgModule({
  imports: [
    // The module that includes all the basic Angular directives like NgIf, NgForOf, ...
    CommonModule,
    SecurityRoutingModule
  ],
  exports: [
    LoginComponent
  ],
  declarations: [LoginComponent]
})
export class SecurityModule { }
