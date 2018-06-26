import { Component, OnInit, ViewChild, Output, EventEmitter } from '@angular/core';
import { MatSort, MatPaginator, MatDialog } from '@angular/material';
import { RoleModel } from '../../../../shared/generated';
import { Observable } from 'rxjs/Observable';
import { RolesFormComponent } from '../roles-form/roles-form.component';
import { AdminRoleService } from '../admin-role.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-roles-details',
  templateUrl: './roles-details.component.html',
  styleUrls: ['./roles-details.component.scss']
})
export class RolesDetailsComponent implements OnInit {
  displayedColumns = [];
  subscriptions: Subscription;

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
    this.subscriptions.add(this.adminRoleService.getRoles(this.paginator, this.sort, this.searchEvent).subscribe(data => this.dataSource = data));
  }

  applyFilter(filterValue: string) {
    filterValue = filterValue.trim(); // Remove whitespace
    filterValue = filterValue.toLowerCase(); // MatTableDataSource defaults to lowercase matches

    this.searchEvent.emit(filterValue);
    this.paginator.pageIndex = 0;
  }

  addRole() {
    let dialogRef = this.dialog.open(RolesFormComponent, {
      width: '250px',
      height: '250px',
      data: {},
      disableClose: true
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }

  editRole(role) {
    console.log(role);
  }

  ngOnDestroy() {
    this.subscriptions.unsubscribe();
  }

}