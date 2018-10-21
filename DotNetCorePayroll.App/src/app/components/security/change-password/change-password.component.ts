import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { ChangePasswordConstants } from './change-password-constants';
import { FormHelper } from '../../../shared/utils/form-helper';
import { AuthenticationService } from '../../../shared/services/authentication.service';
import { ChangePasswordModel, UserModel } from '../../../shared/generated';
import { finalize } from 'rxjs/operators';
import { Router } from '@angular/router';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.scss']
})
export class ChangePasswordComponent implements OnInit {

  changePasswordForm: FormGroup;
  isSubmited: boolean;
  isInProgress: boolean;
  validationMessages = ChangePasswordConstants.VALIDATION_MESSAGES;

  constructor(private router: Router,
    private fb: FormBuilder,
    private authenticationService: AuthenticationService) { }

  ngOnInit() {
    this.createForm();
  }

  createForm(): void {
    this.changePasswordForm = this.fb.group(ChangePasswordConstants.FORM_FIELDS);
    this.changePasswordForm.get('username').setValue(this.authenticationService.user.userName);
    this.isSubmited = false;
  }

  isControlInvalid(control: FormControl): boolean {
    return FormHelper.isErrorState(control, this.isSubmited);
  }

  changePassword() {
    this.isSubmited = true;

    if (this.changePasswordForm.invalid) {
      this.isSubmited = false;
      return;
    }

    this.isSubmited = false;
    this.isInProgress = true;
    const model: ChangePasswordModel = Object.assign(Object.create(null), this.changePasswordForm.getRawValue());

    this.authenticationService.changePassword(model).pipe(
      finalize(() => {
        this.isInProgress = false;
      })).subscribe((data: UserModel) => {
        this.router.navigate(['/home']);
      });
  }
}
