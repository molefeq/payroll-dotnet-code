import { Injectable, EventEmitter } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { OrganisationService, OrganisationModel, PageData, ResultOrganisationModel } from '../../shared/generated';
import { MatPaginator, MatSort } from '@angular/material';
import { merge } from 'rxjs/observable/merge';
import { startWith, switchMap, map, catchError, finalize, delay } from 'rxjs/operators';

@Injectable()
export class OrganisationDetailsService {
  private _isBusy$: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(true);
  private _totalOrganisations$: BehaviorSubject<number> = new BehaviorSubject(0);
  private _organisation: OrganisationModel = null;

  constructor(private organisationService: OrganisationService) { }

  getAllOrganisations(searchEvent: EventEmitter<string>): Observable<OrganisationModel[]> {
    const that = this;

    return searchEvent.pipe(
      startWith(null),
      delay(0),
      switchMap((event) => {

        that._isBusy$.next(true);
        const searchText = typeof event === 'string' ? event : null;

        return that.organisationService.apiOrganisationGetOrganisationsPost(
          {
            searchText: searchText,
            pageData: {
              includeAllData: true,
              sortOrder: PageData.SortOrderEnum.NUMBER_1,
              sortColumn: 'name'
            }
          });
      }),
      map(data => {
        that._totalOrganisations$.next(data.totalItems);

        data.items.forEach(item => that.setAddress(item));
        that._isBusy$.next(false);

        return data.items;
      }),
      catchError((): Observable<OrganisationModel[]> => {
        that._isBusy$.next(false);

        return Observable.of([]);
      })
    );
  }

  getOrganisationsReferenceData(): Observable<OrganisationModel[]> {
    return this.organisationService.apiOrganisationGetOrganisationsPost(
      {
        searchText: '',
        pageData: {
          includeAllData: true,
          sortOrder: PageData.SortOrderEnum.NUMBER_1,
          sortColumn: 'name'
        }
      }).pipe(
        map((response: ResultOrganisationModel) => {
          return response.items;
        }),
        catchError((): Observable<OrganisationModel[]> => {
          return Observable.of([]);
        })
      );
  }

  getOrganisations(paginator: MatPaginator, sort: MatSort, searchEvent: EventEmitter<string>): Observable<OrganisationModel[]> {
    this._isBusy$.next(true);

    return merge(sort.sortChange, paginator.page, searchEvent)
      .pipe(
        startWith({}),
        switchMap((event) => {
          const pageSize: number = paginator.pageSize ? paginator.pageSize : 5;
          const searchText = typeof event === 'string' ? event : null;

          return this.organisationService.apiOrganisationGetOrganisationsPost(
            {
              searchText: searchText,
              pageData: {
                includeAllData: false,
                take: pageSize,
                skip: pageSize * (paginator.pageIndex),
                sortOrder: sort.direction === 'asc' ? PageData.SortOrderEnum.NUMBER_1 : PageData.SortOrderEnum.NUMBER_2,
                sortColumn: sort.active
              }
            });
        }),
        map(data => {
          this._isBusy$.next(false);
          this._totalOrganisations$.next(data.totalItems);

          data.items.forEach(item => this.setAddress(item));

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
  }

  saveOrganisation(organisationModel: OrganisationModel): Observable<OrganisationModel> {
    if (!Boolean(organisationModel.id)) {
      return this.organisationService.apiOrganisationAddOrganisationPost(organisationModel);
    }

    return this.organisationService.apiOrganisationUpdateOrganisationPost(organisationModel);
  }

  get isBusy$(): Observable<boolean> {
    return this._isBusy$.asObservable();
  }

  get totalOrganisations$(): Observable<number> {
    return this._totalOrganisations$.asObservable();
  }

  set Organisation(organisation: OrganisationModel) {
    if (!Boolean(organisation)) {
      this._organisation = null;
      sessionStorage.removeItem('organisation');
    }

    sessionStorage.setItem('organisation', JSON.stringify(organisation));
    this._organisation = organisation;
  }

  get Organisation(): OrganisationModel {
    if (Boolean(this._organisation)) {
      return this._organisation;
    }

    if (Boolean(sessionStorage.getItem('organisation'))) {
      return JSON.parse(sessionStorage.getItem('organisation'));
    }

    return null;
  }

  setAddress(organisation: OrganisationModel) {
    if (Boolean(organisation.physicalAddress)) {
      organisation['physicalAddressText'] = [
        organisation.physicalAddress.line1,
        organisation.physicalAddress.line2,
        organisation.physicalAddress.suburb,
        organisation.physicalAddress.city,
        organisation.physicalAddress.postalCode].filter(Boolean).join(', ');
    }

    if (Boolean(organisation.postalAddress)) {
      organisation['physicalAddressText'] = [
        organisation.postalAddress.line1,
        organisation.postalAddress.line2,
        organisation.postalAddress.suburb,
        organisation.postalAddress.city,
        organisation.postalAddress.postalCode].filter(Boolean).join(', ');
    }
  }
}
