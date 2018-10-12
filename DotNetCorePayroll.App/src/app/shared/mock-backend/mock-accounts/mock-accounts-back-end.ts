import { HttpRequest, HttpEvent, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { AccountModel } from '../../generated';

export function mockAccountsBackEndService(url: string, method: string, request: HttpRequest<any>): Observable<HttpEvent<any>> {

    if (url.endsWith('/api/Account/FetchAccounts') && method === 'POST') {
        const skip = request.body.pageData.skip;
        const take = request.body.pageData.take + skip;
        const searchText = request.body.searchText;

        const items: AccountModel[] = [];

        for (let i = 1; i < 100; i++) {
            const valueId = i % 3 + 1;
            const account: AccountModel = {
                id: '451241-tggert-7899po-kujgf' + i,
                organisationId: i,
                username: 'TestUser' + i,
                firstname: 'Qinisela' + i,
                lastname: 'Molefe' + i,
                emailAddress: 'molefeq@gmail.com',
                contactNumber: '0114478965',
                roleId: 1
            };

            if (searchText && !(account.username.indexOf(searchText) >= 0 || account.firstname.indexOf(searchText) >= 0)) {
                continue;
            }

            items.push(account);
        }

        return new Observable(resp => {
            setTimeout(() => {
                resp.next(new HttpResponse({
                    status: 200,
                    body: {
                        'totalItems': items.length,
                        'items': items.slice(skip, take)
                    }
                }));

                resp.complete();
            }, 2002);
        });
    }

    if (url.endsWith('/api/Account/CreateAccount') && method === 'POST') {
        const account: AccountModel = request.body;
        account.id = 'gfhgsdj-hgdhdhgjgh-122323234';

        return new Observable(resp => {
            resp.next(new HttpResponse({
                status: 200,
                body: account
            }));

            resp.complete();
        });
    }

    if (url.endsWith('/api/Account/UpdateAccount') && method === 'POST') {
        return new Observable(resp => {
            resp.next(new HttpResponse({
                status: 200,
                body: request.body
            }));

            resp.complete();
        });
    }
}
