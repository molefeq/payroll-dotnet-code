import { Component, OnInit, EventEmitter, Output, ViewChild, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription, Observable } from 'rxjs';
import { MatSort, MatPaginator } from '@angular/material';
import { CompanyDetailsService } from './company-details.service';
import { CompanyModel, OrganisationModel } from '../../shared/generated';
import { OrganisationDetailsService } from '../organisation/organisation-details.service';

@Component({
  selector: 'app-company-details',
  templateUrl: './company-details.component.html',
  styleUrls: ['./company-details.component.scss']
})
export class CompanyDetailsComponent implements OnInit, OnDestroy {

  displayedColumns = [];
  subscriptions: Subscription;
  searchText: string;
  organisation: OrganisationModel;

  totalCompanies$ = this.companyDetailsService.totalCompanies$;
  isBusy$: Observable<boolean> = this.companyDetailsService.isBusy$;

  @Output() searchEvent: EventEmitter<string> = new EventEmitter();
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  dataSource: CompanyModel[] = [];

  constructor(private organisationDetailsService: OrganisationDetailsService,
    private companyDetailsService: CompanyDetailsService,
    private router: Router) {
    this.displayedColumns = ['name', 'physicalAddress', 'emailAddress', 'contactNumber', 'employees', 'actions'];
  }

  ngOnInit() {
    this.organisation = this.organisationDetailsService.Organisation;
    this.companyDetailsService.Company = null;
    this.subscriptions = this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);
    this.subscriptions.add(this.companyDetailsService.getCompanies(this.paginator, this.sort, this.searchEvent)
      .subscribe(data => this.dataSource = data));
  }

  applyFilter(filterValue: string) {
    filterValue = filterValue.trim(); // Remove whitespace
    filterValue = filterValue.toLowerCase(); // MatTableDataSource defaults to lowercase matches

    this.searchText = filterValue;
    this.searchEvent.emit(this.searchText);
    this.paginator.pageIndex = 0;
  }

  addCompany() {
    this.router.navigate(['/company']);
  }

  editCompany(company: CompanyModel) {
    this.companyDetailsService.Company = company;
    this.router.navigate(['/company', company.id]);
  }

  viewCompany(company: CompanyModel) {
    this.companyDetailsService.Company = company;
    this.router.navigate(['/employees', company.id]);
  }

  ngOnDestroy() {
    this.subscriptions.unsubscribe();
  }

  refreshCompanies() {
    this.searchEvent.emit(this.searchText);
  }
}
