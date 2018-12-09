import { Component, OnInit, EventEmitter, Output, AfterViewInit } from '@angular/core';
import { OrganisationModel } from '../../shared/generated';
import { OrganisationDetailsService } from './organisation-details.service';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';

@Component({
  selector: 'app-organisation-details',
  templateUrl: './organisation-details.component.html',
  styleUrls: ['./organisation-details.component.scss']
})
export class OrganisationDetailsComponent implements OnInit {

  searchText: string;
  @Output() searchEvent: EventEmitter<string> = new EventEmitter();
  isBusy$: Observable<boolean> = this.organisationDetailsService.isBusy$;
  totalOrganisations$: Observable<number> = this.organisationDetailsService.totalOrganisations$;
  dataSource$: Observable<OrganisationModel[]>;

  constructor(private organisationDetailsService: OrganisationDetailsService,
    private router: Router) {
  }

  ngOnInit() {
    this.organisationDetailsService.Organisation = null;
    this.dataSource$ = this.organisationDetailsService.getAllOrganisations(this.searchEvent);
  }

  applyFilter(filterValue: string) {
    this.searchText = filterValue.trim().toLowerCase();
    this.searchEvent.emit(this.searchText);
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
}
