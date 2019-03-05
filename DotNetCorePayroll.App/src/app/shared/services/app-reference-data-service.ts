import { Injectable } from '@angular/core';
import {
    ReferenceDataModel, OrganisationService,
    PageData, ResultOrganisationModel,
    CompanyModel, ResultRoleModel, RoleService
} from '../generated';
import { DropdownDataSource } from '../models/dropdownDataSource';
import { Observable, BehaviorSubject } from 'rxjs';
import {
    catchError, map, startWith,
    switchMap, tap, distinctUntilChanged, debounceTime
} from 'rxjs/operators';
import { CompanyDetailsService } from '../../components/company/company-details.service';

@Injectable()
export class AppReferenceDataService {
    private countries: Array<ReferenceDataModel>;
    private provinces: Array<ReferenceDataModel>;
    private _organisations: DropdownDataSource =
        {
            data$: this.getOrganisations(),
            inprogess$: new BehaviorSubject(false)
        };
    private _companies: DropdownDataSource =
        {
            data$: Observable.of([]),
            inprogess$: new BehaviorSubject(false)
        };
    private _roles: DropdownDataSource =
        {
            data$: this.getRoles(),
            inprogess$: new BehaviorSubject(false)
        };

    constructor(private organisationService: OrganisationService,
        private companyDetailsService: CompanyDetailsService,
        private roleService: RoleService) { }

    public setCountries(countries) {
        this.countries = countries;
    }

    public getCountries(): Array<ReferenceDataModel> {
        return this.countries;
    }

    public setProvinces(provinces) {
        this.provinces = provinces;
    }

    public getProvinces(): Array<ReferenceDataModel> {
        return this.provinces;
    }

    public organisationData(): DropdownDataSource {
        return this._organisations;
    }

    public rolesData(): DropdownDataSource {
        return this._roles;
    }

    public companyData(initialOrganisationId, valueChanges: Observable<any>): DropdownDataSource {
        this._companies.data$ = this.getOrganisationCompanies(initialOrganisationId, valueChanges);

        return this._companies;
    }

    getOrganisations(): Observable<ReferenceDataModel[]> {
        return this.organisationService.getOrganisations(
            {
                searchText: '',
                pageData: {
                    includeAllData: true,
                    sortOrder: PageData.SortOrderEnum.NUMBER_1,
                    sortColumn: 'name'
                }
            }).pipe(
                tap(() => {
                    this._organisations.inprogess$.next(true);
                }),
                map((response: ResultOrganisationModel) => {
                    this._organisations.inprogess$.next(false);
                    return response.items.map(item => <ReferenceDataModel>{ id: item.id, name: item.name });
                }),
                catchError((): Observable<ReferenceDataModel[]> => {
                    this._organisations.inprogess$.next(false);
                    return Observable.of([]);
                })
            );
    }

    getOrganisationCompanies(initialOrganisationId, valueChanges: Observable<any>): Observable<ReferenceDataModel[]> {

        return valueChanges.pipe(
            startWith(initialOrganisationId),
            distinctUntilChanged(),
            // tap(//how laoding spinner)
            debounceTime(150),
            switchMap((value) => {
                if (!Boolean(value)) {
                    return Observable.of([]);
                }
                return this.companyDetailsService.getCompaniesReferenceData(value).pipe(
                    tap(() => {
                        this._companies.inprogess$.next(true);
                    }),
                    map((response: CompanyModel[]) => {
                        this._companies.inprogess$.next(false);
                        return response.map(item => <ReferenceDataModel>{ id: 1, name: item.name });
                    })
                );
            })
        );
    }

    getRoles(): Observable<ReferenceDataModel[]> {
        return this.roleService.getRoles(
            {
                searchText: '',
                pageData: {
                    includeAllData: true,
                    sortOrder: PageData.SortOrderEnum.NUMBER_1,
                    sortColumn: 'Name'
                }
            }).pipe(
                tap(() => {
                    this._roles.inprogess$.next(true);
                }),
                map((response: ResultRoleModel) => {
                    this._roles.inprogess$.next(false);
                    return response.items.map(item => <ReferenceDataModel>{ id: item.id, name: item.name });
                }),
                catchError((): Observable<ReferenceDataModel[]> => {
                    this._roles.inprogess$.next(false);
                    return Observable.of([]);
                })
            );
    }

}
