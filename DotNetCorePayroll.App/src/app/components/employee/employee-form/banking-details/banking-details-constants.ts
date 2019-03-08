export class EmployeeBankingConstants {
    static readonly VALIDATION_MESSAGES = {
        bankName: {
            required: 'Bank Name is required.',
            maxlength: 'Bank Name cannot be more than 100 characters.',
            pattern: 'Characters entered for the Bank Name are not allowed.',
            serverValidation: ''
        },
        accountHolderName: {
            required: 'Account Holder Name is required.',
            maxlength: 'Account Holder Name cannot be more than 100 characters.',
            pattern: 'Characters entered for the Account Holder Name are not allowed.',
            serverValidation: ''
        },
        accountType: {
            required: 'Account Type is required.',
            serverValidation: ''
        },
        branchCode: {
            required: 'Branch Code is required.',
            maxlength: 'Branch Code cannot be more than 100 characters.',
            pattern: 'Characters entered for the Branch Code are not allowed.',
            serverValidation: ''
        },
        branchName: {
            required: 'Branch Name is required.',
            maxlength: 'Branch Name cannot be more than 100 characters.',
            pattern: 'Characters entered for the Branch Name are not allowed.',
            serverValidation: ''
        },
        accountNumber: {
            required: 'Account Number is required.',
            maxlength: 'Account Number cannot be more than 100 characters.',
            pattern: 'Characters entered for the Account Number are not allowed.',
            serverValidation: ''
        }
    };
}
