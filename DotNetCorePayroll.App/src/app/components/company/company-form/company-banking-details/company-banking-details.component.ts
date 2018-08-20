import { Component, OnInit } from '@angular/core';
import { CompanyBankingDetailConstants } from './company-banking-details-constants';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { CompanyDetailsService } from '../../company-details.service';
import { OrganisationDetailsService } from '../../../organisation/organisation-details.service';
import { Router } from '@angular/router';
import { serverValidation } from '../../../../shared/validators/server-side-validator';
import { Constants } from '../../../../shared/utils/constants';
import { FormHelper } from '../../../../shared/utils/form-helper';
import { FormFieldValidator } from '../../../../shared/utils/form-fields-validator';
import { CompanyBankDetailModel, CompanyModel } from '../../../../shared/generated';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-company-banking-details',
  templateUrl: './company-banking-details.component.html',
  styleUrls: ['./company-banking-details.component.scss']
})
export class CompanyBankingDetailsComponent implements OnInit {

  isSubmited: boolean;
  isInProgress: boolean;
  companyBankingDetailsForm: FormGroup;
  validationMessages = CompanyBankingDetailConstants.VALIDATION_MESSAGES;

  constructor(private fb: FormBuilder,
    private companyDetailsService: CompanyDetailsService,
    private organisationDetailsService: OrganisationDetailsService,
    private router: Router) { }

  ngOnInit() {
    this.createForm();
  }

  createForm() {

    this.companyBankingDetailsForm = this.fb.group({
      bankId: ['', [serverValidation()]],
      // tslint:disable-next-line:max-line-length
      bankName: ['', [Validators.required, Validators.maxLength(100), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]],
      // tslint:disable-next-line:max-line-length
      accountHolderName: ['', [Validators.required, Validators.maxLength(100), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]],
      // tslint:disable-next-line:max-line-length
      accountType: ['', [Validators.required, serverValidation()]],
      // tslint:disable-next-line:max-line-length
      branchCode: ['', [Validators.required, Validators.maxLength(100), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]],
      // tslint:disable-next-line:max-line-length
      branchName: ['', [Validators.required, Validators.maxLength(100), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]],
      // tslint:disable-next-line:max-line-length
      accountNumber: ['', [Validators.required, Validators.maxLength(100), Validators.pattern(Constants.ALPHA_NUMERIC_REG_EXP), serverValidation()]],
    });

    this.initialiseForm();
  }

  initialiseForm() {
    if (!this.companyDetailsService.Company || !this.companyDetailsService.Company.contactDetails) {
      return;
    }

    this.companyBankingDetailsForm.patchValue(this.companyDetailsService.Company.bankingDetails);
  }

  isControlInvalid(control: FormControl): boolean {
    return FormHelper.isErrorState(control, this.isSubmited);
  }

  save() {
    if (this.companyBankingDetailsForm.invalid) {
      this.isSubmited = false;
      FormFieldValidator.validateAllFormFields(this.companyBankingDetailsForm);
      return;
    }

    this.isSubmited = false;
    this.isInProgress = true;

    // tslint:disable-next-line:max-line-length
    const companyBankingDetailModel: CompanyBankDetailModel = Object.assign(Object.create(null), this.companyBankingDetailsForm.getRawValue());

    companyBankingDetailModel.companyId = this.companyDetailsService.Company.id;

    this.companyDetailsService.saveBankingDetails(companyBankingDetailModel).pipe(
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
