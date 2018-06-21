import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { MatTableDataSource, MatSort, MatPaginator } from '@angular/material';
import { RoleService, PageData } from '../../../../shared/generated';
import { merge } from 'rxjs/observable/merge';
import { startWith, switchMap, map, catchError } from 'rxjs/operators';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';

@Component({
  selector: 'app-roles-details',
  templateUrl: './roles-details.component.html',
  styleUrls: ['./roles-details.component.scss']
})
export class RolesDetailsComponent implements AfterViewInit {
  displayedColumns = [];
  dataSource = new MatTableDataSource();

  resultsLength = 0;
  isLoadingResults = false;

  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(private roleService: RoleService) {
    this.displayedColumns = ['name', 'code'];
    console.log(this.displayedColumns);
  }

  ngAfterViewInit() {
    this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);

    merge(this.sort.sortChange, this.paginator.page)
      .pipe(
        startWith({}),
        switchMap(() => {
          console.log({
            searchText: "",
            pageData: {
              includeAllData: false,
              take: this.paginator.pageSize,
              skip: this.paginator.pageSize * (this.paginator.pageIndex),
              sortOrder: this.sort.direction == 'asc' ? PageData.SortOrderEnum.NUMBER_1 : PageData.SortOrderEnum.NUMBER_2,
              sortColumn: this.sort.active
            }
          });
          this.isLoadingResults = true;

          return this.roleService.apiRoleGetRolesPost(
            {
              searchText: "",
              pageData: {
                includeAllData: false,
                take: this.paginator.pageSize,
                skip: this.paginator.pageSize * (this.paginator.pageIndex),
                sortOrder: this.sort.direction == 'asc' ? PageData.SortOrderEnum.NUMBER_1 : PageData.SortOrderEnum.NUMBER_2,
                sortColumn: this.sort.active
              }
            });
        }),
        map(data => {
          // Flip flag to show that loading has finished.
          this.isLoadingResults = false;
          this.resultsLength = data.totalItems;

          return data.items;
        }),
        catchError(() => {
          this.isLoadingResults = false;
          return Observable.of([]);
        })
      ).subscribe(data => this.dataSource.data = data);


    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  applyFilter(filterValue: string) {
    filterValue = filterValue.trim(); // Remove whitespace
    filterValue = filterValue.toLowerCase(); // MatTableDataSource defaults to lowercase matches
    this.dataSource.filter = filterValue;
  }

}