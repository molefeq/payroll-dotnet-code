import { HttpRequest, HttpEvent, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { ReferenceDataModel } from '../../generated';

export function mockReferenceDataBackEndService(url: string, method: string, request: HttpRequest<any>): Observable<HttpEvent<any>> {

    if (url.endsWith('/api/ReferenceData/GetStaticData') && method === "GET") {

        var countries: ReferenceDataModel[] = [];
        var provinces: ReferenceDataModel[] = [];

        for (var i = 1; i < 9; i++) {
            let country: ReferenceDataModel = {
                id: i,
                name: "Country " + i,
                code: "c_code" + i
            };

            countries.push(country);
        }

        for (var i = 1; i < 9; i++) {
            let province: ReferenceDataModel = {
                id: i,
                name: "Province " + i,
                code: "p_code" + i
            };

            provinces.push(province);
        }
        return new Observable(resp => {
            resp.next(new HttpResponse({
                status: 200,
                body: {
                    "countries": countries,
                    "provinces": provinces
                }
            }));

            resp.complete();
        });
    }

    if (url.endsWith('/api/ReferenceData/GetCountries') && method === "GET") {

        var countries: ReferenceDataModel[] = [];

        for (var i = 1; i < 19; i++) {
            let country: ReferenceDataModel = {
                id: i,
                name: "country " + i,
                code: "c_code" + i
            };

            countries.push(country);
        }

        return new Observable(resp => {
            resp.next(new HttpResponse({
                status: 200,
                body: countries
            }));

            resp.complete();
        });
    }

    if (url.endsWith('/api/ReferenceData/GetProvinces') && method === "GET") {
        var provinces: ReferenceDataModel[] = [];

        for (var i = 1; i < 9; i++) {
            let province: ReferenceDataModel = {
                id: i,
                name: "province " + i,
                code: "p_code" + i
            };

            provinces.push(province);
        }

        return new Observable(resp => {
            resp.next(new HttpResponse({
                status: 200,
                body: provinces
            }));

            resp.complete();
        });
    }

}
