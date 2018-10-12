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
/* tslint:disable:no-unused-variable member-ordering */

import { Inject, Injectable, Optional }                      from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams,
         HttpResponse, HttpEvent }                           from '@angular/common/http';
import { CustomHttpUrlEncodingCodec }                        from '../encoder';

import { Observable }                                        from 'rxjs/Observable';

import { CompanyBankDetailModel } from '../model/companyBankDetailModel';
import { CompanyContactDetailModel } from '../model/companyContactDetailModel';
import { CompanyModel } from '../model/companyModel';
import { CompanyPayrollSettingModel } from '../model/companyPayrollSettingModel';
import { CompanySearchFilter } from '../model/companySearchFilter';
import { ResultCompanyModel } from '../model/resultCompanyModel';

import { BASE_PATH, COLLECTION_FORMATS }                     from '../variables';
import { Configuration }                                     from '../configuration';


@Injectable()
export class CompanyService {

    protected basePath = 'https://localhost';
    public defaultHeaders = new HttpHeaders();
    public configuration = new Configuration();

    constructor(protected httpClient: HttpClient, @Optional()@Inject(BASE_PATH) basePath: string, @Optional() configuration: Configuration) {
        if (basePath) {
            this.basePath = basePath;
        }
        if (configuration) {
            this.configuration = configuration;
            this.basePath = basePath || configuration.basePath || this.basePath;
        }
    }

    /**
     * @param consumes string[] mime-types
     * @return true: consumes contains 'multipart/form-data', false: otherwise
     */
    private canConsumeForm(consumes: string[]): boolean {
        const form = 'multipart/form-data';
        for (let consume of consumes) {
            if (form === consume) {
                return true;
            }
        }
        return false;
    }


