import { Component, OnInit } from '@angular/core';
import { EmployeeFormConstants } from './employee-form-constants';
import { logoModel } from '../../../shared/models/logoModel';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { CompanyModel, EmployeeModel } from '../../../shared/generated';
import { CompanyDetailsService } from '../../company/company-details.service';
import { EmployeeDetailsService } from '../employee-details.service';
import { AppReferenceDataService } from '../../../shared/services/app-reference-data-service';
import { Router } from '@angular/router';
import { Constants } from '../../../shared/utils/constants';
import { serverValidation } from '../../../shared/validators/server-side-validator';
import { FormHelper } from '../../../shared/utils/form-helper';
import { FormFieldValidator } from '../../../shared/utils/form-fields-validator';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-employee-form',
  templateUrl: './employee-form.component.html',
  styleUrls: ['./employee-form.component.scss']
})
export class EmployeeFormComponent implements OnInit {


  apiUrl: String = EmployeeFormConstants.UPLOAD_IMAGE_URL;
  logo: logoModel;

  employeeForm: FormGroup;
  isSubmited: boolean;
  isInProgress: boolean;
  heading: String = 'Create Employee';
  company: CompanyModel;
  validationMessages = EmployeeFormConstants.VALIDATION_MESSAGES;

  constructor(private fb: FormBuilder,
    private companyDetailsService: CompanyDetailsService,
    private employeeDetailsService: EmployeeDetailsService,
    private referenceDataService: AppReferenceDataService,
    private router: Router) { }

  ngOnInit() {
    this.company = this.companyDetailsService.Company;
    this.createForm();
  }

  createForm() {
    this.employeeForm = this.fb.group({
      id: [null, []],
      // tslint:disable-next-line:max-line-length
      employeeNumber: ['', [Validators.required, Validators.maxLength(20), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]],
      // tslint:disable-next-line:max-line-length
      title: ['', [serverValidation()]],
      // tslint:disable-next-line:max-line-length
      firstName: ['', [Validators.required, Validators.maxLength(200), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]],
      // tslint:disable-next-line:max-line-length
      initials: ['', [Validators.required, Validators.maxLength(20), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]],
      // tslint:disable-next-line:max-line-length
      lastName: ['', [Validators.required, Validators.maxLength(100), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]],
      // tslint:disable-next-line:max-line-length
      nickName: ['', [Validators.maxLength(100), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]],
      // tslint:disable-next-line:max-line-length
      dateOfBirth: ['', [Validators.required, serverValidation()]],
      // tslint:disable-next-line:max-line-length
      isSouthAfricanCitizen: ['', [serverValidation()]],
      // tslint:disable-next-line:max-line-length
      idOrPassportNumber: ['', [Validators.required, Validators.maxLength(50), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]],
      // tslint:disable-next-line:max-line-length
      ethnicGroup: ['', [serverValidation()]],
      gender: ['', [serverValidation()]],
      hasDisability: ['', [serverValidation()]],
      // tslint:disable-next-line:max-line-length
      disabilityDescription: ['', [Validators.maxLength(100), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]],
      maritalStatus: ['', [serverValidation()]],
      // tslint:disable-next-line:max-line-length
      homeLanguage: ['', [serverValidation()]],
      // tslint:disable-next-line:max-line-length
      taxReferenceNumber: ['', [Validators.required, Validators.maxLength(50), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]],
      // tslint:disable-next-line:max-line-length
      emailAddress: ['', [Validators.required, Validators.email, Validators.maxLength(500), serverValidation()]],
      workNumber: ['', [Validators.maxLength(20), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]],
      homeNumber: ['', [Validators.maxLength(20), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]],
      // tslint:disable-next-line:max-line-length
      mobileNumber: ['', [Validators.maxLength(20), Validators.maxLength(20), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]]
    });

    this.logo = {
      logoUrl: '',
      logoFilename: ''
    };

    this.isSubmited = false;
    this.initialiseForm();
  }

  initialiseForm() {
    if (!this.employeeDetailsService.Employee) {
      return;
    }

    this.heading = 'Edit Employee';
    // this.logo = {
    //   logoUrl: this.employeeDetailsService.Employee.logoFileNamePath,
    //   logoFilename: this.employeeDetailsService.Employee.logoFileName
    // };

    this.employeeForm.patchValue(this.employeeDetailsService.Employee);
  }

  isControlInvalid(control: FormControl): boolean {
    return FormHelper.isErrorState(control, this.isSubmited);
  }

  save() {
    if (this.employeeForm.invalid) {
      this.isSubmited = false;
      FormFieldValidator.validateAllFormFields(this.employeeForm);
      return;
    }

    this.isSubmited = false;
    this.isInProgress = true;

    const employeeModel: EmployeeModel = Object.assign(Object.create(null), this.employeeForm.getRawValue());

    // employeeModel.l = this.logo.logoFilename;

    this.employeeDetailsService.saveEmployee(employeeModel).pipe(
      finalize(() => {
        this.isInProgress = false;
      })
    ).subscribe((data: EmployeeModel) => {
    });
  }

  cancel() {
    this.router.navigate(['/employees', this.companyDetailsService.Company.id]);
  }

  logoChanged(event: logoModel) {
    this.logo = event;
  }

}
