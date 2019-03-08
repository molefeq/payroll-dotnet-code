export class EmployeeAddressFormConstants {
    static readonly VALIDATION_MESSAGES = {
        physicalAddressLine1: {
            required: 'Physical Address Line 1 is required.',
            maxlength: 'Physical Address Line 1 cannot be more than 100 characters.',
            pattern: 'Characters entered for Address Line 1 are not allowed.',
            serverValidation: ''
        },
        physicalAddressLine2: {
            pattern: 'Characters entered for Physical Address Line 2 are not allowed.',
            maxlength: 'Physical Address Line 2 cannot be more than 100 characters.',
            serverValidation: ''
        },
        physicalAddressSuburb: {
            required: 'Suburb is required.',
            maxlength: 'Suburb cannot be more than 100 characters.',
            pattern: 'Characters entered for the Suburb are not allowed.',
            serverValidation: ''
        },
        physicalAddressPostalCode: {
            required: 'Postal Code is required.',
            maxlength: 'Postal Code cannot be more than 10 characters.',
            pattern: 'Characters entered for the Postal Code are not allowed.',
            serverValidation: ''
        },
        physicalAddressCity: {
            required: 'City is required.',
            maxlength: 'City cannot be more than 100 characters.',
            pattern: 'Characters entered for the City are not allowed.',
            serverValidation: ''
        },
        physicalAddressProvinceId: {
            required: 'Province is required.',
            serverValidation: ''
        },
        physicalAddressCountryId: {
            required: 'Country is required.',
            serverValidation: ''
        },
        postalAddressLine1: {
            maxlength: 'Postal Address Line 1 cannot be more than 100 characters.',
            pattern: 'Characters entered for Address Line 1 are not allowed.',
            serverValidation: ''
        },
        postalAddressLine2: {
            maxlength: 'Postal Address Line 2 cannot be more than 100 characters.',
            pattern: 'Characters entered for Address Line 2 are not allowed.',
            serverValidation: ''
        },
        postalAddressSuburb: {
            required: 'Suburb is required.',
            maxlength: 'Suburb cannot be more than 100 characters.',
            pattern: 'Characters entered for the Suburb are not allowed.',
            serverValidation: ''
        },
        postalAddressPostalCode: {
            maxlength: 'Postal Code cannot be more than 100 characters.',
            pattern: '"Characters entered for the Postal Code are not allowed.',
            serverValidation: ''
        },
        postalAddressCity: {
            required: 'City is required.',
            maxlength: 'City cannot be more than 100 characters.',
            pattern: '"Characters entered for the City are not allowed.',
            serverValidation: ''
        },
        postalAddressProvinceId: {
            required: 'Province is required.',
            serverValidation: ''
        },
        postalAddressCountryId: {
            required: 'Country is required.',
            serverValidation: ''
        }
    };
}
