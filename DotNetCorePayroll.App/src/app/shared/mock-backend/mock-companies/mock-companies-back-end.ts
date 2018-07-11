import { HttpRequest, HttpEvent, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { CompanyModel } from '../../generated';

export function mockCompaniesBackEndService(url: string, method: string, request: HttpRequest<any>): Observable<HttpEvent<any>> {

    if (url.endsWith('/api/Company/GetCompanies') && method === "POST") {
        var skip = request.body.pageData.skip;
        var take = request.body.pageData.take + skip;
        var searchText = request.body.searchText;

        var items: CompanyModel[] = [];

        for (var i: number = 1; i < 100; i++) {
            const valueId = i % 3 + 1;
            let company: CompanyModel = {
                id: '451241-tggert-7899po-kujgf' + i,
                organisationId: i,
                organisationName: 'test organisation' + i,
                name: "test organisation" + i,
                registeredName: '',
                tradingName: '',
                natureOfBusiness: '',
                companyRegistrationNumber: '',
                taxNumber: '',
                uifReferenceNumber: '',
                payeReferenceNumber: '',
                uifCompanyReferenceNumber: '',
                sarsUifNumber: '',
                paysdlInd: i % 3 == 0,
                physicalAddressLine1: "Line " + (i + 1),
                physicalAddressLine2: "Line " + (i + 2),
                physicalAddressSuburb: "Suburb " + i,
                physicalAddressCity: "City " + i,
                physicalAddressPostalCode: "200" + i,
                physicalAddressProvinceId: valueId,
                physicalAddressCountryId: valueId,
                postalAddressId: i,
                postalAddressLine1: "Post Line " + (i + 1),
                postalAddressLine2: "Post Line " + (i + 2),
                postalAddressSuburb: "Post Suburb " + i,
                postalAddressCity: "Post City " + i,
                postalAddressPostalCode: "200" + i,
                postalAddressProvinceId: valueId,
                postalAddressCountryId: valueId,
                faxNumber: "01178900" + i,
                emailAddress: "testuser" + i + "@gmail.com",
                contactNumber: "084621300" + i,
            };

            if (searchText && !(company.name.indexOf(searchText) >= 0 || company.organisationName.indexOf(searchText) >= 0)) {
                continue;
            }

            items.push(company);
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

    if (url.endsWith('/api/Company/AddCompany') && method === "POST") {
        let company: CompanyModel = request.body;
        company.id = 'gfhgsdj-hgdhdhgjgh-122323234';

        return new Observable(resp => {
            resp.next(new HttpResponse({
                status: 200,
                body: company
            }));

            resp.complete();
        });
    }

    if (url.endsWith('/api/Company/UpdateCompany') && method === "POST") {
        return new Observable(resp => {
            resp.next(new HttpResponse({
                status: 200,
                body: request.body
            }));

            resp.complete();
        });
    }
}
