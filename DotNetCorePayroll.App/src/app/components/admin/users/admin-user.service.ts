import { Injectable, EventEmitter } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { AccountService, AccountModel, PageData } from '../../../shared/generated';
import { MatPaginator, MatSort } from '@angular/material';
import { Observable } from 'rxjs/Observable';
import { merge } from 'rxjs/observable/merge';
import { startWith, switchMap, map, catchError, finalize, tap } from 'rxjs/operators';
import { FieldHelper } from '../../../shared/utils/field-helper';

@Injectable()
export class AdminUserService {
  private _isBusy$: BehaviorSubject<boolean> = new BehaviorSubject(false);
  private _isInProgress$: BehaviorSubject<boolean> = new BehaviorSubject(false);
  private _totalUsers$: BehaviorSubject<number> = new BehaviorSubject(0);

  constructor(private accountService: AccountService) { }

  getUsers(paginator: MatPaginator, sort: MatSort, searchEvent: EventEmitter<string>): Observable<AccountModel[]> {
    this._isBusy$.next(true);

    return merge(sort.sortChange, paginator.page, searchEvent)
      .pipe(
        startWith({}),
        switchMap((event) => {
          const pageSize: number = paginator.pageSize ? paginator.pageSize : 5;
          const searchText = typeof event === 'string' ? event : null;

          return this.accountService.fetchAccounts(
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
    let savedUser$: Observable<AccountModel> = this.accountService.createAccount(accountModel);

    if (accountModel.id) {
      savedUser$ = this.accountService.updateAccount(accountModel);
    }

    return savedUser$.pipe(
      tap(() => {
        this._isInProgress$.next(true);
      }),
      map((response) => {
        this._isInProgress$.next(false);
        return response;
      }),
      finalize(() => {
        this._isInProgress$.next(false);
      })
    );

  }

  get isBusy$(): Observable<boolean> {
    return this._isBusy$.asObservable();
  }

  get totalUsers$(): Observable<number> {
    return this._totalUsers$.asObservable();
  }

  get isInProgress$(): Observable<boolean> {
    return this._isInProgress$.asObservable();
  }
}
