import { Component, OnInit, EventEmitter, Output, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription, Observable } from 'rxjs';
import { MatSort, MatPaginator, MatDialog, MatDialogRef } from '@angular/material';
import { CompanyDetailsService } from './company-details.service';
import { CompanyModel, OrganisationModel } from '../../shared/generated';
import { SessionStorageService } from 'ngx-store';
import { CompanyFormComponent } from './company-form/company-form.component';
import { dialogCloseResponse } from '../../shared/models/dialogCloseResponse';

@Component({
  selector: 'app-company-details',
  templateUrl: './company-details.component.html',
  styleUrls: ['./company-details.component.scss']
})
export class CompanyDetailsComponent implements OnInit {

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

  constructor(private companyDetailsService: CompanyDetailsService, private dialog: MatDialog, private router: Router) {
    this.displayedColumns = ['name', 'physicalAddress', 'faxNumber', 'emailAddress', 'contactNumber', 'actions'];
  }

  ngOnInit() {
    this.organisation = JSON.parse(sessionStorage.getItem('organisation'));
    this.subscriptions = this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);
    this.subscriptions.add(this.companyDetailsService.getCompanies(this.paginator, this.sort, this.searchEvent).subscribe(data => this.dataSource = data));
  }

  applyFilter(filterValue: string) {
    filterValue = filterValue.trim(); // Remove whitespace
    filterValue = filterValue.toLowerCase(); // MatTableDataSource defaults to lowercase matches

    this.searchText = filterValue;
    this.searchEvent.emit(this.searchText);
    this.paginator.pageIndex = 0;
  }

  addCompany() {
    let dialogRef = this.dialog.open(CompanyFormComponent, this.CompanyModalOptions(null));

    this.closeModal(dialogRef);
  }

  editCompany(company: CompanyModel) {
    let dialogRef = this.dialog.open(CompanyFormComponent, this.CompanyModalOptions(company));

    this.closeModal(dialogRef);
  }

  viewCompany(company: CompanyModel) {
    this.router.navigate(['/employees', company.id]);
  }

  ngOnDestroy() {
    this.subscriptions.unsubscribe();
  }

  refreshCompanies() {
    this.searchEvent.emit(this.searchText);
  }

  closeModal(dialogRef: MatDialogRef<CompanyFormComponent, any>) {
    dialogRef.afterClosed().subscribe((result: dialogCloseResponse) => {
      if (result && result.dataSaved) {
        this.refreshCompanies();
      }
    });
  }

  CompanyModalOptions(company: CompanyModel): any {
    return {
      height: '100%',
      maxHeight: '800px',
      minHeight: '600px',
      width: '580px',
      data: company,
      disableClose: true
    };
  }

}
