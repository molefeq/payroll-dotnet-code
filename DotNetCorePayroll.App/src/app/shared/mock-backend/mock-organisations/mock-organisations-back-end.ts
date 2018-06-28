import { Injectable } from '@angular/core';
import { HttpRequest, HttpEvent, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { RoleModel, OrganisationModel } from '../../generated';

export function mockOrganisationsBackEndService(url: string, method: string, request: HttpRequest<any>): Observable<HttpEvent<any>> {

    if (url.endsWith('/api/Organisation/GetOrganisations') && method === "POST") {
        var skip = request.body.pageData.skip;
        var take = request.body.pageData.take + skip;
        var searchText = request.body.searchText;

        var items: OrganisationModel[] = [];

        for (var i = skip; i < 100; i++) {
            let organisation = { id: i, name: "role " + i, code: "code " + i };
            if (searchText && !(organisation.name.indexOf(searchText) >= 0 || organisation.code.indexOf(searchText) >= 0)) {
                continue;
            }

            items.push(organisation);
        }

        console.log(items.slice(skip, take));

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

    if (url.endsWith('/api/Organisation/AddOrganisation') && method === "POST") {
        let organisation: OrganisationModel = request.body;
        organisation.id = 'gfhgsdj-hgdhdhgjgh-122323234';

        return new Observable(resp => {
            resp.next(new HttpResponse({
                status: 200,
                body: organisation
            }));

            resp.complete();
        });
    }

    if (url.endsWith('/api/Organisation/UpdateOrganisation') && method === "POST") {
        return new Observable(resp => {
            resp.next(new HttpResponse({
                status: 200,
                body: request.body
            }));

            resp.complete();
        });
    }
}
