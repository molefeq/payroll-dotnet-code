import { Component, OnInit, OnDestroy, Output, EventEmitter, ViewChild } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { AdminUserService } from '../admin-user.service';
import { MatDialog, MatSort, MatPaginator, MatDialogRef } from '@angular/material';
import { AccountModel } from '../../../../shared/generated';
import { UserFormComponent } from '../user-form/user-form.component';
import { dialogCloseResponse } from '../../../../shared/models/dialogCloseResponse';
import { Subscription, Subject } from 'rxjs';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.scss']
})
export class UserDetailsComponent implements OnInit, OnDestroy {
  displayedColumns = [];
  subscriptions: Subscription;
  searchText$ = new Subject<string>();
  searchText: string;

  totalUsers$ = this.adminUserService.totalUsers$;
  isBusy$: Observable<boolean> = this.adminUserService.isBusy$;

  @Output() searchEvent: EventEmitter<string> = new EventEmitter();
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  dataSource: AccountModel[] = [];

  constructor(private adminUserService: AdminUserService, private dialog: MatDialog) {
    this.displayedColumns = ['username', 'firstname', 'lastname', 'actions'];
  }

  ngOnInit() {
    this.subscriptions = this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);
    this.subscriptions.add(this.adminUserService.getUsers(this.paginator, this.sort, this.searchEvent)
      .subscribe(data => this.dataSource = data));

    this.subscriptions.add(this.searchText$.debounceTime(400).distinctUntilChanged().subscribe((searchText: string) => {
      this.searchText = searchText;
      this.paginator.pageIndex = 0;
      this.searchEvent.emit(searchText);
    }));
  }

  addUser() {
    const dialogRef = this.dialog.open(UserFormComponent, this.userModalOptions(null));

    this.closeModal(dialogRef);
  }

  editUser(user) {
    const dialogRef = this.dialog.open(UserFormComponent, this.userModalOptions(user));

    this.closeModal(dialogRef);
  }

  ngOnDestroy() {
    this.subscriptions.unsubscribe();
  }

  refreshUsers() {
    this.searchEvent.emit(this.searchText);
  }

  closeModal(dialogRef: MatDialogRef<UserFormComponent, any>) {
    dialogRef.afterClosed().subscribe((result: dialogCloseResponse) => {
      if (result && result.dataSaved) {
        this.refreshUsers();
      }
    });
  }

  userModalOptions(user: AccountModel): any {
    return {
      height: '650px',
      width: '400px',
      data: user,
      disableClose: true
    };
  }

}
