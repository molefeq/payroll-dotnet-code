export class CompanyConstants {
    static readonly VALIDATION_MESSAGES = {
        name: {
            required: 'Company Name is required',
            maxlength: 'Company Name cannot be more than 200 characters.',
            pattern: 'Characters entered for the Company Name are not allowed.',
            serverValidation: ''
        },
        registeredName: {
            maxlength: 'Registered Name cannot be more than 100 characters.',
            pattern: 'Characters entered for the Registered Name are not allowed.',
            serverValidation: ''
        },
        tradingName: {
            maxlength: 'Trading/Other Name cannot be more than 100 characters.',
            pattern: 'Characters entered for the Trading/Other Name are not allowed.',
            serverValidation: ''
        },
        natureOfBusiness: {
            serverValidation: ''
        },
        companyRegistrationNumber: {
            maxlength: 'Registration Number cannot be more than 100 characters.',
            pattern: 'Characters entered for the Registration Number are not allowed.',
            serverValidation: ''
        },
        taxNumber: {
            required: 'Tax Number is required.',
            maxlength: 'Tax Number cannot be more than 50 characters.',
            pattern: 'Characters entered for the Tax Number are not allowed.',
            serverValidation: ''
        },
        vatNumber: {
            maxlength: 'VAT Number cannot be more than 50 characters.',
            pattern: 'Characters entered for the VAT Reference Number are not allowed.',
            serverValidation: ''
        },
        payeReferenceNumber: {
            required: 'PAYE Reference Number is required.',
            maxlength: 'PAYE Reference Number cannot be more than 50 characters.',
            pattern: 'Characters entered for the PAYE Reference Number are not allowed.',
            serverValidation: ''
        },
        uifCompanyReferenceNumber: {
            required: 'UIF Company Registration Number is required.',
            maxlength: 'UIF Company Registration Number cannot be more than 50 characters.',
            pattern: 'Characters entered for the UIF Company Registration Number are not allowed.',
            serverValidation: ''
        },
        sarsUifNumber: {
            required: 'SARS UIF Number is required.',
            maxlength: 'SARS UIF Number cannot be more than 50 characters.',
            pattern: 'Characters entered for the SARS UIF Number are not allowed.',
            serverValidation: ''
        },
        paysdlInd: {
            serverValidation: ''
        },
        sdlReferenceNumber: {
            maxlength: 'SDL Reference Number cannot be more than 50 characters.',
            pattern: 'Characters entered for the SDL Reference Number are not allowed.',
            serverValidation: ''
        },
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
            maxlength: 'City cannot be more than 100 characters.',
            pattern: '"Characters entered for the City are not allowed.',
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

    static readonly UPLOAD_IMAGE_URL: String = 'http://localhost:58308/api/Company/SaveImage';
}
