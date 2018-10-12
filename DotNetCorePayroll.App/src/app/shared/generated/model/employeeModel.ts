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
import { EmployeeBankDetailModel } from './employeeBankDetailModel';
import { EmployeeContactDetailModel } from './employeeContactDetailModel';
import { EmployeeNextOfKinDetailModel } from './employeeNextOfKinDetailModel';


export interface EmployeeModel {
    id?: string;
    companyId?: string;
    employeeNumber?: string;
    title?: string;
    firstName?: string;
    initials?: string;
    lastName?: string;
    nickName?: string;
    dateOfBirth?: Date;
    isSouthAfricanCitizen?: boolean;
    ethnicGroup?: string;
    gender?: string;
    hasDisability?: boolean;
    disabilityDescription?: string;
    maritalStatus?: string;
    homeLanguage?: string;
    taxReferenceNumber?: string;
    imageFileName?: string;
    imageFileNamePath?: string;
    statusId?: number;
    statusName?: string;
    isSystemUser?: boolean;
    emailAddress?: string;
    workNumber?: string;
    homeNumber?: string;
    mobileNumber?: string;
    crudStatus?: EmployeeModel.CrudStatusEnum;
    contactDetail?: EmployeeContactDetailModel;
    nextOfKinDetail?: EmployeeNextOfKinDetailModel;
    bankDetail?: EmployeeBankDetailModel;
}
export namespace EmployeeModel {
    export type CrudStatusEnum = 1 | 2 | 3 | 4;
    export const CrudStatusEnum = {
        NUMBER_1: 1 as CrudStatusEnum,
        NUMBER_2: 2 as CrudStatusEnum,
        NUMBER_3: 3 as CrudStatusEnum,
        NUMBER_4: 4 as CrudStatusEnum
    }
}