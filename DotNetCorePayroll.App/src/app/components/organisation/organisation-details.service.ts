import { Injectable, EventEmitter } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { OrganisationService, OrganisationModel, PageData } from '../../shared/generated';
import { MatPaginator, MatSort } from '@angular/material';
import { merge } from 'rxjs/observable/merge';
import { startWith, switchMap, map, catchError, finalize } from 'rxjs/operators';

@Injectable()
export class OrganisationDetailsService {
  private _isBusy$: BehaviorSubject<boolean> = new BehaviorSubject(false);
  private _totalOrganisations$: BehaviorSubject<number> = new BehaviorSubject(0);

  constructor(private organisationService: OrganisationService) { }

  getOrganisations(paginator: MatPaginator, sort: MatSort, searchEvent: EventEmitter<string>): Observable<OrganisationModel[]> {
    this._isBusy$.next(true);

    return merge(sort.sortChange, paginator.page, searchEvent)
      .pipe(
        startWith({}),
        switchMap((event) => {
          let pageSize: number = paginator.pageSize ? paginator.pageSize : 5;
          let searchText = typeof event === 'string' ? event : null;

          console.log({
            includeAllData: false,
            take: pageSize,
            skip: pageSize * (paginator.pageIndex),
            sortOrder: sort.direction == 'asc' ? PageData.SortOrderEnum.NUMBER_1 : PageData.SortOrderEnum.NUMBER_2,
            sortColumn: sort.active
          });

          return this.organisationService.apiOrganisationGetOrganisationsPost(
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
          this._totalOrganisations$.next(data.totalItems);
          return data.items;
        }),
        catchError((): Observable<OrganisationModel[]> => {
          this._isBusy$.next(false);

          return Observable.of([]);
        }),
        finalize(() => {
          this._isBusy$.next(false);
        })
      );
  };

  saveOrganisation(organisationModel: OrganisationModel):  Observable<OrganisationModel>{
    if(organisationModel.id){
      return  this.organisationService.apiOrganisationAddOrganisationPost(organisationModel);
    }

    return  this.organisationService.apiOrganisationUpdateOrganisationPost(organisationModel);
  }

  get isBusy$(): Observable<boolean> {
    return this._isBusy$.asObservable();
  }

  get totalOrganisations$(): Observable<number> {
    return this._totalOrganisations$.asObservable();
  }

}
