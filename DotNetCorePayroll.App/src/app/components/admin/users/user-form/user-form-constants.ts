import { Validators } from "@angular/forms";
import { serverValidation } from "../../../../shared/validators/server-side-validator";

export class UserConstants {
    static readonly VALIDATION_MESSAGES = {
        username: {
            required: 'Username is required and empty spaces are not allowed.',
            maxlength: 'Username cannot not be more than 100 characters.',
            serverValidation: ''
        },
        firstname: {
            required: 'Firstname is required.',
            maxlength: 'Firstname cannot not be more than 100 characters.',
            serverValidation: ''
        },
        lastname: {
            required: 'Lastname is required.',
            maxlength: 'Lastname cannot not be more than 100 characters.',
            serverValidation: ''
        },
        emailAddress: {
            required: 'Email Address is required.',
            email: 'Email Address must be a valid email address.',
            maxlength: 'Email Address cannot not be more than 500 characters.',
            serverValidation: ''
        },
        organisationId: {
            required: 'Organisation is required.',
            serverValidation: ''
        },
        companyId: {
            serverValidation: ''
        },
        roleId: {
            required: 'Role is required.',
            serverValidation: ''
        }
    };

    static readonly USER_FORM_FIELDS = {
        id: [null, []],
        username: ['', [Validators.required, Validators.maxLength(100), serverValidation()]],
        firstname: ['', [Validators.required, Validators.maxLength(100), serverValidation()]],
        lastname: ['', [Validators.required, Validators.maxLength(100), serverValidation()]],
        emailAddress: ['', [Validators.required, Validators.email, Validators.maxLength(500), serverValidation()]],
        organisationId: ['', [Validators.required, serverValidation()]],
        companyId: ['', [serverValidation()]],
        roleId: ['', [Validators.required, serverValidation()]],
    };
}
