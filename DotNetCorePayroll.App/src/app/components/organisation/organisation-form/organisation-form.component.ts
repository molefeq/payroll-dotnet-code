import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { OrganisationDetailsService } from '../organisation-details.service';
import { OrganisationModel, ReferenceDataModel } from '../../../shared/generated';
import { FormHelper } from '../../../shared/utils/form-helper';
import { finalize } from 'rxjs/operators';
import { AppReferenceDataService } from '../../../shared/services/app-reference-data-service';
import { logoModel } from '../../../shared/models/logoModel';
import { MatCheckboxChange } from '../../../../../node_modules/@angular/material';
import { OrganisationConstants } from './organisation-constants';
import { FormFieldValidator } from '../../../shared/utils/form-fields-validator';
import { Router } from '../../../../../node_modules/@angular/router';

@Component({
  selector: 'app-organisation-form',
  templateUrl: './organisation-form.component.html',
  styleUrls: ['./organisation-form.component.scss']
})
export class OrganisationFormComponent implements OnInit {

  apiUrl = OrganisationConstants.UPLOAD_IMAGE_URL;
  logo: logoModel;

  organisationForm: FormGroup;
  isSubmited: boolean;
  isInProgress: boolean;
  countries: Array<ReferenceDataModel>;
  provinces: Array<ReferenceDataModel>;
  postSameAsPhyAddress = false;
  heading: String = 'Create Organisation';

  validationMessages = OrganisationConstants.VALIDATION_MESSAGES;

  constructor(private fb: FormBuilder,
    private organisationDetailsService: OrganisationDetailsService,
    private referenceDataService: AppReferenceDataService,
    private router: Router) {
  }

  ngOnInit() {
    this.createForm();
    this.countries = this.referenceDataService.getCountries();
    this.provinces = this.referenceDataService.getProvinces();
  }

  createForm() {
    this.organisationForm = OrganisationConstants.getForm(this.fb);

    this.logo = {
      logoUrl: '',
      logoFilename: ''
    };
    this.isSubmited = false;
    this.initialiseForm();
  }

  initialiseForm() {
    if (!this.organisationDetailsService.Organisation) {
      return;
    }

    this.heading = 'Edit Organisation';

    this.logo = {
      logoUrl: this.organisationDetailsService.Organisation.logoFileNamePath,
      logoFilename: this.organisationDetailsService.Organisation.logoFileName
    };

    this.organisationForm.patchValue(this.organisationDetailsService.Organisation);
  }

  isControlInvalid(control: FormControl): boolean {
    return FormHelper.isErrorState(control, this.isSubmited);
  }

  saveOrganisation() {

    if (this.organisationForm.invalid) {
      this.isSubmited = false;
      FormFieldValidator.validateAllFormFields(this.organisationForm);
      return;
    }

    this.isSubmited = true;
    this.isInProgress = true;
    const organisationModel: OrganisationModel = Object.assign(Object.create(null), this.organisationForm.getRawValue());

    organisationModel.logoFileName = this.logo.logoFilename;

    this.organisationDetailsService.saveOrganisation(organisationModel).pipe(
      finalize(() => {
        this.isInProgress = false;
      })
    ).subscribe((data: OrganisationModel) => {

    });
  }

  cancel() {
    this.router.navigate(['/organisations']);
  }

  isPostalSameAsPhysicalAddress(event: MatCheckboxChange) {
    this.postSameAsPhyAddress = event.checked;

    if (!event.checked) {
      return;
    }

    this.organisationForm.get('postalAddress')
      .setValue(Object.assign(Object.create(null), this.organisationForm.get('physicalAddress').value));
  }

  logoChanged(event: logoModel) {
    this.logo = event;
  }
}
