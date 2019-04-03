import { Component, OnInit, EventEmitter, ViewChild, Output, OnDestroy } from '@angular/core';
import { Subscription, Observable } from 'rxjs';
import { CompanyModel, EmployeeModel } from '../../../shared/generated';
import { CompanyDetailsService } from '../../company/company-details.service';
import { EmployeeDetailsService } from '../employee-details.service';
import { Router } from '@angular/router';
import { MatSort, MatPaginator } from '@angular/material';

@Component({
  selector: 'app-employee-details',
  templateUrl: './employee-details.component.html',
  styleUrls: ['./employee-details.component.scss']
})
export class EmployeeDetailsComponent implements OnInit, OnDestroy {

  displayedColumns = [];
  subscriptions: Subscription;
  searchText: string;
  company: CompanyModel;

  totalEmployees$ = this.employeeDetailsSerivce.totalEmployees$;
  isBusy$: Observable<boolean> = this.employeeDetailsSerivce.isBusy$;
  @Output() searchEvent: EventEmitter<string> = new EventEmitter();
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  dataSource: EmployeeModel[] = [];

  constructor(private companyDetailsService: CompanyDetailsService,
    private employeeDetailsSerivce: EmployeeDetailsService,
    private router: Router) {
    this.displayedColumns = ['name', 'physicalAddress', 'emailAddress', 'actions'];
  }

  ngOnInit() {
    this.company = this.companyDetailsService.Company;
    this.employeeDetailsSerivce.Employee = null;
    this.subscriptions = this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);
    this.subscriptions.add(this.employeeDetailsSerivce.getEmployees(this.paginator, this.sort, this.searchEvent,  this.company.id)
      .subscribe(data => this.dataSource = data));
  }

  applyFilter(filterValue: string) {
    filterValue = filterValue.trim(); // Remove whitespace
    filterValue = filterValue.toLowerCase(); // MatTableDataSource defaults to lowercase matches

    this.searchText = filterValue;
    this.searchEvent.emit(this.searchText);
    this.paginator.pageIndex = 0;
  }

  addEmployee() {
    this.router.navigate(['/employee']);
  }

  editEmployee(employee: EmployeeModel) {
    this.employeeDetailsSerivce.Employee = employee;
    this.router.navigate(['/employee', employee.id]);
  }

  ngOnDestroy() {
    this.subscriptions.unsubscribe();
  }

  refreshEmployees() {
    this.searchEvent.emit(this.searchText);
  }

}
