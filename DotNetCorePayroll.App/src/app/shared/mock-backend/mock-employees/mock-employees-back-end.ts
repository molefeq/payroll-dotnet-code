import { HttpRequest, HttpEvent, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { EmployeeModel } from '../../generated';

export function mockEmployeesBackEndService(url: string, method: string, request: HttpRequest<any>): Observable<HttpEvent<any>> {

    if (url.endsWith('/api/Employee/GetEmployees') && method === 'POST') {
        const skip = request.body.pageData.skip;
        const take = request.body.pageData.take + skip;
        const searchText = request.body.searchText;

        const items: EmployeeModel[] = [];

        for (let i = 1; i < 100; i++) {
            const valueId = i % 3 + 1;
            const employee: EmployeeModel = {
                id: i,
                companyId: '1202124564-ghdkjghfdk',
                employeeNumber: '123_' + i,
                firstName: 'firstname ' + i,
                lastName: 'lastname ' + i,
                title: i % 2 === 0 ? 'Mr' : 'Miss',
                dateOfBirth: new Date(1987, (i % 10 + 1), (i % 28 + 1)),
                isSouthAfricanCitizen: i % 2 === 0,
                ethnicGroup: 'Black',
                gender: i % 2 === 0 ? 'Male' : 'Female',
                hasDisability: i % 2 === 0,
                disabilityDescription: i % 2 === 0 ? 'Lack of eye sight' : null,
                maritalStatus: i % 2 === 0 ? 'Single' : 'Married',
                homeLanguage: 'IsiZulu',
                taxReferenceNumber: '1232346846511',
                isSystemUser: false,
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
                    postalAddress: {
                        id: i,
                        line1: 'Post Line ' + (i + 1),
                        line2: 'Post Line ' + (i + 2),
                        suburb: 'Post Suburb ' + i,
                        city: 'Post City ' + i,
                        postalCode: '200' + i,
                        provinceId: valueId,
                        countryId: valueId,
                    }
                },
                homeNumber: '01178900' + i,
                workNumber: '01178925' + i,
                emailAddress: 'testuser' + i + '@gmail.com',
                mobileNumber: '084621300' + i,
            };

            if (searchText && !(employee.firstName.indexOf(searchText) >= 0 || employee.lastName.indexOf(searchText) >= 0)) {
                continue;
            }

            items.push(employee);
        }

        const pagedItems = items.slice(skip, take);

        return new Observable(resp => {
            resp.next(new HttpResponse({
                status: 200,
                body: {
                    'totalItems': items.length,
                    'items': pagedItems
                }
            }));

            resp.complete();
        });
    }

    if (url.endsWith('/api/Employee/AddEmployee') && method === 'POST') {
        const employee: EmployeeModel = request.body;
        employee.id = 4;

        return new Observable(resp => {
            resp.next(new HttpResponse({
                status: 200,
                body: employee
            }));

            resp.complete();
        });
    }

    if (url.endsWith('/api/Employee/UpdateEmployee') && method === 'POST') {
        return new Observable(resp => {
            resp.next(new HttpResponse({
                status: 200,
                body: request.body
            }));

            resp.complete();
        });
    }
}
