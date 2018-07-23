import { Component, OnInit, Inject } from '@angular/core';
import { logoModel } from '../../../shared/models/logoModel';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { CompanyDetailsService } from '../company-details.service';
import { AppReferenceDataService } from '../../../shared/services/app-reference-data-service';
import { MatDialogRef, MAT_DIALOG_DATA, MatCheckboxChange } from '@angular/material';
import { CompanyModel, ReferenceDataModel, OrganisationModel } from '../../../shared/generated';
import { FormHelper } from '../../../shared/utils/form-helper';
import { serverValidation } from '../../../shared/validators/server-side-validator';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-company-form',
  templateUrl: './company-form.component.html',
  styleUrls: ['./company-form.component.scss']
})
export class CompanyFormComponent implements OnInit {

  apiUrl: string = 'http://localhost:58308/api/Company/SaveImage'
  logo: logoModel;

  companyForm: FormGroup;
  isSubmited: boolean;
  isInProgress: boolean;
  heading: String = 'Create Company';
  countries: Array<ReferenceDataModel>;
  provinces: Array<ReferenceDataModel>;
  organisation: OrganisationModel;
  postSameAsPhyAddress: boolean = false;


  validationMessages = {
    name: {
      required: 'Company Name is required',
      maxlength: 'Company Name cannot be more than 20 characters',
      serverValidation: ''
    },
    registeredName: {
      maxlength: 'Registered Name cannot be more than 20 characters',
      serverValidation: ''
    },
    tradingName: {
      maxlength: 'Trading Name cannot be more than 20 characters',
      serverValidation: ''
    },
    natureOfBusiness: {
      serverValidation: ''
    },
    companyRegistrationNumber: {
      maxlength: 'Registration Number cannot be more than 20 characters',
      serverValidation: ''
    },
    taxNumber: {
      maxlength: 'Tax Number cannot be more than 20 characters',
      serverValidation: ''
    },
    uifReferenceNumber: {
      maxlength: 'UIF Reference Number cannot be more than 20 characters',
      serverValidation: ''
    },
    payeReferenceNumber: {
      maxlength: 'PAYE Reference Number cannot be more than 20 characters',
      serverValidation: ''
    },
    uifCompanyReferenceNumber: {
      maxlength: 'UIF Company Reference Number cannot be more than 20 characters',
      serverValidation: ''
    },
    sarsUifNumber: {
      maxlength: 'SARS UIF Number cannot be more than 20 characters',
      serverValidation: ''
    },
    paysdlInd: {
      serverValidation: ''
    },
    physicalAddressLine1: {
      required: 'Address is required',
      maxlength: 'Address cannot be more than 200 characters',
      serverValidation: ''
    },
    physicalAddressLine2: {
      serverValidation: ''
    },
    physicalAddressSuburb: {
      required: 'Suburb is required',
      maxlength: 'Suburb cannot be more than 200 characters',
      serverValidation: ''
    },
    physicalAddressPostalCode: {
      required: 'Postal Code is required',
      maxlength: 'Postal Code cannot be more than 10 characters',
      serverValidation: ''
    },
    physicalAddressCity: {
      required: 'City is required',
      maxlength: 'City cannot be more than 200 characters',
      serverValidation: ''
    },
    physicalAddressProvinceId: {
      required: 'Province is required',
      serverValidation: ''
    },
    physicalAddressCountryId: {
      required: 'Country is required',
      serverValidation: ''
    },
    postalAddressLine1: {
      required: 'Postal Address is required',
      maxlength: 'Postal Address cannot be more than 200 characters',
      serverValidation: ''
    },
    postalAddressLine2: {
      serverValidation: ''
    },
    postalAddressSuburb: {
      required: 'Suburb is required',
      maxlength: 'Suburb cannot be more than 200 characters',
      serverValidation: ''
    },
    postalAddressPostalCode: {
      required: 'Postal Code is required',
      maxlength: 'Postal Code cannot be more than 10 characters',
      serverValidation: ''
    },
    postalAddressCity: {
      required: 'City is required',
      maxlength: 'City cannot be more than 200 characters',
      serverValidation: ''
    },
    postalAddressProvinceId: {
      required: 'Province is required',
      serverValidation: ''
    },
    postalAddressCountryId: {
      required: 'Country is required',
      serverValidation: ''
    },
    faxNumber: {
      serverValidation: ''
    },
    emailAddress: {
      required: 'Email is required',
      maxlength: 'Email cannot be more than 500 characters',
      serverValidation: ''
    },
    contactNumber: {
      required: 'Contact is required',
      maxlength: 'Contact cannot be more than 20 characters',
      serverValidation: ''
    }
  };

  constructor(private fb: FormBuilder, private companyDetailsService: CompanyDetailsService, private referenceDataService: AppReferenceDataService,
    public dialogRef: MatDialogRef<CompanyFormComponent>, @Inject(MAT_DIALOG_DATA) public data: CompanyModel) {
  }

