import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { serverValidation } from '../../../shared/validators/server-side-validator';
import { FormHelper } from '../../../shared/utils/form-helper';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  isSubmited: boolean;

  validationMessages = {
    username: {
      required: '',
      minlength: '',
      serverValidation: ''
    },    
    password: {
      required: '',
      minlength: '',
      serverValidation: ''
    }
  };

  constructor(private router: Router, private fb: FormBuilder) { }

  ngOnInit() {
    this.createForm();
    this.validationMessages = {
      username: {
        required: 'Username is required',
        minlength: 'Username cannot be less than 2 characters',
        serverValidation: ''
      },
      password: {
        required: 'Password is required',
        minlength: 'Password cannot be less than 2 characters',
        serverValidation: ''
      }
    }
  }

  createForm() {
    this.loginForm = this.fb.group({
      username: ['', [Validators.required, Validators.minLength(2)]],//,
      password: ['', [Validators.required, Validators.minLength(2)],
    });
    this.isSubmited = false;
  }

  isControlInvalid(control: FormControl): boolean {
    return FormHelper.isErrorState(control, this.isSubmited);
  }

  login() {
    this.isSubmited = true;
    this.router.navigate(['/home']);
  }

}
