import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { SecurityRoutingModule } from './security-routing.module';
import { SharedModule } from '../../shared/shared.module';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { ChangePasswordComponent } from './change-password/change-password.component';

@NgModule({
  imports: [
    // The module that includes all the basic Angular directives like NgIf, NgForOf, ...
    CommonModule,
    SecurityRoutingModule,
    SharedModule,
  ],
  exports: [
    LoginComponent,
    ForgotPasswordComponent,
    ChangePasswordComponent
  ],
  declarations: [LoginComponent, ForgotPasswordComponent, ChangePasswordComponent]
})
export class SecurityModule { }
