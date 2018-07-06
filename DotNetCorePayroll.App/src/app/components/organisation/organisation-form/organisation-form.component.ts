import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { OrganisationDetailsService } from '../organisation-details.service';
import { MatDialogRef, MAT_DIALOG_DATA, MatCheckboxChange } from '@angular/material';
import { OrganisationModel, ReferenceDataModel } from '../../../shared/generated';
import { serverValidation } from '../../../shared/validators/server-side-validator';
import { FormHelper } from '../../../shared/utils/form-helper';
import { finalize } from 'rxjs/operators';
import { AppReferenceDataService } from '../../../shared/services/app-reference-data-service';
import { logoModel } from '../../../shared/models/logoModel';

@Component({
  selector: 'app-organisation-form',
  templateUrl: './organisation-form.component.html',
  styleUrls: ['./organisation-form.component.scss']
})
export class OrganisationFormComponent implements OnInit {

  apiUrl: string = 'http://localhost:58308/api/Organisation/SaveImage'
  logo: logoModel;

  organisationForm: FormGroup;
  isSubmited: boolean;
  isInProgress: boolean;
  countries: Array<ReferenceDataModel>;
  provinces: Array<ReferenceDataModel>;
  postSameAsPhyAddress: boolean = false;

  validationMessages = {
    name: {
      required: 'Organisation Name is required',
      maxlength: 'Organisation Name cannot be more than 20 characters',
      serverValidation: ''
    },
    description: {
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

  constructor(private fb: FormBuilder, private organisationDetailsService: OrganisationDetailsService, private referenceDataService: AppReferenceDataService,
    public dialogRef: MatDialogRef<OrganisationFormComponent>, @Inject(MAT_DIALOG_DATA) public data: OrganisationModel) {
  }

  ngOnInit() {
    this.createForm();
    this.countries = this.referenceDataService.getCountries();
    this.provinces = this.referenceDataService.getProvinces();
  }

  createForm() {
    this.organisationForm = this.fb.group({
      id: [null, []],
      name: ['', [Validators.required, Validators.maxLength(20), serverValidation()]],
      description: ['', [serverValidation()]],
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

    this.isSubmited = false;
    this.initialiseForm();
  }

  initialiseForm() {
    if (!this.data) {
      return;
    }

    this.logo = {
      logoUrl: this.data.logoFileNamePath,
      logoFilename: this.data.logoFileName
    };
    this.organisationForm.get('id').setValue(this.data.id);
    this.organisationForm.get('name').setValue(this.data.name);
    this.organisationForm.get('description').setValue(this.data.description);

    this.organisationForm.get('physicalAddressId').setValue(this.data.physicalAddressId);
    this.organisationForm.get('physicalAddressLine1').setValue(this.data.physicalAddressLine1);
    this.organisationForm.get('physicalAddressLine2').setValue(this.data.physicalAddressLine2);
    this.organisationForm.get('physicalAddressSuburb').setValue(this.data.physicalAddressSuburb);
    this.organisationForm.get('physicalAddressCity').setValue(this.data.physicalAddressCity);
    this.organisationForm.get('physicalAddressPostalCode').setValue(this.data.physicalAddressPostalCode);
    this.organisationForm.get('physicalAddressProvinceId').setValue(this.data.physicalAddressProvinceId);
    this.organisationForm.get('physicalAddressCountryId').setValue(this.data.physicalAddressCountryId);

    this.organisationForm.get('postalAddressId').setValue(this.data.postalAddressId);
    this.organisationForm.get('postalAddressLine1').setValue(this.data.postalAddressLine1);
    this.organisationForm.get('postalAddressLine2').setValue(this.data.postalAddressLine2);
    this.organisationForm.get('postalAddressSuburb').setValue(this.data.postalAddressSuburb);
    this.organisationForm.get('postalAddressCity').setValue(this.data.postalAddressCity);
    this.organisationForm.get('postalAddressPostalCode').setValue(this.data.postalAddressPostalCode);
    this.organisationForm.get('postalAddressProvinceId').setValue(this.data.postalAddressProvinceId);
    this.organisationForm.get('postalAddressCountryId').setValue(this.data.postalAddressCountryId);

    this.organisationForm.get('faxNumber').setValue(this.data.faxNumber);
    this.organisationForm.get('emailAddress').setValue(this.data.emailAddress);
    this.organisationForm.get('contactNumber').setValue(this.data.contactNumber);
  }

  isControlInvalid(control: FormControl): boolean {
    return FormHelper.isErrorState(control, this.isSubmited);
  }

  saveOrganisation() {
    this.isSubmited = true;

    if (this.organisationForm.invalid) {
      this.isSubmited = false;
      return;
    }

    this.isSubmited = false;
    this.isInProgress = true;

    const organisationModel: OrganisationModel = {
      id: this.organisationForm.get('id').value,
      name: this.organisationForm.get('name').value,
      description: this.organisationForm.get('description').value,
      physicalAddressId: this.organisationForm.get('physicalAddressId').value,
      physicalAddressLine1: this.organisationForm.get('physicalAddressLine1').value,
      physicalAddressLine2: this.organisationForm.get('physicalAddressLine2').value,
      physicalAddressSuburb: this.organisationForm.get('physicalAddressSuburb').value,
      physicalAddressCity: this.organisationForm.get('physicalAddressCity').value,
      physicalAddressPostalCode: this.organisationForm.get('physicalAddressPostalCode').value,
      physicalAddressProvinceId: this.organisationForm.get('physicalAddressProvinceId').value,
      physicalAddressCountryId: this.organisationForm.get('physicalAddressCountryId').value,
      postalAddressId: this.organisationForm.get('postalAddressId').value,
      postalAddressLine1: this.organisationForm.get('postalAddressLine1').value,
      postalAddressLine2: this.organisationForm.get('postalAddressLine2').value,
      postalAddressSuburb: this.organisationForm.get('postalAddressSuburb').value,
      postalAddressCity: this.organisationForm.get('postalAddressCity').value,
      postalAddressPostalCode: this.organisationForm.get('postalAddressPostalCode').value,
      postalAddressProvinceId: this.organisationForm.get('postalAddressProvinceId').value,
      postalAddressCountryId: this.organisationForm.get('postalAddressCountryId').value,
      faxNumber: this.organisationForm.get('faxNumber').value,
      emailAddress: this.organisationForm.get('emailAddress').value,
      contactNumber: this.organisationForm.get('contactNumber').value,
      logoFileName: this.logo.logoFilename
    }

    this.organisationDetailsService.saveOrganisation(organisationModel).pipe(
      finalize(() => {
        this.isInProgress = false;
      })
    ).subscribe((data: OrganisationModel) => {
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

    this.organisationForm.get('postalAddressId').setValue(this.organisationForm.get('physicalAddressId').value);
    this.organisationForm.get('postalAddressLine1').setValue(this.organisationForm.get('physicalAddressLine1').value);
    this.organisationForm.get('postalAddressLine2').setValue(this.organisationForm.get('physicalAddressLine2').value);
    this.organisationForm.get('postalAddressSuburb').setValue(this.organisationForm.get('physicalAddressSuburb').value);
    this.organisationForm.get('postalAddressCity').setValue(this.organisationForm.get('physicalAddressCity').value);
    this.organisationForm.get('postalAddressPostalCode').setValue(this.organisationForm.get('physicalAddressPostalCode').value);
    this.organisationForm.get('postalAddressProvinceId').setValue(this.organisationForm.get('physicalAddressProvinceId').value);
    this.organisationForm.get('postalAddressCountryId').setValue(this.organisationForm.get('physicalAddressCountryId').value);
  }

  logoChanged(event: logoModel) {
    this.logo = event;
  }
}
