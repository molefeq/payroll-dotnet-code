import { Injectable, EventEmitter } from '@angular/core';
import { RoleService, RoleModel, PageData } from '../../../shared/generated';
import { Observable } from 'rxjs';
import { MatPaginator, MatSort } from '@angular/material';
import { merge } from 'rxjs/observable/merge';
import { startWith, switchMap, map, catchError, finalize } from 'rxjs/operators';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import 'rxjs/add/observable/of';

@Injectable()
export class AdminRoleService {
  private _isBusy$: BehaviorSubject<boolean> = new BehaviorSubject(false);
  private _totalRoles$: BehaviorSubject<number> = new BehaviorSubject(0);

  constructor(private roleService: RoleService) { }

  getRoles(paginator: MatPaginator, sort: MatSort, searchEvent: EventEmitter<string>): Observable<RoleModel[]> {
    this._isBusy$.next(true);

    return merge(sort.sortChange, paginator.page, searchEvent)
      .pipe(
        startWith({}),
        switchMap((event) => {
          let pageSize: number = paginator.pageSize ? paginator.pageSize : 5;
          let searchText = typeof event === 'string' ? event : null;
          
          return this.roleService.apiRoleGetRolesPost(
            {
              searchText: searchText,
              pageData: {
                includeAllData: false,
                take: pageSize,
                skip: pageSize * (paginator.pageIndex),
                sortOrder: sort.direction == 'asc' ? PageData.SortOrderEnum.NUMBER_1 : PageData.SortOrderEnum.NUMBER_2,
                sortColumn: sort.active
              }
            });
        }),
        map(data => {
          this._isBusy$.next(false);
          this._totalRoles$.next(data.totalItems);
          return data.items;
        }),
        catchError((): Observable<RoleModel[]> => {
          const items: RoleModel[] = [];
          this._isBusy$.next(false);

          return Observable.of([]);
        }),
        finalize(() => {
          this._isBusy$.next(false);
        })
      );
  };

  get isBusy$(): Observable<boolean> {
    return this._isBusy$.asObservable();
  }

  get totalRoles$(): Observable<number> {
    return this._totalRoles$.asObservable();
  }
}
