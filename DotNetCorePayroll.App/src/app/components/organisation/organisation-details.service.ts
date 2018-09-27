import { Injectable, EventEmitter } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { OrganisationService, OrganisationModel, PageData } from '../../shared/generated';
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
    if (organisationModel.id) {
      return this.organisationService.apiOrganisationAddOrganisationPost(organisationModel);
    }

    return this.organisationService.apiOrganisationUpdateOrganisationPost(organisationModel);
  }

  /*saveImage(organisationModel: OrganisationModel): Observable<OrganisationModel> {
    if (organisationModel.id) {
      return this.organisationService.apiOrganisationAddOrganisationPost(organisationModel);
    }

    return this.organisationService.apiOrganisationSaveImagePost(organisationModel);
  }*/

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
    organisation['physicalAddress'] = [
      organisation.physicalAddressLine1,
      organisation.physicalAddressLine2,
      organisation.physicalAddressSuburb,
      organisation.physicalAddressCity,
      organisation.physicalAddressPostalCode].filter(Boolean).join(', ');

    organisation['postalAddress'] = [
      organisation.postalAddressLine1,
      organisation.postalAddressLine2,
      organisation.postalAddressSuburb,
      organisation.postalAddressCity,
      organisation.postalAddressPostalCode].filter(Boolean).join(', ');
  }
}
