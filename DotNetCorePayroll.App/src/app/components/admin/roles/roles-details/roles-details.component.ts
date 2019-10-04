import { Component, OnInit, ViewChild, Output, EventEmitter, OnDestroy } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { RoleModel } from '../../../../shared/generated';
import { Observable } from 'rxjs/Observable';
import { RolesFormComponent } from '../roles-form/roles-form.component';
import { AdminRoleService } from '../admin-role.service';
import { Subscription, Subject } from 'rxjs';
import { dialogCloseResponse } from '../../../../shared/models/dialogCloseResponse';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';

@Component({
  selector: 'app-roles-details',
  templateUrl: './roles-details.component.html',
  styleUrls: ['./roles-details.component.scss']
})
export class RolesDetailsComponent implements OnInit, OnDestroy {
  displayedColumns = [];
  subscriptions: Subscription;
  searchText$ = new Subject<string>();
  searchText: string;

  totalRoles$ = this.adminRoleService.totalRoles$;
  isBusy$: Observable<boolean> = this.adminRoleService.isBusy$;

  @Output() searchEvent: EventEmitter<string> = new EventEmitter();
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  dataSource: RoleModel[] = [];

  constructor(private adminRoleService: AdminRoleService, private dialog: MatDialog) {
    this.displayedColumns = ['name', 'code', 'actions'];
  }

  ngOnInit() {
    this.subscriptions = this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);
    this.subscriptions.add(this.adminRoleService.getRoles(this.paginator, this.sort, this.searchEvent)
      .subscribe(data => this.dataSource = data));

    this.subscriptions.add(this.searchText$.pipe(
      debounceTime(400),
      distinctUntilChanged()
    ).subscribe((searchText: string) => {
      this.searchText = searchText;
      this.paginator.pageIndex = 0;
      this.searchEvent.emit(searchText);
    }));

  }

  addRole() {
    const dialogRef = this.dialog.open(RolesFormComponent, this.roleModalOptions(null));

    this.closeModal(dialogRef);
  }

  editRole(role) {
    const dialogRef = this.dialog.open(RolesFormComponent, this.roleModalOptions(role));

    this.closeModal(dialogRef);
  }

  ngOnDestroy() {
    this.subscriptions.unsubscribe();
  }

  refreshRoles() {
    this.searchEvent.emit(this.searchText);
  }

  closeModal(dialogRef: MatDialogRef<RolesFormComponent, any>) {
    dialogRef.afterClosed().subscribe((result: dialogCloseResponse) => {
      if (result && result.dataSaved) {
        this.refreshRoles();
      }
    });
  }

  roleModalOptions(role: RoleModel): any {
    return {
      height: '290px',
      width: '320px',
      data: role,
      disableClose: true
    };
  }

}
