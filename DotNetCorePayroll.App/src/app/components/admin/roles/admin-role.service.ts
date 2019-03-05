import { Injectable, EventEmitter } from '@angular/core';
import { RoleService, RoleModel, PageData } from '../../../shared/generated';
import { Observable } from 'rxjs';
import { MatPaginator, MatSort } from '@angular/material';
import { merge } from 'rxjs/observable/merge';
import { startWith, switchMap, map, catchError, finalize } from 'rxjs/operators';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import 'rxjs/add/observable/of';
import { FieldHelper } from '../../../shared/utils/field-helper';

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
          const pageSize: number = paginator.pageSize ? paginator.pageSize : 5;
          const searchText = typeof event === 'string' ? event : null;

          return this.roleService.getRoles(
            {
              searchText: searchText,
              pageData: {
                includeAllData: false,
                take: pageSize,
                skip: pageSize * (paginator.pageIndex),
                sortOrder: sort.direction === 'desc' ? PageData.SortOrderEnum.NUMBER_2 : PageData.SortOrderEnum.NUMBER_1,
                sortColumn: Boolean(sort.active) ? FieldHelper.toCamelCase(sort.active) : 'Name'
              }
            });
        }),
        map(data => {
          this._isBusy$.next(false);
          this._totalRoles$.next(data.totalItems);
          return data.items;
        }),
        catchError((): Observable<RoleModel[]> => {
          this._isBusy$.next(false);

          return Observable.of([]);
        }),
        finalize(() => {
          this._isBusy$.next(false);
        })
      );
  }

  getRolesRefrenceData(): Observable<RoleModel[]> {

    return this.roleService.getRoles(
      {
        searchText: '',
        pageData: {
          includeAllData: true,
          sortOrder: PageData.SortOrderEnum.NUMBER_1,
          sortColumn: 'Name'
        }
      }).pipe(
        map(data => {
          return data.items;
        }),
        catchError((): Observable<RoleModel[]> => {
          return Observable.of([]);
        })
      );
  }
  saveRole(roleModel: RoleModel): Observable<RoleModel> {
    if (roleModel.id) {
      return this.roleService.updateRole(roleModel);
    }

    return this.roleService.addRole(roleModel);
  }

  get isBusy$(): Observable<boolean> {
    return this._isBusy$.asObservable();
  }

  get totalRoles$(): Observable<number> {
    return this._totalRoles$.asObservable();
  }
}
