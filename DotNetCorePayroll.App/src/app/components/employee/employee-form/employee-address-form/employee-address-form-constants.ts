export class EmployeeAddressFormConstants {
    static readonly UPLOAD_IMAGE_URL = '';

    static readonly VALIDATION_MESSAGES = {
        employeeNumber: {
            required: 'Employee Number is required.',
            maxlength: 'Employee Number cannot be more than 20 characters.',
            pattern: 'Characters entered for the Employee Number are not allowed.',
            serverValidation: ''
        },
        title: {
            serverValidation: ''
        },
        firstName: {
            required: 'First Name(s) is required.',
            maxlength: 'First Name(s) cannot be more than 200 characters.',
            pattern: 'Characters entered for the First Name(s) are not allowed.',
            serverValidation: ''
        },
        initials: {
            required: 'Initials are required.',
            maxlength: 'Initials cannot be more than 20 characters.',
            pattern: 'Characters entered for the Initials are not allowed.',
            serverValidation: ''
        },
        lastName: {
            required: 'Last Name is required.',
            maxlength: 'Last Name cannot be more than 100 characters.',
            pattern: 'Characters entered for the Last Name are not allowed.',
            serverValidation: ''
        },
        nickName: {
            maxlength: 'Known As cannot be more than 100 characters.',
            required: 'Characters entered for the Known As are not allowed.',
            serverValidation: ''
        },
        dateOfBirth: {
            required: 'Date Of Birth is required.',
            serverValidation: ''
        },
        isSouthAfricanCitizen: {
            serverValidation: ''
        },
        idOrPassportNumber: {
            required: 'ID / Password Number is required.',
            maxlength: 'ID / Password Number cannot be more than 50 characters.',
            pattern: 'Characters entered for the ID / Password Number are not allowed.',
            serverValidation: ''
        },
        ethnicGroup: {
            serverValidation: ''
        },
        gender: {
            serverValidation: ''
        },
        hasDisability: {
            serverValidation: ''
        },
        disabilityDescription: {
            maxlength: 'Specify Disablity cannot be more than 100 characters.',
            pattern: 'Characters entered for the Specify Disablity are not allowed.',
            serverValidation: ''
        },
        maritalStatus: {
            serverValidation: ''
        },
        homeLanguage: {
            serverValidation: ''
        },
        taxReferenceNumber: {
            required: 'Tax Reference Number is required.',
            maxlength: 'Tax Reference Number cannot be more than 50 characters.',
            pattern: 'Characters entered for the Tax Reference Number are not allowed.',
            serverValidation: ''
        },
        emailAddress: {
            required: 'Email Address is required.',
            maxlength: 'Email Address cannot be more than 500 characters.',
            email: 'Invalid Email Address Format.',
            serverValidation: ''
        },
        workNumber: {
            maxlength: 'Work Number cannot be more than 20 characters.',
            pattern: 'Characters entered for the Work Number are not allowed.',
            serverValidation: ''
        },
        homeNumber: {
            maxlength: 'Home Number cannot be more than 20 characters.',
            pattern: 'Characters entered for the Home Number are not allowed.',
            serverValidation: ''
        },
        mobileNumber: {
            required: 'Mobile Number is required.',
            maxlength: 'Mobile Number cannot be more than 20 characters.',
            pattern: 'Characters entered for the Mobile Number are not allowed.',
            serverValidation: ''
        }
    };
}
