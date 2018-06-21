import { Injectable } from '@angular/core';
import { HttpRequest, HttpEvent, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { UserModel, RoleModel } from '../generated';

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

    if (url.endsWith('/api/Role/GetRoles') && method === "POST") {
        var items: RoleModel[] = [];
        for (var i = 0; i < 100; i++) {
            items.push({ id: i, name: "role " + i, code: "code " + i });
        }

        return new Observable(resp => {
            resp.next(new HttpResponse({
                status: 200,
                body: {
                    "totalItems": 100,
                    "items": items
                }
            }));

            resp.complete();
        });
    }
}
