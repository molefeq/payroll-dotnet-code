import { Injectable } from '@angular/core';
import { HttpRequest, HttpEvent, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { RoleModel } from '../../generated';

export function mockRoleBackEndService(url: string, method: string, request: HttpRequest<any>): Observable<HttpEvent<any>> {

    if (url.endsWith('/api/Role/GetRoles') && method === "POST") {
        var skip = request.body.pageData.skip;
        var take = request.body.pageData.take + skip;
        var searchText = request.body.searchText;

        var items: RoleModel[] = [];

        for (var i = skip; i < 100; i++) {
            let role = { id: i, name: "role " + i, code: "code " + i };
            if (searchText && !(role.name.indexOf(searchText) >= 0 || role.code.indexOf(searchText) >= 0)) {
                continue;
            }

            items.push(role);
        }

        return new Observable(resp => {
            resp.next(new HttpResponse({
                status: 200,
                body: {
                    "totalItems": 100,
                    "items": items.slice(skip, take)
                }
            }));

            resp.complete();
        });
    }

    if (url.endsWith('/api/Role/AddRole') && method === "POST") {
        let role: RoleModel = request.body;
        role.id = 100;

        return new Observable(resp => {
            resp.next(new HttpResponse({
                status: 200,
                body: role
            }));

            resp.complete();
        });
    }

    if (url.endsWith('/api/Role/UpdateRole') && method === "POST") {
        return new Observable(resp => {
            resp.next(new HttpResponse({
                status: 200,
                body: request.body
            }));

            resp.complete();
        });
    }
}
