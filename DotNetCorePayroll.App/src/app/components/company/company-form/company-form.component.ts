import { Component, OnInit, } from '@angular/core';
import { logoModel } from '../../../shared/models/logoModel';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { CompanyDetailsService } from '../company-details.service';
import { CompanyModel, OrganisationModel } from '../../../shared/generated';
import { FormHelper } from '../../../shared/utils/form-helper';
import { serverValidation } from '../../../shared/validators/server-side-validator';
import { finalize } from 'rxjs/operators';
import { CompanyConstants } from './company-constants';
import { OrganisationDetailsService } from '../../organisation/organisation-details.service';
import { Router } from '@angular/router';
import { Constants } from '../../../shared/utils/constants';
import { FormFieldValidator } from '../../../shared/utils/form-fields-validator';

@Component({
  selector: 'app-company-form',
  templateUrl: './company-form.component.html',
  styleUrls: ['./company-form.component.scss']
})
export class CompanyFormComponent implements OnInit {
  opened = true;

  navLinks = [
    {
      path: '/organisations',
      label: 'Company Details',
      isActive: true
    }, {
      path: '/company',
      label: 'Contact Details',
      isActive: false
    }, {
      path: '/company',
      label: 'Settings',
      isActive: false
    }];

  apiUrl: String = CompanyConstants.UPLOAD_IMAGE_URL;
  logo: logoModel;

  companyForm: FormGroup;
  companySettingsForm: FormGroup;
  isSubmited: boolean;
  isInProgress: boolean;
  heading: String = 'Create Company';
  organisation: OrganisationModel;
  validationMessages = CompanyConstants.VALIDATION_MESSAGES;
  isCompanyNew = true;

  constructor(private fb: FormBuilder,
    private organisationDetailsService: OrganisationDetailsService,
    private companyDetailsService: CompanyDetailsService,
    private router: Router) {
  }

  ngOnInit() {
    this.organisation = this.organisationDetailsService.Organisation;
    this.createForm();
  }

  createForm() {
    this.companyForm = this.fb.group({
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
      faxNumber: ['', [Validators.pattern(Constants.TELEPHONE_REG_EXP), Validators.maxLength(20), serverValidation()]],
      emailAddress: ['', [Validators.required, Validators.email, Validators.maxLength(500), serverValidation()]],
      // tslint:disable-next-line:max-line-length
      contactNumber: ['', [Validators.required, Validators.pattern(Constants.TELEPHONE_REG_EXP), Validators.maxLength(20), serverValidation()]]
    });

    this.companySettingsForm = this.fb.group({});

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

    this.isCompanyNew = false;
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
      FormFieldValidator.validateAllFormFields(this.companyForm);
      return;
    }

    this.isSubmited = false;
    this.isInProgress = true;

    const companyModel: CompanyModel = Object.assign(Object.create(null), this.companyForm.getRawValue());

    companyModel.logoFileName = this.logo.logoFilename;
    companyModel.paysdlInd = false;
    companyModel.organisationId = this.organisation.id;

    this.companyDetailsService.saveCompany(companyModel).pipe(
      finalize(() => {
        this.isInProgress = false;
      })
    ).subscribe(() => {
    });
  }

  cancel() {
    this.router.navigate(['/companies', this.organisationDetailsService.Organisation.id]);
  }

  logoChanged(event: logoModel) {
    this.logo = event;
  }
}
