import { Component, OnInit, ViewChild } from '@angular/core';
import { EmployeeFormConstants } from './employee-form-constants';
import { logoModel } from '../../../shared/models/logoModel';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { CompanyModel, EmployeeModel, ReferenceDataModel } from '../../../shared/generated';
import { CompanyDetailsService } from '../../company/company-details.service';
import { EmployeeDetailsService } from '../employee-details.service';
import { AppReferenceDataService } from '../../../shared/services/app-reference-data-service';
import { Router } from '@angular/router';
import { Constants } from '../../../shared/utils/constants';
import { serverValidation } from '../../../shared/validators/server-side-validator';
import { FormHelper } from '../../../shared/utils/form-helper';
import { FormFieldValidator } from '../../../shared/utils/form-fields-validator';
import { finalize } from 'rxjs/operators';
import { DateAdapter, MAT_DATE_LOCALE, MAT_DATE_FORMATS } from '@angular/material/core';
import { MatDatepicker } from '@angular/material/datepicker';
//import {MomentDateAdapter} from '@angular/material-moment-adapter';
import * as _moment from 'moment';
// tslint:disable-next-line:no-duplicate-imports
import { default as _rollupMoment } from 'moment';

const moment = _rollupMoment || _moment;

// See the Moment.js docs for the meaning of these formats:
// https://momentjs.com/docs/#/displaying/format/
export const MY_FORMATS = {
  parse: {
    dateInput: 'LL',
  },
  display: {
    dateInput: 'LL',
    monthYearLabel: 'MMM YYYY',
    dateA11yLabel: 'LL',
    monthYearA11yLabel: 'MMMM YYYY',
  },
};

@Component({
  selector: 'app-employee-form',
  templateUrl: './employee-form.component.html',
  styleUrls: ['./employee-form.component.scss'],
  providers: [
    // `MomentDateAdapter` can be automatically provided by importing `MomentDateModule` in your
    // application's root module. We provide it at the component level here, due to limitations of
    // our example generation script.
    // {provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE]},

    // {provide: MAT_DATE_FORMATS, useValue: MY_FORMATS},
  ],
})
export class EmployeeFormComponent implements OnInit {

  @ViewChild(MatDatepicker, {static: true}) dateOfBirthPicker: MatDatepicker<Date>;
  apiUrl: String = EmployeeFormConstants.UPLOAD_IMAGE_URL;
  logo: logoModel;

  employeeForm: FormGroup;
  isSubmited: boolean;
  isInProgress: boolean;
  heading: String = 'Create Employee';
  company: CompanyModel;
  validationMessages = EmployeeFormConstants.VALIDATION_MESSAGES;
  titles: Array<ReferenceDataModel>;
  languages: Array<ReferenceDataModel>;
  maritalStatuses: Array<ReferenceDataModel>;
  ethnicGroups: Array<ReferenceDataModel>;

  constructor(private fb: FormBuilder,
    private companyDetailsService: CompanyDetailsService,
    private employeeDetailsService: EmployeeDetailsService,
    private referenceDataService: AppReferenceDataService,
    private router: Router) { }

  ngOnInit() {
    this.company = this.companyDetailsService.Company;
    this.titles = this.referenceDataService.getTitles();
    this.languages = this.referenceDataService.getLanguages();
    this.maritalStatuses = this.referenceDataService.getMaritalStatuses();
    this.ethnicGroups = this.referenceDataService.getEthnicGroups();

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
      gender: ['', [Validators.required, serverValidation()]],
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
