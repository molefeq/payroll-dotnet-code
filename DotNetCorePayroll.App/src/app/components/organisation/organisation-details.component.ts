import { Component, OnInit, EventEmitter, Output, ViewChild, OnDestroy } from '@angular/core';
import { Subscription, Observable } from 'rxjs';
import { MatSort, MatPaginator, MatDialog, MatDialogRef } from '@angular/material';
import { OrganisationModel } from '../../shared/generated';
import { dialogCloseResponse } from '../../shared/models/dialogCloseResponse';
import { OrganisationFormComponent } from './organisation-form/organisation-form.component';
import { OrganisationDetailsService } from './organisation-details.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-organisation-details',
  templateUrl: './organisation-details.component.html',
  styleUrls: ['./organisation-details.component.scss']
})
export class OrganisationDetailsComponent implements OnInit, OnDestroy {

  displayedColumns = [];
  subscriptions: Subscription;
  searchText: string;

  totalOrganisations$ = this.organisationDetailsService.totalOrganisations$;
  isBusy$: Observable<boolean> = this.organisationDetailsService.isBusy$;

  @Output() searchEvent: EventEmitter<string> = new EventEmitter();
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  dataSource: OrganisationModel[] = [];

  constructor(private organisationDetailsService: OrganisationDetailsService, private dialog: MatDialog, private router: Router) {
    this.displayedColumns = ['name', 'description', 'emailAddress', 'companies', 'actions'];
  }

  ngOnInit() {
    sessionStorage.getItem('organisation');
    this.subscriptions = this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);
    this.subscriptions.add(this.organisationDetailsService.getOrganisations(this.paginator, this.sort, this.searchEvent)
      .subscribe(data => this.dataSource = data));
  }

  applyFilter(filterValue: string) {
    filterValue = filterValue.trim(); // Remove whitespace
    filterValue = filterValue.toLowerCase(); // MatTableDataSource defaults to lowercase matches

    this.searchText = filterValue;
    this.searchEvent.emit(this.searchText);
    this.paginator.pageIndex = 0;
  }

  addOrganisation() {
    this.router.navigate(['/organisation']);
   // const dialogRef = this.dialog.open(OrganisationFormComponent, this.organisationModalOptions(null));

    // this.closeModal(dialogRef);
  }

  editOrganisation(organisation: OrganisationModel) {
    this.organisationDetailsService.Organisation = organisation;
    this.router.navigate(['/organisation', organisation.id]);

   // const dialogRef = this.dialog.open(OrganisationFormComponent, this.organisationModalOptions(organisation));

   // this.closeModal(dialogRef);
  }

  viewOrganisation(organisation: OrganisationModel) {
    sessionStorage.setItem('organisation', JSON.stringify(organisation));
    this.router.navigate(['/companies', organisation.id]);
  }

  ngOnDestroy() {
    this.subscriptions.unsubscribe();
  }

  refreshOrganisations() {
    this.searchEvent.emit(this.searchText);
  }

  closeModal(dialogRef: MatDialogRef<OrganisationFormComponent, any>) {
    dialogRef.afterClosed().subscribe((result: dialogCloseResponse) => {
      if (result && result.dataSaved) {
        this.refreshOrganisations();
      }
    });
  }

  organisationModalOptions(organisation: OrganisationModel): any {
    return {
      height: '100%',
      maxHeight: '800px',
      minHeight: '600px',
      width: '580px',
      data: organisation,
      disableClose: true
    };
  }

}
