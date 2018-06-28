import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { OrganisationDetailsService } from '../organisation-details.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { OrganisationModel } from '../../../shared/generated';
import { serverValidation } from '../../../shared/validators/server-side-validator';
import { FormHelper } from '../../../shared/utils/form-helper';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-organisation-form',
  templateUrl: './organisation-form.component.html',
  styleUrls: ['./organisation-form.component.scss']
})
export class OrganisationFormComponent implements OnInit {

  organisationForm: FormGroup;
  isSubmited: boolean;
  isInProgress: boolean;

  validationMessages = {
    name: {
      required: 'Organisation Name is required',
      maxlength: 'Organisation Name cannot be more than 20 characters',
      serverValidation: ''
    }
  };

  constructor(private fb: FormBuilder, private organisationDetailsService: OrganisationDetailsService,
    public dialogRef: MatDialogRef<OrganisationFormComponent>, @Inject(MAT_DIALOG_DATA) public data: OrganisationModel) { }

  ngOnInit() {
    this.createForm();
  }

  createForm() {
    this.organisationForm = this.fb.group({
      id: [null, []],
      name: ['', [Validators.required, Validators.maxLength(20), serverValidation()]],
    });

    this.isSubmited = false;
    this.initialiseForm();
  }

  initialiseForm() {
    if (!this.data) {
      return;
    }

    this.organisationForm.get('id').setValue(this.data.id);
    this.organisationForm.get('name').setValue(this.data.name);
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
}
