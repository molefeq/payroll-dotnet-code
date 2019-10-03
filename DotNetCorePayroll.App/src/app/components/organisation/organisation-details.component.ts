import { Component, OnInit, EventEmitter, Output, AfterViewInit, ViewChild, OnDestroy } from '@angular/core';
import { OrganisationModel } from '../../shared/generated';
import { OrganisationDetailsService } from './organisation-details.service';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { Subscription } from 'rxjs';
import { MatPaginator, MatSort } from '@angular/material';

@Component({
  selector: 'app-organisation-details',
  templateUrl: './organisation-details.component.html',
  styleUrls: ['./organisation-details.component.scss']
})
export class OrganisationDetailsComponent implements OnInit, OnDestroy {

  displayedColumns = [];
  subscriptions: Subscription;
  searchText: string;

  @Output() searchEvent: EventEmitter<string> = new EventEmitter();
  isBusy$: Observable<boolean> = this.organisationDetailsService.isBusy$;
  totalOrganisations$: Observable<number> = this.organisationDetailsService.totalOrganisations$;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  dataSource: OrganisationModel[] = [];

  constructor(private organisationDetailsService: OrganisationDetailsService,
    private router: Router) {
    this.displayedColumns = ['name', 'physicalAddress', 'emailAddress', 'actions'];
  }

  ngOnInit() {
    this.organisationDetailsService.Organisation = null;
    this.subscriptions = this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);
    this.subscriptions.add(this.organisationDetailsService.getOrganisations(this.paginator, this.sort, this.searchEvent)
      .subscribe(data => this.dataSource = data));
  }

  applyFilter(filterValue: string) {
    this.searchText = filterValue.trim().toLowerCase();
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

  refreshOrganisations() {
    this.searchEvent.emit(this.searchText);
  }

  ngOnDestroy() {
    this.subscriptions.unsubscribe();
  }
}
