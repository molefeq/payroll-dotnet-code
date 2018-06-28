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
            let organisation: OrganisationModel = {
                id: i,
                name: "test organisation" + i,
                description: "organisation description" + i,
                physicalAddressLine1: "Line " + (i + 1),
                physicalAddressLine2: "Line " + (i + 2),
                physicalAddressSuburb: "Suburb " + i,
                physicalAddressCity: "City " + i,
                physicalAddressPostalCode: "200 " + i,
                physicalAddressProvinceId: i,
                physicalAddressCountryId: i,
                postalAddressId: i,
                postalAddressLine1: "Line " + (i + 1),
                postalAddressLine2: "Line " + (i + 2),
                postalAddressSuburb: "Suburb " + i,
                postalAddressCity: "City " + i,
                postalAddressPostalCode: "200 " + i,
                postalAddressProvinceId: i,
                postalAddressCountryId: i,
                faxNumber: "01178900" + i,
                emailAddress: "testuser" + i + "@gmail.com",
                contactNumber: "084621300" + i,
            };

            if (searchText && !(organisation.name.indexOf(searchText) >= 0 || organisation.description.indexOf(searchText) >= 0)) {
                continue;
            }

            items.push(organisation);
        }

       let pagedItems = items.slice(skip, take);

        return new Observable(resp => {
            resp.next(new HttpResponse({
                status: 200,
                body: {
                    "totalItems": items.length,
                    "items": pagedItems
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
