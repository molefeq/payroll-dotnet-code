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


export interface AccountModel { 
    id?: string;
    username: string;
    password?: string;
    firstname: string;
    lastname: string;
    emailAddress: string;
    contactNumber?: string;
    organisationId: number;
    companyId?: number;
    roleId: number;
    forgotPasswordKey?: string;
    createUserId?: number;
}
