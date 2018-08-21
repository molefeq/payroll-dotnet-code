export class CompanyPayrollSettingConstants {
    static readonly VALIDATION_MESSAGES = {
        monthPeriods: {
            pattern: 'Characters entered for Month Periods are not allowed.',
            serverValidation: ''
        },
        weeklyPeriods: {
            pattern: 'Characters entered for Weekly Periods are not allowed.',
            serverValidation: ''
        },
        hoursPerDay: {
            pattern: 'Characters entered for the Hours Per Day are not allowed.',
            serverValidation: ''
        },
        hoursPerWeek: {
            pattern: 'Characters entered for the Hours Per Week are not allowed.',
            serverValidation: ''
        },
        daysPerMonth: {
            required: 'Days Per Month is required.',
            pattern: 'Characters entered for the Days Per Month are not allowed.',
            serverValidation: ''
        }
    };
}
