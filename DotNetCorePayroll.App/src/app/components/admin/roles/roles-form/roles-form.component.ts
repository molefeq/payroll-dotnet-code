import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { serverValidation } from '../../../../shared/validators/server-side-validator';
import { FormHelper } from '../../../../shared/utils/form-helper';
import { RoleModel } from '../../../../shared/generated';
import { finalize } from 'rxjs/operators';
import { AdminRoleService } from '../admin-role.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormFieldValidator } from '../../../../shared/utils/form-fields-validator';

@Component({
  selector: 'app-roles-form',
  templateUrl: './roles-form.component.html',
  styleUrls: ['./roles-form.component.scss']
})
export class RolesFormComponent implements OnInit {

  roleForm: FormGroup;
  isSubmited: boolean;
  isInProgress: boolean;

  validationMessages = {
    name: {
      required: 'Role Name is required',
      maxlength: 'Role Name cannot be more than 20 characters',
      serverValidation: ''
    },
    code: {
      required: 'Role Code is required',
      minlength: 'Role Code cannot be less than 3 characters',
      maxlength: 'Role Name cannot be more than 10 characters',
      serverValidation: ''
    }
  };

  constructor(private fb: FormBuilder, private adminRoleService: AdminRoleService,
    public dialogRef: MatDialogRef<RolesFormComponent>, @Inject(MAT_DIALOG_DATA) public data: RoleModel) { }

  ngOnInit() {
    this.createForm();
  }

  createForm() {
    this.roleForm = this.fb.group({
      id: [null, []],
      name: ['', [Validators.required, Validators.maxLength(20), serverValidation()]],
      code: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(10), serverValidation()]],
    });

    this.isSubmited = false;
    this.initialiseForm();
  }

  initialiseForm() {
    if (!this.data) {
      return;
    }

    this.roleForm.get('id').setValue(this.data.id);
    this.roleForm.get('name').setValue(this.data.name);
    this.roleForm.get('code').setValue(this.data.code);
  }

  isControlInvalid(control: FormControl): boolean {
    return FormHelper.isErrorState(control, this.isSubmited);
  }

  saveRole() {
    this.isSubmited = true;

    if (this.roleForm.invalid) {
      this.isSubmited = false;
      FormFieldValidator.validateAllFormFields(this.roleForm);
      return;
    }

    this.isSubmited = false;
    this.isInProgress = true;

    const roleModel: RoleModel = {
      id: this.roleForm.get('id').value,
      name: this.roleForm.get('name').value,
      code: this.roleForm.get('code').value,
    }

    this.adminRoleService.saveRole(roleModel).pipe(
      finalize(() => {
        this.isInProgress = false;
      })
    ).subscribe((data: RoleModel) => {
      this.dialogRef.close({
        dataSaved: true
      })
    });

  }
}
