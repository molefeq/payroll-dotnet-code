import { Injectable, EventEmitter } from '@angular/core';
import {
  CompanyService, CompanyModel, PageData,
  CompanyPayrollSettingModel,
  CompanyBankDetailModel,
  CompanyAddressModel
} from '../../shared/generated';
import { BehaviorSubject, Observable } from 'rxjs';
import { MatPaginator, MatSort } from '@angular/material';
import { merge } from 'rxjs/observable/merge';
import { startWith, switchMap, map, catchError, finalize, delay } from 'rxjs/operators';


@Injectable()
export class CompanyDetailsService {
  private _isBusy$: BehaviorSubject<boolean> = new BehaviorSubject(false);
  private _totalCompanies$: BehaviorSubject<number> = new BehaviorSubject(0);
  private _company: CompanyModel = null;

  constructor(private companyService: CompanyService) { }

  getAllCompanies(searchEvent: EventEmitter<string>): Observable<CompanyModel[]> {
    const that = this;

    return searchEvent.pipe(
      startWith(null),
      delay(0),
      switchMap((event) => {
        that._isBusy$.next(true);
        const searchText = typeof event === 'string' ? event : null;

        return that.companyService.getCompanies(
          {
            searchText: searchText,
            pageData: {
              includeAllData: false,
              sortOrder: PageData.SortOrderEnum.NUMBER_1,
              sortColumn: 'name'
            }
          });
      }),
      map(data => {
        that._isBusy$.next(false);
        data.items.forEach(item => that.setAddress(item));

        return data.items;
      }),
      catchError((): Observable<CompanyModel[]> => {
        that._isBusy$.next(false);

        return Observable.of([]);
      })
    );
  }

  getCompanies(paginator: MatPaginator, sort: MatSort, searchEvent: EventEmitter<string>): Observable<CompanyModel[]> {
    this._isBusy$.next(true);

    return merge(sort.sortChange, paginator.page, searchEvent)
      .pipe(
        startWith(null),
        switchMap((event) => {
          const pageSize: number = paginator.pageSize ? paginator.pageSize : 5;
          const searchText = typeof event === 'string' ? event : null;

          return this.companyService.getCompanies(
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

  getCompaniesReferenceData(organisationId): Observable<CompanyModel[]> {
    return this.companyService.getCompanies(
      {
        searchText: '',
        organisationId: organisationId,
        pageData: {
          includeAllData: true,
          sortOrder: PageData.SortOrderEnum.NUMBER_1,
          sortColumn: 'Name'
        }
      }).pipe(

        map(data => {
          return data.items;
        }),
        catchError((): Observable<CompanyModel[]> => {
          return Observable.of([]);
        }),
      );
  }

  saveCompany(companyModel: CompanyModel): Observable<CompanyModel> {
    if (companyModel.id) {
      return this.companyService.addCompany(companyModel);
    }

    return this.companyService.updateCompany(companyModel);
  }

  saveContactDetails(CompanyAddressModel: CompanyAddressModel): Observable<CompanyModel> {
    return this.companyService.saveCompanyAddress(CompanyAddressModel);
  }

  /* savePayrollSettings(companyPayrollSettingModel: CompanyPayrollSettingModel): Observable<CompanyModel> {
    return this.companyService.saveCompanyAddress(companyPayrollSettingModel);
  }

  saveBankingDetails(companyBankDetailModel: CompanyBankDetailModel): Observable<CompanyModel> {
    return this.companyService.apiCompanySaveBankingDetailsPost(companyBankDetailModel);
  }

 saveImage(organisationModel: OrganisationModel): Observable<OrganisationModel> {
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
    if (Boolean(company.address) && Boolean(company.address.physicalAddress)) {
      company['physicalAddressText'] = [
        company.address.physicalAddress.line1,
        company.address.physicalAddress.line2,
        company.address.physicalAddress.suburb,
        company.address.physicalAddress.city,
        company.address.physicalAddress.postalCode].filter(Boolean).join(', ');
    }

    if (Boolean(company.address) && Boolean(company.address.postalAddress)) {
      company['physicalAddressText'] = [
        company.address.postalAddress.line1,
        company.address.postalAddress.line2,
        company.address.postalAddress.suburb,
        company.address.postalAddress.city,
        company.address.postalAddress.postalCode].filter(Boolean).join(', ');
    }
  }
}
