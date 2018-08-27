import { Component, OnInit } from '@angular/core';
import { CompanyModel, EmployeeModel } from '../../../../shared/generated';
import { EmployeeAddressFormConstants } from './employee-form-constants';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { logoModel } from '../../../../shared/models/logoModel';
import { CompanyDetailsService } from '../../../company/company-details.service';
import { EmployeeDetailsService } from '../../employee-details.service';
import { AppReferenceDataService } from '../../../../shared/services/app-reference-data-service';
import { Router } from '@angular/router';
import { finalize } from 'rxjs/operators';
import { FormFieldValidator } from '../../../../shared/utils/form-fields-validator';
import { FormHelper } from '../../../../shared/utils/form-helper';
import { Constants } from '../../../../shared/utils/constants';
import { serverValidation } from '../../../../shared/validators/server-side-validator';

@Component({
  selector: 'app-employee-address-form',
  templateUrl: './employee-address-form.component.html',
  styleUrls: ['./employee-address-form.component.scss']
})
export class EmployeeAddressFormComponent implements OnInit {

  apiUrl: String = EmployeeAddressFormConstants.UPLOAD_IMAGE_URL;
  logo: logoModel;

  employeeForm: FormGroup;
  isSubmited: boolean;
  isInProgress: boolean;
  heading: String = 'Create Employee';
  company: CompanyModel;
  validationMessages = EmployeeAddressFormConstants.VALIDATION_MESSAGES;

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
      name: ['', [Validators.required, Validators.maxLength(200), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]],
      registeredName: ['', [Validators.maxLength(100), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]],
      tradingName: ['', [Validators.maxLength(100), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]],
      natureOfBusiness: ['', [Validators.maxLength(20), serverValidation()]],
      companyRegistrationNumber: ['', [Validators.maxLength(100), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]],
      // tslint:disable-next-line:max-line-length
      taxNumber: ['', [Validators.required, Validators.maxLength(50), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]],
      // tslint:disable-next-line:max-line-length
      payeReferenceNumber: ['', [Validators.required, Validators.maxLength(50), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]],
      // tslint:disable-next-line:max-line-length
      uifReferenceNumber: ['', [Validators.maxLength(50), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]],
      // tslint:disable-next-line:max-line-length
      uifCompanyReferenceNumber: ['', [Validators.required, Validators.maxLength(50), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]],
      // tslint:disable-next-line:max-line-length
      sarsUifNumber: ['', [Validators.required, Validators.maxLength(50), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]],
      paysdlInd: ['', [serverValidation()]],
      physicalAddressId: ['', [serverValidation()]],
      // tslint:disable-next-line:max-line-length
      physicalAddressLine1: ['', [Validators.required, Validators.maxLength(100), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]],
      physicalAddressLine2: ['', [Validators.maxLength(100), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]],
      // tslint:disable-next-line:max-line-length
      physicalAddressSuburb: ['', [Validators.required, Validators.maxLength(100), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]],
      // tslint:disable-next-line:max-line-length
      physicalAddressCity: ['', [Validators.required, Validators.maxLength(100), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]],
      // tslint:disable-next-line:max-line-length
      physicalAddressPostalCode: ['', [Validators.required, Validators.maxLength(10), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]],
      physicalAddressProvinceId: ['', [Validators.required, serverValidation()]],
      physicalAddressCountryId: ['', [Validators.required, serverValidation()]],
      postalAddressId: ['', [serverValidation()]],
      postalAddressLine1: ['', [Validators.maxLength(100), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]],
      postalAddressLine2: ['', [Validators.maxLength(100), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]],
      postalAddressSuburb: ['', [Validators.maxLength(100), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]],
      postalAddressCity: ['', [Validators.maxLength(100), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]],
      postalAddressPostalCode: ['', [Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), Validators.maxLength(10), serverValidation()]],
      postalAddressProvinceId: ['', [serverValidation()]],
      postalAddressCountryId: ['', [serverValidation()]],
      faxNumber: ['', [Validators.pattern(Constants.TELEPHONE_REG_EXP), Validators.maxLength(20), serverValidation()]],
      emailAddress: ['', [Validators.required, Validators.email, Validators.maxLength(500), serverValidation()]],
      // tslint:disable-next-line:max-line-length
      contactNumber: ['', [Validators.required, Validators.pattern(Constants.TELEPHONE_REG_EXP), Validators.maxLength(20), serverValidation()]]
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
