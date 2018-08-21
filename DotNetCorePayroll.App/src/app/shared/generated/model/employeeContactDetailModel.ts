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


export interface EmployeeContactDetailModel {
    employeeId?: string;
    physicalAddressId?: number;
    physicalAddressLine1?: string;
    physicalAddressLine2?: string;
    physicalAddressSuburb?: string;
    physicalAddressCity?: string;
    physicalAddressPostalCode?: string;
    physicalAddressProvinceId?: number;
    physicalAddressCountryId?: number;
    postalAddressId?: number;
    postalAddressLine1?: string;
    postalAddressLine2?: string;
    postalAddressSuburb?: string;
    postalAddressCity?: string;
    postalAddressPostalCode?: string;
    postalAddressProvinceId?: number;
    postalAddressCountryId?: number;
    crudStatus?: EmployeeContactDetailModel.CrudStatusEnum;
}
export namespace EmployeeContactDetailModel {
    export type CrudStatusEnum = 1 | 2 | 3 | 4;
    export const CrudStatusEnum = {
        NUMBER_1: 1 as CrudStatusEnum,
        NUMBER_2: 2 as CrudStatusEnum,
        NUMBER_3: 3 as CrudStatusEnum,
        NUMBER_4: 4 as CrudStatusEnum
    }
}
