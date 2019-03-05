import { HttpRequest, HttpEvent, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { CompanyModel } from '../../generated';

export function mockCompaniesBackEndService(url: string, method: string, request: HttpRequest<any>): Observable<HttpEvent<any>> {

    if (url.endsWith('/api/Company/GetCompanies') && method === 'POST') {
        const skip = request.body.pageData.skip;
        const take = request.body.pageData.take + skip;
        const searchText = request.body.searchText;

        const items: CompanyModel[] = [];

        for (let i = 1; i < 2; i++) {
            const valueId = i % 3 + 1;
            const company: CompanyModel = {
                id: i,
                guid: '451241-tggert-7899po-kujgf' + i,
                organisationId: i,
                organisationName: 'test organisation' + i,
                name: 'Test Company' + i,
                registeredName: '',
                tradingName: '',
                natureOfBusiness: '',
                companyRegistrationNumber: '',
                taxNumber: '',
                uifReferenceNumber: '',
                payeReferenceNumber: '',
                uifCompanyReferenceNumber: '',
                sarsUifNumber: '',
                paysdlInd: i % 3 === 0,
                address: {
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
                    postalAddress:
                    {
                        id: i,
                        line1: 'Post Line ' + (i + 1),
                        line2: 'Post Line ' + (i + 2),
                        suburb: 'Post Suburb ' + i,
                        city: 'Post City ' + i,
                        postalCode: '200' + i,
                        provinceId: valueId,
                        countryId: valueId
                    }

                },
                faxNumber: '01178900' + i,
                emailAddress: 'testuser' + i + '@gmail.com',
                contactNumber: '084621300' + i,
                logoFileNamePath: 'https://material.angular.io/assets/img/examples/shiba2.jpg',
            };

            if (searchText && !(company.name.indexOf(searchText) >= 0 || company.organisationName.indexOf(searchText) >= 0)) {
                continue;
            }

            items.push(company);
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
            }, 2002);
        });
    }

    if (url.endsWith('/api/Company/AddCompany') && method === 'POST') {
        const company: CompanyModel = request.body;
        company.guid = 'gfhgsdj-hgdhdhgjgh-122323234';

        return new Observable(resp => {
            resp.next(new HttpResponse({
                status: 200,
                body: company
            }));

            resp.complete();
        });
    }

    if (url.endsWith('/api/Company/UpdateCompany') && method === 'POST') {
        return new Observable(resp => {
            resp.next(new HttpResponse({
                status: 200,
                body: request.body
            }));

            resp.complete();
        });
    }
}
