import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { serverValidation } from '../../../shared/validators/server-side-validator';
import { FormHelper } from '../../../shared/utils/form-helper';
import { AuthenticationService } from '../../../shared/services/authentication.service';
import { startWith, finalize } from 'rxjs/operators';
import { UserModel } from '../../../shared/generated';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  isSubmited: boolean;
  isInProgress: boolean;

  validationMessages = {
    username: {
      required: 'Username is required',
      minlength: 'Username cannot be less than 6 characters',
      serverValidation: ''
    },
    password: {
      required: 'Password is required',
      minlength: 'Password cannot be less than 6 characters',
      serverValidation: ''
    }
  };

  constructor(private router: Router, private fb: FormBuilder, private authenticationService: AuthenticationService) { }

  ngOnInit() {
    this.createForm();
  }

  createForm() {
    this.loginForm = this.fb.group({
      username: ['', [Validators.required, Validators.minLength(6), serverValidation()]],
      password: ['', [Validators.required, Validators.minLength(6), serverValidation()]],
    });

    this.isSubmited = false;
  }

  isControlInvalid(control: FormControl): boolean {
    return FormHelper.isErrorState(control, this.isSubmited);
  }

  login() {
    this.isSubmited = true;

    if (this.loginForm.invalid) {
      this.isSubmited = false;
      return;
    }

    this.isSubmited = false;
    this.isInProgress = true;

    this.authenticationService.login(this.loginForm.get("username").value, this.loginForm.get("password").value).pipe(
      finalize(() => {
        this.isInProgress = false;
      })).subscribe((data: UserModel) => {
        if (this.authenticationService.redirectUrl) {
          this.router.navigate([this.authenticationService.redirectUrl]);
          return;
        }
        this.router.navigate(['/home']);
      });
  }

}
