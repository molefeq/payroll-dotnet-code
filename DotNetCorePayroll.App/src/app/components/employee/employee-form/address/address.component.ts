import { Component, OnInit } from '@angular/core';
import { ReferenceDataModel, EmployeeModel } from '../../../../../../src/app/shared/generated';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { EmployeeDetailsService } from '../../employee-details.service';
import { AppReferenceDataService } from '../../../../../../src/app/shared/services/app-reference-data-service';
import { OrganisationDetailsService } from '../../../../../../src/app/components/organisation/organisation-details.service';
import { Router } from '@angular/router';
import { serverValidation } from '../../../../../../src/app/shared/validators/server-side-validator';
import { Constants } from '../../../../../../src/app/shared/utils/constants';
import { FormFieldValidator } from '../../../../../../src/app/shared/utils/form-fields-validator';
import { finalize } from 'rxjs/operators';
import { MatCheckboxChange } from '@angular/material/checkbox';
import { FormHelper } from '../../../../../../src/app/shared/utils/form-helper';
import { EmployeeAddressFormConstants } from './address-form-constants';

@Component({
  selector: 'app-address',
  templateUrl: './address.component.html',
  styleUrls: ['./address.component.scss']
})
export class AddressComponent implements OnInit {

  isSubmited: boolean;
  isInProgress: boolean;
  countries: Array<ReferenceDataModel>;
  provinces: Array<ReferenceDataModel>;
  addressForm: FormGroup;
  postSameAsPhyAddress = false;
  validationMessages = EmployeeAddressFormConstants.VALIDATION_MESSAGES;

  constructor(private fb: FormBuilder,
    private employeeDetailsService: EmployeeDetailsService,
    private referenceDataService: AppReferenceDataService,
    private organisationDetailsService: OrganisationDetailsService,
    private router: Router) { }

  ngOnInit() {
    this.countries = this.referenceDataService.getCountries();
    this.provinces = this.referenceDataService.getProvinces();
    this.createForm();
  }

  createForm() {

    this.addressForm = this.fb.group({
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

    this.addressForm.get('postalAddressLine1').valueChanges.subscribe((postalAddressLine1: string) => {
      if (Boolean(postalAddressLine1)) {

        // tslint:disable-next-line:max-line-length
        this.addressForm.get('postalAddressSuburb').setValidators([Validators.required, Validators.maxLength(100), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]);
        // tslint:disable-next-line:max-line-length
        this.addressForm.get('postalAddressCity').setValidators([Validators.required, Validators.maxLength(100), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]);
        // tslint:disable-next-line:max-line-length
        this.addressForm.get('postalAddressPostalCode').setValidators([Validators.required, Validators.maxLength(10), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP)]);
        // tslint:disable-next-line:max-line-length
        this.addressForm.get('postalAddressProvinceId').setValidators([Validators.required, serverValidation()]);
        // tslint:disable-next-line:max-line-length
        this.addressForm.get('postalAddressCountryId').setValidators([Validators.required, serverValidation()]);

      } else {
        // tslint:disable-next-line:max-line-length
        this.addressForm.get('postalAddressSuburb').setValidators([Validators.maxLength(100), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]);
        // tslint:disable-next-line:max-line-length
        this.addressForm.get('postalAddressCity').setValidators([Validators.maxLength(100), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]);
        // tslint:disable-next-line:max-line-length
        this.addressForm.get('postalAddressPostalCode').setValidators([Validators.maxLength(10), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP)]);
        // tslint:disable-next-line:max-line-length
        this.addressForm.get('postalAddressProvinceId').setValidators([serverValidation()]);
        // tslint:disable-next-line:max-line-length
        this.addressForm.get('postalAddressCountryId').setValidators([serverValidation()]);
      }

      this.addressForm.get('postalAddressSuburb').updateValueAndValidity();
      this.addressForm.get('postalAddressCity').updateValueAndValidity();
      this.addressForm.get('postalAddressPostalCode').updateValueAndValidity();
      this.addressForm.get('postalAddressProvinceId').updateValueAndValidity();
      this.addressForm.get('postalAddressCountryId').updateValueAndValidity();
    });

    this.initialiseForm();
  }

  initialiseForm() {
    if (!this.employeeDetailsService.Employee) {
      return;
    }

    this.addressForm.patchValue(this.employeeDetailsService.Employee);
  }

  save() {
    if (this.addressForm.invalid) {
      this.isSubmited = false;
      FormFieldValidator.validateAllFormFields(this.addressForm);
      return;
    }

    this.isSubmited = false;
    this.isInProgress = true;

    const employeeModel: EmployeeModel = Object.assign(Object.create(null), this.addressForm.getRawValue());

    // employeeModel.companyId = this.employeeDetailsService.Company.id;

    /* this.employeeDetailsService.saveContactDetails(employeeModel).pipe(
      finalize(() => {
        this.isInProgress = false;
      })
    ).subscribe((data: EmployeeModel) => {
      this.employeeDetailsService.Employee = data;
      this.initialiseForm();
    });*/
  }

  isPostalSameAsPhysicalAddress(event: MatCheckboxChange) {
    this.postSameAsPhyAddress = event.checked;

    if (!event.checked) {
      return;
    }

    this.addressForm.get('postalAddressId').setValue(this.addressForm.get('physicalAddressId').value);
    this.addressForm.get('postalAddressLine1').setValue(this.addressForm.get('physicalAddressLine1').value);
    this.addressForm.get('postalAddressLine2').setValue(this.addressForm.get('physicalAddressLine2').value);
    this.addressForm.get('postalAddressSuburb').setValue(this.addressForm.get('physicalAddressSuburb').value);
    this.addressForm.get('postalAddressCity').setValue(this.addressForm.get('physicalAddressCity').value);
    this.addressForm.get('postalAddressPostalCode').setValue(this.addressForm.get('physicalAddressPostalCode').value);
    this.addressForm.get('postalAddressProvinceId').setValue(this.addressForm.get('physicalAddressProvinceId').value);
    this.addressForm.get('postalAddressCountryId').setValue(this.addressForm.get('physicalAddressCountryId').value);
  }

  isControlInvalid(control: FormControl): boolean {
    return FormHelper.isErrorState(control, this.isSubmited);
  }

  cancel() {
    this.router.navigate(['/employees', this.employeeDetailsService.Employee.id]);
  }

}
