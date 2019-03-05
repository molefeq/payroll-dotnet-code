import { Injectable, EventEmitter } from '@angular/core';
import {
  EmployeeModel, EmployeeService, PageData,
  EmployeeBankDetailModel, EmployeeNextOfKinDetailModel,
  EmployeeContactDetailModel
} from '../../shared/generated';
import { BehaviorSubject, Observable } from 'rxjs';
import { MatPaginator, MatSort } from '@angular/material';
import { merge } from 'rxjs/observable/merge';
import { startWith, switchMap, map, catchError, finalize } from 'rxjs/operators';

@Injectable()
export class EmployeeDetailsService {
  private _isBusy$: BehaviorSubject<boolean> = new BehaviorSubject(false);
  private _totalEmployees$: BehaviorSubject<number> = new BehaviorSubject(0);
  private _employee: EmployeeModel = null;

  constructor(private employeeService: EmployeeService) { }

  getEmployees(paginator: MatPaginator, sort: MatSort, searchEvent: EventEmitter<string>): Observable<EmployeeModel[]> {
    this._isBusy$.next(true);

    return merge(sort.sortChange, paginator.page, searchEvent)
      .pipe(
        startWith({}),
        switchMap((event) => {
          const pageSize: number = paginator.pageSize ? paginator.pageSize : 5;
          const searchText = typeof event === 'string' ? event : null;

          return this.employeeService.getEmployees(
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
          this._totalEmployees$.next(data.totalItems);

          data.items.forEach(item => this.setAddress(item));

          return data.items;
        }),
        catchError((): Observable<EmployeeModel[]> => {
          this._isBusy$.next(false);

          return Observable.of([]);
        }),
        finalize(() => {
          this._isBusy$.next(false);
        })
      );
  }

  saveEmployee(employeeModel: EmployeeModel): Observable<EmployeeModel> {
    if (employeeModel.id) {
      return this.employeeService.addEmployee(employeeModel);
    }

    return this.employeeService.updateEmployee(employeeModel);
  }

  saveContactDetails(companyContactDetailModel: EmployeeContactDetailModel): Observable<EmployeeModel> {
    return this.employeeService.saveEmployeeContactDetails(companyContactDetailModel);
  }

  saveNextOfKinDetails(employeeNextOfKinDetailModel: EmployeeNextOfKinDetailModel): Observable<EmployeeModel> {
    return this.employeeService.saveEmployeeNextOfKin(employeeNextOfKinDetailModel);
  }

  saveBankingDetails(employeeBankDetailModel: EmployeeBankDetailModel): Observable<EmployeeModel> {
    return this.employeeService.saveEmployeeBankingDetails(employeeBankDetailModel);
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

  get totalEmployees$(): Observable<number> {
    return this._totalEmployees$.asObservable();
  }

  set Employee(employee: EmployeeModel) {
    if (!Boolean(employee)) {
      this._employee = null;
      sessionStorage.removeItem('employee');
    }

    sessionStorage.setItem('employee', JSON.stringify(employee));
    this._employee = employee;
  }

  get Employee(): EmployeeModel {
    if (Boolean(this._employee)) {
      return this._employee;
    }

    if (Boolean(sessionStorage.getItem('employee'))) {
      return JSON.parse(sessionStorage.getItem('employee'));
    }

    return null;
  }

  setAddress(employee: EmployeeModel) {
    employee['name'] = [employee.title, employee.firstName, employee.lastName].filter(Boolean).join(', ');
    employee['physicalAddress'] = [employee.contactDetail.physicalAddressLine1,
    employee.contactDetail.physicalAddressLine2,
    employee.contactDetail.physicalAddressSuburb,
    employee.contactDetail.physicalAddressCity,
    employee.contactDetail.physicalAddressPostalCode].filter(Boolean).join(', ');

    employee['postalAddress'] = [employee.contactDetail.postalAddressLine1,
    employee.contactDetail.postalAddressLine2,
    employee.contactDetail.postalAddressSuburb,
    employee.contactDetail.postalAddressCity,
    employee.contactDetail.postalAddressPostalCode].filter(Boolean).join(', ');
  }
}
