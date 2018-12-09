import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { serverValidation } from '../../../shared/validators/server-side-validator';

export class OrganisationConstants {
    static readonly VALIDATION_MESSAGES = {
        name: {
            required: 'Organisation Name is required',
            maxlength: 'Organisation Name cannot be more than 20 characters',
            serverValidation: ''
        },
        description: {
            serverValidation: ''
        },
        physicalAddress:
        {
            line1: {
                required: 'Address is required',
                maxlength: 'Address cannot be more than 200 characters',
                serverValidation: ''
            },
            line2: {
                serverValidation: ''
            },
            suburb: {
                required: 'Suburb is required',
                maxlength: 'Suburb cannot be more than 200 characters',
                serverValidation: ''
            },
            postalCode: {
                required: 'Postal Code is required',
                maxlength: 'Postal Code cannot be more than 10 characters',
                serverValidation: ''
            },
            city: {
                required: 'City is required',
                maxlength: 'City cannot be more than 200 characters',
                serverValidation: ''
            },
            provinceId: {
                required: 'Province is required',
                serverValidation: ''
            },
            countryId: {
                required: 'Country is required',
                serverValidation: ''
            },
        },
        postalAddress: {
            line1: {
                required: 'Postal Address is required',
                maxlength: 'Postal Address cannot be more than 200 characters',
                serverValidation: ''
            },
            line2: {
                serverValidation: ''
            },
            suburb: {
                required: 'Suburb is required',
                maxlength: 'Suburb cannot be more than 200 characters',
                serverValidation: ''
            },
            postalCode: {
                required: 'Postal Code is required',
                maxlength: 'Postal Code cannot be more than 10 characters',
                serverValidation: ''
            },
            city: {
                required: 'City is required',
                maxlength: 'City cannot be more than 200 characters',
                serverValidation: ''
            },
            provinceId: {
                required: 'Province is required',
                serverValidation: ''
            },
            countryId: {
                required: 'Country is required',
                serverValidation: ''
            },
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

    static readonly ADDRESS_FORM_FIELDS = {
        id: ['', [serverValidation()]],
        line1: ['', [Validators.required, Validators.maxLength(200), serverValidation()]],
        line2: ['', [serverValidation()]],
        suburb: ['', [Validators.required, Validators.maxLength(200), serverValidation()]],
        city: ['', [Validators.required, Validators.maxLength(200), serverValidation()]],
        postalCode: ['', [Validators.required, Validators.maxLength(10), serverValidation()]],
        provinceId: ['', [Validators.required, serverValidation()]],
        countryId: ['', [Validators.required, serverValidation()]],
    };

    static readonly FORM_FIELDS = {
        id: [null, []],
        name: ['', [Validators.required, Validators.maxLength(20), serverValidation()]],
        description: ['', [serverValidation()]],
        faxNumber: ['', [serverValidation()]],
        emailAddress: ['', [Validators.required, Validators.maxLength(500), serverValidation()]],
        contactNumber: ['', [Validators.required, Validators.maxLength(20), serverValidation()]]
    };

    static readonly UPLOAD_IMAGE_URL: String = 'http://localhost:58308/api/Organisation/SaveImage';

    static getForm(fb: FormBuilder) {

        const form: FormGroup = fb.group({
            id: [null, []],
            name: ['', [Validators.required, Validators.maxLength(20), serverValidation()]],
            description: ['', [serverValidation()]],
            faxNumber: ['', [serverValidation()]],
            emailAddress: ['', [Validators.required, Validators.maxLength(500), serverValidation()]],
            contactNumber: ['', [Validators.required, Validators.maxLength(20), serverValidation()]],
            postalAddress:
                fb.group({
                    id: ['', [serverValidation()]],
                    line1: ['', [Validators.required, Validators.maxLength(200), serverValidation()]],
                    line2: ['', [serverValidation()]],
                    suburb: ['', [Validators.required, Validators.maxLength(200), serverValidation()]],
                    city: ['', [Validators.required, Validators.maxLength(200), serverValidation()]],
                    postalCode: ['', [Validators.required, Validators.maxLength(10), serverValidation()]],
                    provinceId: ['', [Validators.required, serverValidation()]],
                    countryId: ['', [Validators.required, serverValidation()]],
                }),
            physicalAddress:
                fb.group({
                    id: ['', [serverValidation()]],
                    line1: ['', [Validators.required, Validators.maxLength(200), serverValidation()]],
                    line2: ['', [serverValidation()]],
                    suburb: ['', [Validators.required, Validators.maxLength(200), serverValidation()]],
                    city: ['', [Validators.required, Validators.maxLength(200), serverValidation()]],
                    postalCode: ['', [Validators.required, Validators.maxLength(10), serverValidation()]],
                    provinceId: ['', [Validators.required, serverValidation()]],
                    countryId: ['', [Validators.required, serverValidation()]],
                })
        });

        return form;
    }
}
