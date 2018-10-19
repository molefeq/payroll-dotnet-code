import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { AdminUserService } from '../admin-user.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { AccountModel } from '../../../../shared/generated';
import { FormHelper } from '../../../../shared/utils/form-helper';
import { finalize } from 'rxjs/operators';
import { FormFieldValidator } from '../../../../shared/utils/form-fields-validator';
import { AppReferenceDataService } from '../../../../shared/services/app-reference-data-service';
import { DropdownDataSource } from '../../../../shared/models/dropdownDataSource';
import { UserConstants } from './user-form-constants';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.scss']
})
export class UserFormComponent implements OnInit {

  userForm: FormGroup;
  isSubmited: boolean;
  organisationsData: DropdownDataSource;
  companiesData: DropdownDataSource;
  rolesData: DropdownDataSource;
  isInProgress$ = this.adminUserService.isInProgress$;

  validationMessages = UserConstants.VALIDATION_MESSAGES;

  constructor(private fb: FormBuilder,
    private adminUserService: AdminUserService,
    private appReferenceDataService: AppReferenceDataService,
    public dialogRef: MatDialogRef<UserFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: AccountModel) { }

  ngOnInit() {
    this.createForm();
  }

  createForm(): void {
    this.userForm = this.fb.group(UserConstants.USER_FORM_FIELDS);

    this.isSubmited = false;
    this.initialiseForm();
    this.initialiseReferenceData();
  }

  initialiseForm(): void {
    if (!this.data) {
      return;
    }

    this.userForm.patchValue(this.data);
  }

  initialiseReferenceData(): void {
    this.organisationsData = this.appReferenceDataService.organisationData();
    // tslint:disable-next-line:max-line-length
    this.companiesData = this.appReferenceDataService.companyData(this.data ? this.data.organisationId : null, this.userForm.get('organisationId').valueChanges);
    this.rolesData = this.appReferenceDataService.rolesData();
  }

  isControlInvalid(control: FormControl): boolean {
    return FormHelper.isErrorState(control, this.isSubmited);
  }

  saveUser(): void {
    this.isSubmited = true;

    if (this.userForm.invalid) {
      this.isSubmited = false;
      FormFieldValidator.validateAllFormFields(this.userForm);
      return;
    }

    this.isSubmited = false;
    const accountModel: AccountModel = Object.assign(Object.create(null), this.userForm.getRawValue());

    this.adminUserService.saveUser(accountModel).subscribe((data: AccountModel) => {
      this.dialogRef.close({
        dataSaved: true
      });
    });
  }
}
