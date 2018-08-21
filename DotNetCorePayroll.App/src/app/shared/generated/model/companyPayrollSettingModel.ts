/**
 * Zenit Payroll API V1
 * Zenit Payroll Web API written in ASP.NET Core Web API
 *
 * OpenAPI spec version: v1
 * Contact: molefeq@gmail.com
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */


export interface CompanyPayrollSettingModel {
    id?: number;
    companyId?: string;
    monthPeriods?: number;
    hoursPerDay?: number;
    weeklyPeriods?: number;
    hoursPerWeek?: number;
    daysPerMonth?: number;
    payslipMessage?: string;
    crudStatus?: CompanyPayrollSettingModel.CrudStatusEnum;
}
export namespace CompanyPayrollSettingModel {
    export type CrudStatusEnum = 1 | 2 | 3 | 4;
    export const CrudStatusEnum = {
        NUMBER_1: 1 as CrudStatusEnum,
        NUMBER_2: 2 as CrudStatusEnum,
        NUMBER_3: 3 as CrudStatusEnum,
        NUMBER_4: 4 as CrudStatusEnum
    }
}
