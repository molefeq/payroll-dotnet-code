import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { serverValidation } from '../../../../../../src/app/shared/validators/server-side-validator';
import { Constants } from '../../../../../../src/app/shared/utils/constants';
import { FormHelper } from '../../../../../../src/app/shared/utils/form-helper';
import { FormFieldValidator } from '../../../../../../src/app/shared/utils/form-fields-validator';
import { EmployeeBankingConstants } from './banking-details-constants';
import { EmployeeDetailsService } from '../../employee-details.service';

@Component({
  selector: 'app-banking-details',
  templateUrl: './banking-details.component.html',
  styleUrls: ['./banking-details.component.scss']
})
export class BankingDetailsComponent implements OnInit {

  isSubmited: boolean;
  isInProgress: boolean;
  bankingDetailsForm: FormGroup;
  validationMessages = EmployeeBankingConstants.VALIDATION_MESSAGES;

  constructor(private fb: FormBuilder,
    private employeeDetailsService: EmployeeDetailsService,
    private router: Router) { }

  ngOnInit() {
    this.createForm();
  }

  createForm() {

    this.bankingDetailsForm = this.fb.group({
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
    if (!this.employeeDetailsService.Employee) {
      return;
    }

    // this.bankingDetailsForm.patchValue(this.employeeDetailsService.Employee.);
  }

  isControlInvalid(control: FormControl): boolean {
    return FormHelper.isErrorState(control, this.isSubmited);
  }

  save() {
    if (this.bankingDetailsForm.invalid) {
      this.isSubmited = false;
      FormFieldValidator.validateAllFormFields(this.bankingDetailsForm);
      return;
    }

    this.isSubmited = false;
    this.isInProgress = true;

    // tslint:disable-next-line:max-line-length
    /*const companyBankingDetailModel: CompanyBankDetailModel = Object.assign(Object.create(null), this.companyBankingDetailsForm.getRawValue());

    companyBankingDetailModel.companyId = this.companyDetailsService.Company.id;

    this.companyDetailsService.saveBankingDetails(companyBankingDetailModel).pipe(
      finalize(() => {
        this.isInProgress = false;
      })
    ).subscribe((data: CompanyModel) => {
      this.companyDetailsService.Company = data;
      this.initialiseForm();
    });*/
  }

  cancel() {
    this.router.navigate(['/employees', this.employeeDetailsService.Employee.companyId]);
  }

}
