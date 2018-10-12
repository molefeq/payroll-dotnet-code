import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { AdminUserService } from '../admin-user.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { AccountModel } from '../../../../shared/generated';
import { serverValidation } from '../../../../shared/validators/server-side-validator';
import { FormHelper } from '../../../../shared/utils/form-helper';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.scss']
})
export class UserFormComponent implements OnInit {

  userForm: FormGroup;
  isSubmited: boolean;
  isInProgress: boolean;

  validationMessages = {
    username: {
      required: 'Username is required and empty spaces are not allowed.',
      maxlength: 'Username cannot not be more than 100 characters.',
      serverValidation: ''
    },
    firstname: {
      required: 'Firstname is required.',
      maxlength: 'Firstname cannot not be more than 100 characters.',
      serverValidation: ''
    },
    lastname: {
      required: 'Lastname is required.',
      maxlength: 'Lastname cannot not be more than 100 characters.',
      serverValidation: ''
    },
    emailAddress: {
      required: 'Email Address is required.',
      email: 'Email Address must be a valid email address.',
      maxlength: 'Email Address cannot not be more than 500 characters.',
      serverValidation: ''
    },
    organisationId: {
      required: 'Organisation is required.',
      serverValidation: ''
    },
    companyId: {
      serverValidation: ''
    },
    roleId: {
      required: 'Role is required.',
      serverValidation: ''
    }
  };

  constructor(private fb: FormBuilder,
    private adminUserService: AdminUserService,
    public dialogRef: MatDialogRef<UserFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: AccountModel) { }

  ngOnInit() {
    this.createForm();
  }

  createForm() {
    this.userForm = this.fb.group({
      id: [null, []],
      username: ['', [Validators.required, Validators.maxLength(100), serverValidation()]],
      firstname: ['', [Validators.required, Validators.maxLength(100), serverValidation()]],
      lastname: ['', [Validators.required, Validators.maxLength(100), serverValidation()]],
      emailAddress: ['', [Validators.required, Validators.email, Validators.maxLength(500), serverValidation()]],
      organisationId: ['', [Validators.required, serverValidation()]],
      companyId: ['', [serverValidation()]],
      roleId: ['', [Validators.required, serverValidation()]],
    });

    this.isSubmited = false;
    this.initialiseForm();
  }

  initialiseForm() {
    if (!this.data) {
      return;
    }

    this.userForm.patchValue(this.data);
  }

  isControlInvalid(control: FormControl): boolean {
    return FormHelper.isErrorState(control, this.isSubmited);
  }

  saveRole() {
    this.isSubmited = true;

    if (this.userForm.invalid) {
      this.isSubmited = false;
      return;
    }

    this.isSubmited = false;
    this.isInProgress = true;
    const accountModel: AccountModel = Object.assign(Object.create(null), this.userForm.getRawValue());

    this.adminUserService.saveUser(accountModel).pipe(
      finalize(() => {
        this.isInProgress = false;
      })
    ).subscribe((data: AccountModel) => {
      this.dialogRef.close({
        dataSaved: true
      });
    });

  }

}
