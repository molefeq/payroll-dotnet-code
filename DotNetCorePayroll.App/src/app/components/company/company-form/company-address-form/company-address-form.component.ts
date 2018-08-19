import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '../../../../../../node_modules/@angular/forms';
import { serverValidation } from '../../../../shared/validators/server-side-validator';
import { Constants } from '../../../../shared/utils/constants';
import { CompanyDetailsService } from '../../company-details.service';
import { AppReferenceDataService } from '../../../../shared/services/app-reference-data-service';
import { ReferenceDataModel, CompanyContactDetailModel, CompanyModel } from '../../../../shared/generated';
import { FormFieldValidator } from '../../../../shared/utils/form-fields-validator';
import { MatCheckboxChange } from '../../../../../../node_modules/@angular/material';
import { OrganisationDetailsService } from '../../../organisation/organisation-details.service';
import { Router } from '../../../../../../node_modules/@angular/router';
import { CompanyAddressFormConstants } from './company-form-constants';
import { FormHelper } from '../../../../shared/utils/form-helper';
import { finalize } from '../../../../../../node_modules/rxjs/operators';

@Component({
  selector: 'app-company-address-form',
  templateUrl: './company-address-form.component.html',
  styleUrls: ['./company-address-form.component.scss']
})
export class CompanyAddressFormComponent implements OnInit {

  isSubmited: boolean;
  isInProgress: boolean;
  countries: Array<ReferenceDataModel>;
  provinces: Array<ReferenceDataModel>;
  companyAddressForm: FormGroup;
  postSameAsPhyAddress = false;
  validationMessages = CompanyAddressFormConstants.VALIDATION_MESSAGES;

  constructor(private fb: FormBuilder,
    private companyDetailsService: CompanyDetailsService,
    private referenceDataService: AppReferenceDataService,
    private organisationDetailsService: OrganisationDetailsService,
    private router: Router) { }

  ngOnInit() {
    this.countries = this.referenceDataService.getCountries();
    this.provinces = this.referenceDataService.getProvinces();
    this.createForm();
  }

  createForm() {

    this.companyAddressForm = this.fb.group({
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
    });

    this.companyAddressForm.get('postalAddressLine1').valueChanges.subscribe((postalAddressLine1: string) => {
      if (Boolean(postalAddressLine1)) {

        // tslint:disable-next-line:max-line-length
        this.companyAddressForm.get('postalAddressSuburb').setValidators([Validators.required, Validators.maxLength(100), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]);
        // tslint:disable-next-line:max-line-length
        this.companyAddressForm.get('postalAddressCity').setValidators([Validators.required, Validators.maxLength(100), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]);
        // tslint:disable-next-line:max-line-length
        this.companyAddressForm.get('postalAddressPostalCode').setValidators([Validators.required, Validators.maxLength(10), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP)]);
        // tslint:disable-next-line:max-line-length
        this.companyAddressForm.get('postalAddressProvinceId').setValidators([Validators.required, serverValidation()]);
        // tslint:disable-next-line:max-line-length
        this.companyAddressForm.get('postalAddressCountryId').setValidators([Validators.required, serverValidation()]);

      } else {
        // tslint:disable-next-line:max-line-length
        this.companyAddressForm.get('postalAddressSuburb').setValidators([Validators.maxLength(100), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]);
        // tslint:disable-next-line:max-line-length
        this.companyAddressForm.get('postalAddressCity').setValidators([Validators.maxLength(100), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]);
        // tslint:disable-next-line:max-line-length
        this.companyAddressForm.get('postalAddressPostalCode').setValidators([Validators.maxLength(10), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP)]);
        // tslint:disable-next-line:max-line-length
        this.companyAddressForm.get('postalAddressProvinceId').setValidators([serverValidation()]);
        // tslint:disable-next-line:max-line-length
        this.companyAddressForm.get('postalAddressCountryId').setValidators([serverValidation()]);
      }

      this.companyAddressForm.get('postalAddressSuburb').updateValueAndValidity();
      this.companyAddressForm.get('postalAddressCity').updateValueAndValidity();
      this.companyAddressForm.get('postalAddressPostalCode').updateValueAndValidity();
      this.companyAddressForm.get('postalAddressProvinceId').updateValueAndValidity();
      this.companyAddressForm.get('postalAddressCountryId').updateValueAndValidity();
    });

    this.initialiseForm();
  }

  initialiseForm() {
    if (!this.companyDetailsService.Company.contactDetails) {
      return;
    }

    this.companyAddressForm.patchValue(this.companyDetailsService.Company.contactDetails);
  }

  save() {
    if (this.companyAddressForm.invalid) {
      this.isSubmited = false;
      FormFieldValidator.validateAllFormFields(this.companyAddressForm);
      return;
    }

    this.isSubmited = false;
    this.isInProgress = true;

    const companyContactDetailModel: CompanyContactDetailModel = Object.assign(Object.create(null), this.companyAddressForm.getRawValue());

    companyContactDetailModel.companyId = this.companyDetailsService.Company.id;

    this.companyDetailsService.saveContactDetails(companyContactDetailModel).pipe(
      finalize(() => {
        this.isInProgress = false;
      })
    ).subscribe((data: CompanyModel) => {
      this.companyDetailsService.Company = data;
      this.initialiseForm();
    });
  }

  isPostalSameAsPhysicalAddress(event: MatCheckboxChange) {
    this.postSameAsPhyAddress = event.checked;

    if (!event.checked) {
      return;
    }

    this.companyAddressForm.get('postalAddressId').setValue(this.companyAddressForm.get('physicalAddressId').value);
    this.companyAddressForm.get('postalAddressLine1').setValue(this.companyAddressForm.get('physicalAddressLine1').value);
    this.companyAddressForm.get('postalAddressLine2').setValue(this.companyAddressForm.get('physicalAddressLine2').value);
    this.companyAddressForm.get('postalAddressSuburb').setValue(this.companyAddressForm.get('physicalAddressSuburb').value);
    this.companyAddressForm.get('postalAddressCity').setValue(this.companyAddressForm.get('physicalAddressCity').value);
    this.companyAddressForm.get('postalAddressPostalCode').setValue(this.companyAddressForm.get('physicalAddressPostalCode').value);
    this.companyAddressForm.get('postalAddressProvinceId').setValue(this.companyAddressForm.get('physicalAddressProvinceId').value);
    this.companyAddressForm.get('postalAddressCountryId').setValue(this.companyAddressForm.get('physicalAddressCountryId').value);
  }

  isControlInvalid(control: FormControl): boolean {
    return FormHelper.isErrorState(control, this.isSubmited);
  }

  cancel() {
    this.router.navigate(['/companies', this.organisationDetailsService.Organisation.id]);
  }
}
