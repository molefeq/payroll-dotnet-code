import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { CompanyDetailsService } from '../../company-details.service';
import { Router } from '@angular/router';
import { OrganisationDetailsService } from '../../../organisation/organisation-details.service';
import { serverValidation } from '../../../../shared/validators/server-side-validator';
import { Constants } from '../../../../shared/utils/constants';
import { CompanyPayrollSettingConstants } from './company-payroll-setting-constants';
import { FormFieldValidator } from '../../../../shared/utils/form-fields-validator';
import { CompanyPayrollSettingModel, CompanyModel } from '../../../../shared/generated';
import { finalize } from 'rxjs/operators';
import { FormHelper } from '../../../../shared/utils/form-helper';

@Component({
  selector: 'app-company-payroll-settings-form',
  templateUrl: './company-payroll-settings-form.component.html',
  styleUrls: ['./company-payroll-settings-form.component.scss']
})
export class CompanyPayrollSettingsFormComponent implements OnInit {

  isSubmited: boolean;
  isInProgress: boolean;
  companyPayrollSettingsForm: FormGroup;
  validationMessages = CompanyPayrollSettingConstants.VALIDATION_MESSAGES;

  constructor(private fb: FormBuilder,
    private companyDetailsService: CompanyDetailsService,
    private organisationDetailsService: OrganisationDetailsService,
    private router: Router) { }

  ngOnInit() {
    this.createForm();
  }

  createForm() {

    this.companyPayrollSettingsForm = this.fb.group({
      id: ['', [serverValidation()]],
      // tslint:disable-next-line:max-line-length
      monthPeriods: ['', [Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]],
      weeklyPeriods: ['', [Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]],
      // tslint:disable-next-line:max-line-length
      hoursPerDay: ['', [Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]],
      // tslint:disable-next-line:max-line-length
      hoursPerWeek: ['', [Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]],
      // tslint:disable-next-line:max-line-length
      daysPerMonth: ['', [Validators.required, Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]]
    });

    this.initialiseForm();
  }

  initialiseForm() {
    if (!this.companyDetailsService.Company || !this.companyDetailsService.Company.contactDetails) {
      return;
    }

    this.companyPayrollSettingsForm.patchValue(this.companyDetailsService.Company.payrollSettings);
  }

  isControlInvalid(control: FormControl): boolean {
    return FormHelper.isErrorState(control, this.isSubmited);
  }

  save() {
    if (this.companyPayrollSettingsForm.invalid) {
      this.isSubmited = false;
      FormFieldValidator.validateAllFormFields(this.companyPayrollSettingsForm);
      return;
    }

    this.isSubmited = false;
    this.isInProgress = true;

    // tslint:disable-next-line:max-line-length
    const companyContactDetailModel: CompanyPayrollSettingModel = Object.assign(Object.create(null), this.companyPayrollSettingsForm.getRawValue());

    companyContactDetailModel.companyId = this.companyDetailsService.Company.id;

    this.companyDetailsService.savePayrollSettings(companyContactDetailModel).pipe(
      finalize(() => {
        this.isInProgress = false;
      })
    ).subscribe((data: CompanyModel) => {
      this.companyDetailsService.Company = data;
      this.initialiseForm();
    });
  }

  cancel() {
    this.router.navigate(['/companies', this.organisationDetailsService.Organisation.id]);
  }
}
