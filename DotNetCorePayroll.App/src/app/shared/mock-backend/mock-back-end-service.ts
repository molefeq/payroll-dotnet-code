import { HttpRequest, HttpEvent, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { mockRoleBackEndService } from './mock-roles/mock-roles-back-end-services';
import { mockOrganisationsBackEndService } from './mock-organisations/mock-organisations-back-end';
import { mockReferenceDataBackEndService } from './mock-reference-data/mock-reference-data-back-end';
import { mockCompaniesBackEndService } from './mock-companies/mock-companies-back-end';
import { mockEmployeesBackEndService } from './mock-employees/mock-employees-back-end';
import { mockAccountsBackEndService } from './mock-accounts/mock-accounts-back-end';

export function mockBackEndService(url: string, method: string, request: HttpRequest<any>): Observable<HttpEvent<any>> {

    // if (url.endsWith('/api/Account/Login') && method === 'POST') {
    //     return new Observable(resp => {
    //         resp.next(new HttpResponse({
    //             status: 200,
    //             body: {
    //                 id: '120312012-123121-retfds',
    //                 userName: 'molefeq',
    //                 token: 'teshsdfjkghdfkgdfgkfhgjkhgjkdghdfjk',
    //                 organisationId: 1,
    //                 organisationName: 'Test Organisation',
    //                 companyId: null,
    //                 companyName: null,
    //                 roleId: 1,
    //                 roleName: 'Admin',
    //                 isFirstTimeLogIn: true
    //             }
    //         }));

    //         resp.complete();
    //     });
    // }

    // if (url.indexOf('/api/Role/') >= 0) {
    //     return mockRoleBackEndService(url, method, request);
    // }

    // if (url.indexOf('/api/Organisation/') >= 0) {
    //     return mockOrganisationsBackEndService(url, method, request);
    // }
    // if (url.indexOf('/api/ReferenceData/') >= 0) {
    //     return mockReferenceDataBackEndService(url, method, request);
    // }
    // if (url.indexOf('/api/Company/') >= 0) {
    //     return mockCompaniesBackEndService(url, method, request);
    // }
    if (url.indexOf('/api/Employee/') >= 0) {
        return mockEmployeesBackEndService(url, method, request);
    }
    // if (url.indexOf('/api/Account/') >= 0) {
    //     return mockAccountsBackEndService(url, method, request);
    // }
}