  ngOnInit() {
    this.createForm();
    this.organisation = JSON.parse(sessionStorage.getItem('organisation'));
    this.countries = this.referenceDataService.getCountries();
    this.provinces = this.referenceDataService.getProvinces();
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
    if (!this.data) {
      return;
    }

    this.heading = 'Edit Company';
    this.logo = {
      logoUrl: this.data.logoFileNamePath,
      logoFilename: this.data.logoFileName
    };

    this.companyForm.get('id').setValue(this.data.id);
    this.companyForm.get('name').setValue(this.data.name);
    this.companyForm.get('registeredName').setValue(this.data.registeredName);
    this.companyForm.get('tradingName').setValue(this.data.tradingName);
    this.companyForm.get('natureOfBusiness').setValue(this.data.natureOfBusiness);
    this.companyForm.get('companyRegistrationNumber').setValue(this.data.companyRegistrationNumber);
    this.companyForm.get('taxNumber').setValue(this.data.taxNumber);
    this.companyForm.get('uifReferenceNumber').setValue(this.data.uifReferenceNumber);
    this.companyForm.get('payeReferenceNumber').setValue(this.data.payeReferenceNumber);
    this.companyForm.get('uifCompanyReferenceNumber').setValue(this.data.uifCompanyReferenceNumber);
    this.companyForm.get('sarsUifNumber').setValue(this.data.sarsUifNumber);
    this.companyForm.get('paysdlInd').setValue(this.data.paysdlInd);

    this.companyForm.get('physicalAddressId').setValue(this.data.physicalAddressId);
    this.companyForm.get('physicalAddressLine1').setValue(this.data.physicalAddressLine1);
    this.companyForm.get('physicalAddressLine2').setValue(this.data.physicalAddressLine2);
    this.companyForm.get('physicalAddressSuburb').setValue(this.data.physicalAddressSuburb);
    this.companyForm.get('physicalAddressCity').setValue(this.data.physicalAddressCity);
    this.companyForm.get('physicalAddressPostalCode').setValue(this.data.physicalAddressPostalCode);
    this.companyForm.get('physicalAddressProvinceId').setValue(this.data.physicalAddressProvinceId);
    this.companyForm.get('physicalAddressCountryId').setValue(this.data.physicalAddressCountryId);

    this.companyForm.get('postalAddressId').setValue(this.data.postalAddressId);
    this.companyForm.get('postalAddressLine1').setValue(this.data.postalAddressLine1);
    this.companyForm.get('postalAddressLine2').setValue(this.data.postalAddressLine2);
    this.companyForm.get('postalAddressSuburb').setValue(this.data.postalAddressSuburb);
    this.companyForm.get('postalAddressCity').setValue(this.data.postalAddressCity);
    this.companyForm.get('postalAddressPostalCode').setValue(this.data.postalAddressPostalCode);
    this.companyForm.get('postalAddressProvinceId').setValue(this.data.postalAddressProvinceId);
    this.companyForm.get('postalAddressCountryId').setValue(this.data.postalAddressCountryId);

    this.companyForm.get('faxNumber').setValue(this.data.faxNumber);
    this.companyForm.get('emailAddress').setValue(this.data.emailAddress);
    this.companyForm.get('contactNumber').setValue(this.data.contactNumber);
  }


  isControlInvalid(control: FormControl): boolean {
    return FormHelper.isErrorState(control, this.isSubmited);
  }

  save() {
    this.isSubmited = true;

    if (this.companyForm.invalid) {
      this.isSubmited = false;
      return;
    }

    this.isSubmited = false;
    this.isInProgress = true;

    const companyModel: CompanyModel = {
      id: this.companyForm.get('id').value,
      // organisationId: this.organisation.id,
      name: this.companyForm.get('name').value,
      registeredName: this.companyForm.get('registeredName').value,
      tradingName: this.companyForm.get('tradingName').value,
      natureOfBusiness: this.companyForm.get('natureOfBusiness').value,
      companyRegistrationNumber: this.companyForm.get('companyRegistrationNumber').value,
      taxNumber: this.companyForm.get('taxNumber').value,
      uifReferenceNumber: this.companyForm.get('uifReferenceNumber').value,
      payeReferenceNumber: this.companyForm.get('payeReferenceNumber').value,
      uifCompanyReferenceNumber: this.companyForm.get('uifCompanyReferenceNumber').value,
      sarsUifNumber: this.companyForm.get('sarsUifNumber').value,
      paysdlInd: this.companyForm.get('paysdlInd').value,
      physicalAddressId: this.companyForm.get('physicalAddressId').value,
      physicalAddressLine1: this.companyForm.get('physicalAddressLine1').value,
      physicalAddressLine2: this.companyForm.get('physicalAddressLine2').value,
      physicalAddressSuburb: this.companyForm.get('physicalAddressSuburb').value,
      physicalAddressCity: this.companyForm.get('physicalAddressCity').value,
      physicalAddressPostalCode: this.companyForm.get('physicalAddressPostalCode').value,
      physicalAddressProvinceId: this.companyForm.get('physicalAddressProvinceId').value,
      physicalAddressCountryId: this.companyForm.get('physicalAddressCountryId').value,
      postalAddressId: this.companyForm.get('postalAddressId').value,
      postalAddressLine1: this.companyForm.get('postalAddressLine1').value,
      postalAddressLine2: this.companyForm.get('postalAddressLine2').value,
      postalAddressSuburb: this.companyForm.get('postalAddressSuburb').value,
      postalAddressCity: this.companyForm.get('postalAddressCity').value,
      postalAddressPostalCode: this.companyForm.get('postalAddressPostalCode').value,
      postalAddressProvinceId: this.companyForm.get('postalAddressProvinceId').value,
      postalAddressCountryId: this.companyForm.get('postalAddressCountryId').value,
      faxNumber: this.companyForm.get('faxNumber').value,
      emailAddress: this.companyForm.get('emailAddress').value,
      contactNumber: this.companyForm.get('contactNumber').value,
      logoFileName: this.logo.logoFilename
    };

    this.companyDetailsService.saveCompany(companyModel).pipe(
      finalize(() => {
        this.isInProgress = false;
      })
    ).subscribe((data: CompanyModel) => {
      this.dialogRef.close({
        dataSaved: true
      })
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


  logoChanged(event: logoModel) {
    this.logo = event;
  }
}
