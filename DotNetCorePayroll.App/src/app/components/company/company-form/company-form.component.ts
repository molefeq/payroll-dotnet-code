import { Component, OnInit, } from '@angular/core';
import { logoModel } from '../../../shared/models/logoModel';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { CompanyDetailsService } from '../company-details.service';
import { AppReferenceDataService } from '../../../shared/services/app-reference-data-service';
import { MatCheckboxChange } from '@angular/material';
import { CompanyModel, ReferenceDataModel, OrganisationModel } from '../../../shared/generated';
import { FormHelper } from '../../../shared/utils/form-helper';
import { serverValidation } from '../../../shared/validators/server-side-validator';
import { finalize } from 'rxjs/operators';
import { CompanyConstants } from './company-constants';
import { OrganisationDetailsService } from '../../organisation/organisation-details.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-company-form',
  templateUrl: './company-form.component.html',
  styleUrls: ['./company-form.component.scss']
})
export class CompanyFormComponent implements OnInit {

  apiUrl: String = CompanyConstants.UPLOAD_IMAGE_URL;
  logo: logoModel;

  companyForm: FormGroup;
  isSubmited: boolean;
  isInProgress: boolean;
  heading: String = 'Create Company';
  countries: Array<ReferenceDataModel>;
  provinces: Array<ReferenceDataModel>;
  organisation: OrganisationModel;
  validationMessages = CompanyConstants.VALIDATION_MESSAGES;
  postSameAsPhyAddress = false;

  constructor(private fb: FormBuilder,
    private organisationDetailsService: OrganisationDetailsService,
    private companyDetailsService: CompanyDetailsService,
    private referenceDataService: AppReferenceDataService,
    private router: Router) {
  }

  ngOnInit() {
    this.organisation = this.organisationDetailsService.Organisation;
    this.countries = this.referenceDataService.getCountries();
    this.provinces = this.referenceDataService.getProvinces();
    this.createForm();
  }

  createForm() {
    this.companyForm = this.fb.group({
      id: [null, []],
      name: ['', [Validators.required, Validators.maxLength(20), serverValidation()]],
      registeredName: ['', [Validators.maxLength(20), serverValidation()]],
      tradingName: ['', [Validators.maxLength(20), serverValidation()]],
      natureOfBusiness: ['', [Validators.maxLength(20), serverValidation()]],
      companyRegistrationNumber: ['', [Validators.maxLength(20), serverValidation()]],
      taxNumber: ['', [Validators.maxLength(20), serverValidation()]],
      uifReferenceNumber: ['', [Validators.maxLength(20), serverValidation()]],
      payeReferenceNumber: ['', [Validators.maxLength(20), serverValidation()]],
      uifCompanyReferenceNumber: ['', [Validators.maxLength(20), serverValidation()]],
      sarsUifNumber: ['', [Validators.maxLength(20), serverValidation()]],
      paysdlInd: ['', [serverValidation()]],
      physicalAddressId: ['', [serverValidation()]],
      physicalAddressLine1: ['', [Validators.required, Validators.maxLength(200), serverValidation()]],
      physicalAddressLine2: ['', [serverValidation()]],
      physicalAddressSuburb: ['', [Validators.required, Validators.maxLength(200), serverValidation()]],
      physicalAddressCity: ['', [Validators.required, Validators.maxLength(200), serverValidation()]],
      physicalAddressPostalCode: ['', [Validators.required, Validators.maxLength(10), serverValidation()]],
      physicalAddressProvinceId: ['', [Validators.required, serverValidation()]],
      physicalAddressCountryId: ['', [Validators.required, serverValidation()]],
      postalAddressId: ['', [serverValidation()]],
      postalAddressLine1: ['', [Validators.required, Validators.maxLength(200), serverValidation()]],
      postalAddressLine2: ['', [serverValidation()]],
      postalAddressSuburb: ['', [Validators.required, Validators.maxLength(200), serverValidation()]],
      postalAddressCity: ['', [Validators.required, Validators.maxLength(200), serverValidation()]],
      postalAddressPostalCode: ['', [Validators.required, Validators.maxLength(10), serverValidation()]],
      postalAddressProvinceId: ['', [Validators.required, serverValidation()]],
      postalAddressCountryId: ['', [Validators.required, serverValidation()]],
      faxNumber: ['', [serverValidation()]],
      emailAddress: ['', [Validators.required, Validators.maxLength(500), serverValidation()]],
      contactNumber: ['', [Validators.required, Validators.maxLength(20), serverValidation()]]
    });

    this.logo = {
      logoUrl: '',
      logoFilename: ''
    };
    this.isSubmited = false;
    this.initialiseForm();
  }

  initialiseForm() {
    if (!this.companyDetailsService.Company) {
      return;
    }

    this.heading = 'Edit Company';
    this.logo = {
      logoUrl: this.companyDetailsService.Company.logoFileNamePath,
      logoFilename: this.companyDetailsService.Company.logoFileName
    };

    this.companyForm.patchValue(this.companyDetailsService.Company);
  }

  isControlInvalid(control: FormControl): boolean {
    return FormHelper.isErrorState(control, this.isSubmited);
  }

  save() {
    if (this.companyForm.invalid) {
      this.isSubmited = false;
      return;
    }

    this.isSubmited = false;
    this.isInProgress = true;

    const companyModel: CompanyModel = Object.assign(Object.create(null), this.companyForm.getRawValue());

    companyModel.logoFileName = this.logo.logoFilename;

    this.companyDetailsService.saveCompany(companyModel).pipe(
      finalize(() => {
        this.isInProgress = false;
      })
    ).subscribe((data: CompanyModel) => {
    });
  }

  isPostalSameAsPhysicalAddress(event: MatCheckboxChange) {
    this.postSameAsPhyAddress = event.checked;

    if (!event.checked) {
      return;
    }

    this.companyForm.get('postalAddressId').setValue(this.companyForm.get('physicalAddressId').value);
    this.companyForm.get('postalAddressLine1').setValue(this.companyForm.get('physicalAddressLine1').value);
    this.companyForm.get('postalAddressLine2').setValue(this.companyForm.get('physicalAddressLine2').value);
    this.companyForm.get('postalAddressSuburb').setValue(this.companyForm.get('physicalAddressSuburb').value);
    this.companyForm.get('postalAddressCity').setValue(this.companyForm.get('physicalAddressCity').value);
    this.companyForm.get('postalAddressPostalCode').setValue(this.companyForm.get('physicalAddressPostalCode').value);
    this.companyForm.get('postalAddressProvinceId').setValue(this.companyForm.get('physicalAddressProvinceId').value);
    this.companyForm.get('postalAddressCountryId').setValue(this.companyForm.get('physicalAddressCountryId').value);
  }

  cancel() {
    this.router.navigate(['/companies', this.organisationDetailsService.Organisation.id]);
  }

  logoChanged(event: logoModel) {
    this.logo = event;
  }
}
