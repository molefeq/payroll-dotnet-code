import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { CompanyDetailsService } from './company-details.service';
import { CompanyModel, OrganisationModel } from '../../shared/generated';
import { OrganisationDetailsService } from '../organisation/organisation-details.service';

@Component({
  selector: 'app-company-details',
  templateUrl: './company-details.component.html',
  styleUrls: ['./company-details.component.scss']
})
export class CompanyDetailsComponent implements OnInit {

  searchText: string;
  organisation: OrganisationModel;
  isBusy$: Observable<boolean> = this.companyDetailsService.isBusy$;
  @Output() searchEvent: EventEmitter<string> = new EventEmitter();
  dataSource$ = this.companyDetailsService.getAllCompanies(this.searchEvent);

  constructor(private organisationDetailsService: OrganisationDetailsService,
    private companyDetailsService: CompanyDetailsService,
    private router: Router) {
  }

  ngOnInit() {
    this.organisation = this.organisationDetailsService.Organisation;
    this.companyDetailsService.Company = null;
  }

  applyFilter(filterValue: string) {
    this.searchText = filterValue.trim().toLowerCase();
    this.searchEvent.emit(this.searchText);
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

  refreshCompanies() {
    this.searchEvent.emit(this.searchText);
  }
}
