import { HttpRequest, HttpEvent, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { OrganisationModel } from '../../generated';

export function mockOrganisationsBackEndService(url: string, method: string, request: HttpRequest<any>): Observable<HttpEvent<any>> {

    if (url.endsWith('/api/Organisation/GetOrganisations') && method === 'POST') {
        const skip = request.body.pageData.skip;
        const take = request.body.pageData.take + skip;
        const searchText = request.body.searchText;

        const items: OrganisationModel[] = [];

        for (let i = 1; i < 100; i++) {
            const valueId = i % 3 + 1;
            const organisation: OrganisationModel = {
                id: i,
                guid: '451241-tggert-7899po-kujgf' + i,
                name: 'test organisation' + i,
                description: 'organisation description' + i,
                physicalAddress: {
                    id: i,
                    line1: 'Line ' + (i + 1),
                    line2: 'Line ' + (i + 2),
                    suburb: 'Suburb ' + i,
                    city: 'City ' + i,
                    postalCode: '200' + i,
                    provinceId: valueId,
                    countryId: valueId,
                },
                postalAddress: {
                    id: i,
                    line1: 'Post Line ' + (i + 1),
                    line2: 'Post Line ' + (i + 2),
                    suburb: 'Post Suburb ' + i,
                    city: 'Post City ' + i,
                    postalCode: '200' + i,
                    provinceId: valueId,
                    countryId: valueId,
                },
                faxNumber: '01178900' + i,
                emailAddress: 'testuser' + i + '@gmail.com',
                contactNumber: '084621300' + i,
                logoFileNamePath: 'https://material.angular.io/assets/img/examples/shiba2.jpg'
            };

            if (searchText && !(organisation.name.indexOf(searchText) >= 0 || organisation.description.indexOf(searchText) >= 0)) {
                continue;
            }

            items.push(organisation);
        }

        return new Observable(resp => {
            setTimeout(() => {
                resp.next(new HttpResponse({
                    status: 200,
                    body: {
                        'totalItems': items.length,
                        'items': items
                    }
                }));

                resp.complete();
            }, 2000);
        });
    }

    if (url.endsWith('/api/Organisation/AddOrganisation') && method === 'POST') {
        const organisation: OrganisationModel = request.body;
        organisation.guid = 'gfhgsdj-hgdhdhgjgh-122323234';
        organisation.id = 1;

        return new Observable(resp => {
            resp.next(new HttpResponse({
                status: 200,
                body: organisation
            }));

            resp.complete();
        });
    }

    if (url.endsWith('/api/Organisation/UpdateOrganisation') && method === 'POST') {
        return new Observable(resp => {
            resp.next(new HttpResponse({
                status: 200,
                body: request.body
            }));

            resp.complete();
        });
    }
}
