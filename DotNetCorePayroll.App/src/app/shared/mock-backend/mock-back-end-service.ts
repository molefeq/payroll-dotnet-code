import { Injectable } from '@angular/core';
import { HttpRequest, HttpEvent, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { UserModel, RoleModel } from '../generated';
import { mockRoleBackEndService } from './mock-roles/mock-roles-back-end-services';
import { mockOrganisationsBackEndService } from './mock-organisations/mock-organisations-back-end';

export function mockBackEndService(url: string, method: string, request: HttpRequest<any>): Observable<HttpEvent<any>> {

    if (url.endsWith('/api/Account/Login') && method === "POST") {
        return new Observable(resp => {
            resp.next(new HttpResponse({
                status: 200,
                body: {
                    id: '120312012-123121-retfds',
                    userName: 'molefeq',
                    token: 'teshsdfjkghdfkgdfgkfhgjkhgjkdghdfjk',
                    organisationId: 1,
                    organisationName: 'Test Organisation',
                    companyId: null,
                    companyName: null,
                    roleId: 1,
                    roleName: 'Admin',
                    isFirstTimeLogIn: true
                }
            }));

            resp.complete();
        });
    }

    if (url.indexOf('/api/Role/') >= 0) {
        return mockRoleBackEndService(url, method, request);
    }

    if (url.indexOf('/api/Organisation/') >= 0) {
        return mockOrganisationsBackEndService(url, method, request);
    }
}
