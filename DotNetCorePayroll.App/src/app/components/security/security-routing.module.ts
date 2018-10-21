import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { ChangePasswordComponent } from './change-password/change-password.component';

const secuirtyRoutes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'forgot-password', component: ForgotPasswordComponent },
  { path: 'change-password', component: ChangePasswordComponent },
];

@NgModule({
  imports: [
    RouterModule.forRoot(
      secuirtyRoutes,
    )
  ],
  exports: [
    RouterModule
  ]
})
export class SecurityRoutingModule { }
