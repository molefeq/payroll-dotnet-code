import { Injectable, EventEmitter } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { AccountService, AccountModel, PageData, CompanyModel } from '../../../shared/generated';
import { MatPaginator, MatSort } from '@angular/material';
import { Observable } from 'rxjs/Observable';
import { merge } from 'rxjs/observable/merge';
import { startWith, switchMap, map, catchError, finalize, tap } from 'rxjs/operators';
import { FieldHelper } from '../../../shared/utils/field-helper';
import { CompanyDetailsService } from '../../company/company-details.service';

@Injectable()
export class AdminUserService {
  private _isBusy$: BehaviorSubject<boolean> = new BehaviorSubject(false);
  private _totalUsers$: BehaviorSubject<number> = new BehaviorSubject(0);
  private _companies$: BehaviorSubject<CompanyModel[]> = new BehaviorSubject([]);

  constructor(private accountService: AccountService,
    private companyDetailsService: CompanyDetailsService) { }

  getUsers(paginator: MatPaginator, sort: MatSort, searchEvent: EventEmitter<string>): Observable<AccountModel[]> {
    this._isBusy$.next(true);

    return merge(sort.sortChange, paginator.page, searchEvent)
      .pipe(
        startWith({}),
        switchMap((event) => {
          const pageSize: number = paginator.pageSize ? paginator.pageSize : 5;
          const searchText = typeof event === 'string' ? event : null;

          return this.accountService.apiAccountFetchAccountsPost(
            {
              searchText: searchText,
              pageData: {
                includeAllData: false,
                take: pageSize,
                skip: pageSize * (paginator.pageIndex),
                sortOrder: sort.direction === 'desc' ? PageData.SortOrderEnum.NUMBER_2 : PageData.SortOrderEnum.NUMBER_1,
                sortColumn: Boolean(sort.active) ? FieldHelper.toCamelCase(sort.active) : 'Username'
              }
            });
        }),
        map(data => {
          this._isBusy$.next(false);
          this._totalUsers$.next(data.totalItems);
          return data.items;
        }),
        catchError((): Observable<AccountModel[]> => {
          const items: AccountModel[] = [];
          this._isBusy$.next(false);

          return Observable.of([]);
        }),
        finalize(() => {
          this._isBusy$.next(false);
        })
      );
  }

  saveUser(accountModel: AccountModel): Observable<AccountModel> {
    if (accountModel.id) {
      return this.accountService.apiAccountUpdateAccountPost(accountModel);
    }

    return this.accountService.apiAccountCreateAccountPost(accountModel);
  }

  getOrganisationCompanies(organisationId) {
    if (!Boolean(organisationId)) {
      this._companies$.next([]);
      return;
    }

    this.companyDetailsService.getCompaniesReferenceData(organisationId)
      .subscribe((response) => {
        this._companies$.next(response);
      });
  }

  get isBusy$(): Observable<boolean> {
    return this._isBusy$.asObservable();
  }

  get totalUsers$(): Observable<number> {
    return this._totalUsers$.asObservable();
  }

  get companies$(): Observable<CompanyModel[]> {
    return this._companies$.asObservable();
  }
}