    /**
     * 
     * 
     * @param companyModel 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public apiCompanyAddCompanyPost(companyModel?: CompanyModel, observe?: 'body', reportProgress?: boolean): Observable<CompanyModel>;
    public apiCompanyAddCompanyPost(companyModel?: CompanyModel, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<CompanyModel>>;
    public apiCompanyAddCompanyPost(companyModel?: CompanyModel, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<CompanyModel>>;
    public apiCompanyAddCompanyPost(companyModel?: CompanyModel, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        let headers = this.defaultHeaders;

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
            'application/json'
        ];
        let httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set("Accept", httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        let consumes: string[] = [
            'application/json-patch+json',
            'application/json',
            'text/json',
            'application/_*+json'
        ];
        let httpContentTypeSelected:string | undefined = this.configuration.selectHeaderContentType(consumes);
        if (httpContentTypeSelected != undefined) {
            headers = headers.set("Content-Type", httpContentTypeSelected);
        }

        return this.httpClient.post<CompanyModel>(`${this.basePath}/api/Company/AddCompany`,
            companyModel,
            {
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * 
     * 
     * @param companyModel 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public apiCompanyDeleteCompanyPost(companyModel?: CompanyModel, observe?: 'body', reportProgress?: boolean): Observable<any>;
    public apiCompanyDeleteCompanyPost(companyModel?: CompanyModel, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
    public apiCompanyDeleteCompanyPost(companyModel?: CompanyModel, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
    public apiCompanyDeleteCompanyPost(companyModel?: CompanyModel, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        let headers = this.defaultHeaders;

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
        ];
        let httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set("Accept", httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        let consumes: string[] = [
            'application/json-patch+json',
            'application/json',
            'text/json',
            'application/_*+json'
        ];
        let httpContentTypeSelected:string | undefined = this.configuration.selectHeaderContentType(consumes);
        if (httpContentTypeSelected != undefined) {
            headers = headers.set("Content-Type", httpContentTypeSelected);
        }

        return this.httpClient.post<any>(`${this.basePath}/api/Company/DeleteCompany`,
            companyModel,
            {
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * 
     * 
     * @param companyId 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public apiCompanyFetchCompanyGet(companyId?: string, observe?: 'body', reportProgress?: boolean): Observable<CompanyModel>;
    public apiCompanyFetchCompanyGet(companyId?: string, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<CompanyModel>>;
    public apiCompanyFetchCompanyGet(companyId?: string, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<CompanyModel>>;
    public apiCompanyFetchCompanyGet(companyId?: string, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        let queryParameters = new HttpParams({encoder: new CustomHttpUrlEncodingCodec()});
        if (companyId !== undefined) {
            queryParameters = queryParameters.set('companyId', <any>companyId);
        }

        let headers = this.defaultHeaders;

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
            'application/json'
        ];
        let httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set("Accept", httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        let consumes: string[] = [
        ];

        return this.httpClient.get<CompanyModel>(`${this.basePath}/api/Company/FetchCompany`,
            {
                params: queryParameters,
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * 
     * 
     * @param searchFilter 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public apiCompanyGetCompaniesPost(searchFilter?: CompanySearchFilter, observe?: 'body', reportProgress?: boolean): Observable<ResultCompanyModel>;
    public apiCompanyGetCompaniesPost(searchFilter?: CompanySearchFilter, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ResultCompanyModel>>;
    public apiCompanyGetCompaniesPost(searchFilter?: CompanySearchFilter, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ResultCompanyModel>>;
    public apiCompanyGetCompaniesPost(searchFilter?: CompanySearchFilter, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        let headers = this.defaultHeaders;

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
            'application/json'
        ];
        let httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set("Accept", httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        let consumes: string[] = [
            'application/json-patch+json',
            'application/json',
            'text/json',
            'application/_*+json'
        ];
        let httpContentTypeSelected:string | undefined = this.configuration.selectHeaderContentType(consumes);
        if (httpContentTypeSelected != undefined) {
            headers = headers.set("Content-Type", httpContentTypeSelected);
        }

        return this.httpClient.post<ResultCompanyModel>(`${this.basePath}/api/Company/GetCompanies`,
            searchFilter,
            {
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * 
     * 
     * @param model 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public apiCompanySaveBankingDetailsPost(model?: CompanyBankDetailModel, observe?: 'body', reportProgress?: boolean): Observable<CompanyModel>;
    public apiCompanySaveBankingDetailsPost(model?: CompanyBankDetailModel, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<CompanyModel>>;
    public apiCompanySaveBankingDetailsPost(model?: CompanyBankDetailModel, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<CompanyModel>>;
    public apiCompanySaveBankingDetailsPost(model?: CompanyBankDetailModel, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        let headers = this.defaultHeaders;

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
            'application/json'
        ];
        let httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set("Accept", httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        let consumes: string[] = [
            'application/json-patch+json',
            'application/json',
            'text/json',
            'application/_*+json'
        ];
        let httpContentTypeSelected:string | undefined = this.configuration.selectHeaderContentType(consumes);
        if (httpContentTypeSelected != undefined) {
            headers = headers.set("Content-Type", httpContentTypeSelected);
        }

        return this.httpClient.post<CompanyModel>(`${this.basePath}/api/Company/SaveBankingDetails`,
            model,
            {
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * 
     * 
     * @param companyContactDetail 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public apiCompanySaveCompanyContactDetailsPost(companyContactDetail?: CompanyContactDetailModel, observe?: 'body', reportProgress?: boolean): Observable<CompanyModel>;
    public apiCompanySaveCompanyContactDetailsPost(companyContactDetail?: CompanyContactDetailModel, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<CompanyModel>>;
    public apiCompanySaveCompanyContactDetailsPost(companyContactDetail?: CompanyContactDetailModel, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<CompanyModel>>;
    public apiCompanySaveCompanyContactDetailsPost(companyContactDetail?: CompanyContactDetailModel, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        let headers = this.defaultHeaders;

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
            'application/json'
        ];
        let httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set("Accept", httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        let consumes: string[] = [
            'application/json-patch+json',
            'application/json',
            'text/json',
            'application/_*+json'
        ];
        let httpContentTypeSelected:string | undefined = this.configuration.selectHeaderContentType(consumes);
        if (httpContentTypeSelected != undefined) {
            headers = headers.set("Content-Type", httpContentTypeSelected);
        }

        return this.httpClient.post<CompanyModel>(`${this.basePath}/api/Company/SaveCompanyContactDetails`,
            companyContactDetail,
            {
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * 
     * 
     * @param companyPayrollSettingModel 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public apiCompanySaveCompanyPayrollSettingsPost(companyPayrollSettingModel?: CompanyPayrollSettingModel, observe?: 'body', reportProgress?: boolean): Observable<CompanyModel>;
    public apiCompanySaveCompanyPayrollSettingsPost(companyPayrollSettingModel?: CompanyPayrollSettingModel, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<CompanyModel>>;
    public apiCompanySaveCompanyPayrollSettingsPost(companyPayrollSettingModel?: CompanyPayrollSettingModel, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<CompanyModel>>;
    public apiCompanySaveCompanyPayrollSettingsPost(companyPayrollSettingModel?: CompanyPayrollSettingModel, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        let headers = this.defaultHeaders;

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
            'application/json'
        ];
        let httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set("Accept", httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        let consumes: string[] = [
            'application/json-patch+json',
            'application/json',
            'text/json',
            'application/_*+json'
        ];
        let httpContentTypeSelected:string | undefined = this.configuration.selectHeaderContentType(consumes);
        if (httpContentTypeSelected != undefined) {
            headers = headers.set("Content-Type", httpContentTypeSelected);
        }

        return this.httpClient.post<CompanyModel>(`${this.basePath}/api/Company/SaveCompanyPayrollSettings`,
            companyPayrollSettingModel,
            {
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * 
     * 
     * @param file 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public apiCompanySaveImagePost(file?: string, observe?: 'body', reportProgress?: boolean): Observable<any>;
    public apiCompanySaveImagePost(file?: string, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
    public apiCompanySaveImagePost(file?: string, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
    public apiCompanySaveImagePost(file?: string, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        let queryParameters = new HttpParams({encoder: new CustomHttpUrlEncodingCodec()});
        if (file !== undefined) {
            queryParameters = queryParameters.set('file', <any>file);
        }

        let headers = this.defaultHeaders;

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
        ];
        let httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set("Accept", httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        let consumes: string[] = [
        ];

        return this.httpClient.post<any>(`${this.basePath}/api/Company/SaveImage`,
            null,
            {
                params: queryParameters,
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * 
     * 
     * @param companyModel 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public apiCompanyUpdateCompanyPost(companyModel?: CompanyModel, observe?: 'body', reportProgress?: boolean): Observable<CompanyModel>;
    public apiCompanyUpdateCompanyPost(companyModel?: CompanyModel, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<CompanyModel>>;
    public apiCompanyUpdateCompanyPost(companyModel?: CompanyModel, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<CompanyModel>>;
    public apiCompanyUpdateCompanyPost(companyModel?: CompanyModel, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        let headers = this.defaultHeaders;

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
            'application/json'
        ];
        let httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set("Accept", httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        let consumes: string[] = [
            'application/json-patch+json',
            'application/json',
            'text/json',
            'application/_*+json'
        ];
        let httpContentTypeSelected:string | undefined = this.configuration.selectHeaderContentType(consumes);
        if (httpContentTypeSelected != undefined) {
            headers = headers.set("Content-Type", httpContentTypeSelected);
        }

        return this.httpClient.post<CompanyModel>(`${this.basePath}/api/Company/UpdateCompany`,
            companyModel,
            {
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

}