import { Component, OnInit, EventEmitter, Output, ViewChild, OnDestroy } from '@angular/core';
import { Subscription, Observable } from 'rxjs';
import { MatSort, MatPaginator } from '@angular/material';
import { OrganisationModel } from '../../shared/generated';
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

  constructor(private organisationDetailsService: OrganisationDetailsService, private router: Router) {
    this.displayedColumns = ['name', 'description', 'emailAddress', 'companies', 'actions'];
  }

  ngOnInit() {
    this.organisationDetailsService.Organisation = null;
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
  }

  editOrganisation(organisation: OrganisationModel) {
    this.organisationDetailsService.Organisation = organisation;
    this.router.navigate(['/organisation', organisation.id]);
  }

  viewOrganisation(organisation: OrganisationModel) {
    this.organisationDetailsService.Organisation = organisation;
    this.router.navigate(['/companies', organisation.id]);
  }

  ngOnDestroy() {
    this.subscriptions.unsubscribe();
  }

  refreshOrganisations() {
    this.searchEvent.emit(this.searchText);
  }
}
