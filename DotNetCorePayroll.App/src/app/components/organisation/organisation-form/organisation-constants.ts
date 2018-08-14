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
        physicalAddressLine1: {
            required: 'Address is required',
            maxlength: 'Address cannot be more than 200 characters',
            serverValidation: ''
        },
        physicalAddressLine2: {
            serverValidation: ''
        },
        physicalAddressSuburb: {
            required: 'Suburb is required',
            maxlength: 'Suburb cannot be more than 200 characters',
            serverValidation: ''
        },
        physicalAddressPostalCode: {
            required: 'Postal Code is required',
            maxlength: 'Postal Code cannot be more than 10 characters',
            serverValidation: ''
        },
        physicalAddressCity: {
            required: 'City is required',
            maxlength: 'City cannot be more than 200 characters',
            serverValidation: ''
        },
        physicalAddressProvinceId: {
            required: 'Province is required',
            serverValidation: ''
        },
        physicalAddressCountryId: {
            required: 'Country is required',
            serverValidation: ''
        },
        postalAddressLine1: {
            required: 'Postal Address is required',
            maxlength: 'Postal Address cannot be more than 200 characters',
            serverValidation: ''
        },
        postalAddressLine2: {
            serverValidation: ''
        },
        postalAddressSuburb: {
            required: 'Suburb is required',
            maxlength: 'Suburb cannot be more than 200 characters',
            serverValidation: ''
        },
        postalAddressPostalCode: {
            required: 'Postal Code is required',
            maxlength: 'Postal Code cannot be more than 10 characters',
            serverValidation: ''
        },
        postalAddressCity: {
            required: 'City is required',
            maxlength: 'City cannot be more than 200 characters',
            serverValidation: ''
        },
        postalAddressProvinceId: {
            required: 'Province is required',
            serverValidation: ''
        },
        postalAddressCountryId: {
            required: 'Country is required',
            serverValidation: ''
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

    static readonly UPLOAD_IMAGE_URL: String = 'http://localhost:58308/api/Organisation/SaveImage';
}
