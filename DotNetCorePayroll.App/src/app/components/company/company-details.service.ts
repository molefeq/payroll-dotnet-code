import { Injectable, EventEmitter } from '@angular/core';
import { CompanyService, CompanyModel, PageData } from '../../shared/generated';
import { BehaviorSubject, Observable } from 'rxjs';
import { MatPaginator, MatSort } from '@angular/material';
import { merge } from 'rxjs/observable/merge';
import { startWith, switchMap, map, catchError, finalize } from 'rxjs/operators';


@Injectable()
export class CompanyDetailsService {
  private _isBusy$: BehaviorSubject<boolean> = new BehaviorSubject(false);
  private _totalCompanies$: BehaviorSubject<number> = new BehaviorSubject(0);
  private _company: CompanyModel = null;

  constructor(private companyService: CompanyService) { }

  getCompanies(paginator: MatPaginator, sort: MatSort, searchEvent: EventEmitter<string>): Observable<CompanyModel[]> {
    this._isBusy$.next(true);

    return merge(sort.sortChange, paginator.page, searchEvent)
      .pipe(
        startWith({}),
        switchMap((event) => {
          const pageSize: number = paginator.pageSize ? paginator.pageSize : 5;
          const searchText = typeof event === 'string' ? event : null;

          return this.companyService.apiCompanyGetCompaniesPost(
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
          this._totalCompanies$.next(data.totalItems);

          data.items.forEach(item => this.setAddress(item));

          return data.items;
        }),
        catchError((): Observable<CompanyModel[]> => {
          this._isBusy$.next(false);

          return Observable.of([]);
        }),
        finalize(() => {
          this._isBusy$.next(false);
        })
      );
  }

  saveCompany(companyModel: CompanyModel): Observable<CompanyModel> {
    if (companyModel.id) {
      return this.companyService.apiCompanyAddCompanyPost(companyModel);
    }

    return this.companyService.apiCompanyUpdateCompanyPost(companyModel);
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

  get totalCompanies$(): Observable<number> {
    return this._totalCompanies$.asObservable();
  }

  set Company(company: CompanyModel) {
    if (!Boolean(company)) {
      this._company = null;
      sessionStorage.removeItem('company');
    }

    sessionStorage.setItem('company', JSON.stringify(company));
    this._company = company;
  }

  get Company(): CompanyModel {
    if (Boolean(this._company)) {
      return this._company;
    }

    if (Boolean(sessionStorage.getItem('company'))) {
      return JSON.parse(sessionStorage.getItem('company'));
    }

    return null;
  }

  setAddress(company: CompanyModel) {
    company['physicalAddress'] = [company.physicalAddressLine1,
    company.physicalAddressLine2,
    company.physicalAddressSuburb,
    company.physicalAddressCity,
    company.physicalAddressPostalCode].filter(Boolean).join(', ');

    company['postalAddress'] = [company.postalAddressLine1,
    company.postalAddressLine2,
    company.postalAddressSuburb,
    company.postalAddressCity,
    company.postalAddressPostalCode].filter(Boolean).join(', ');
  }
}
