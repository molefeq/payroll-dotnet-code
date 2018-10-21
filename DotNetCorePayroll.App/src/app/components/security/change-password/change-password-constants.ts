import { Validators } from "@angular/forms";
import { serverValidation } from "../../../shared/validators/server-side-validator";


export class ChangePasswordConstants {
    static readonly VALIDATION_MESSAGES = {
        oldPassword: {
            required: 'Old Password is required.',
            maxlength: 'Old Password cannot not be more than 100 characters.',
            serverValidation: ''
        },
        newPassword: {
            required: 'New Password is required.',
            maxlength: 'New Password cannot not be more than 100 characters.',
            serverValidation: ''
        },
        confirmNewPassword: {
            required: 'Confirm New Password is required.',
            maxlength: 'Confirm New Password cannot not be more than 100 characters.',
            serverValidation: ''
        }
    };

    static readonly FORM_FIELDS = {
        username: ['', []],
        oldPassword: ['', [Validators.required, Validators.maxLength(100), serverValidation()]],
        newPassword: ['', [Validators.required, Validators.maxLength(100), serverValidation()]],
        confirmNewPassword: ['', [Validators.required, Validators.maxLength(100)]]
    };
}
