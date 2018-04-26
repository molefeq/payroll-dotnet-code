import { Component, OnInit, Inject } from '@angular/core';
import { ServerValidationService } from '../../services/server-validation.service';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialog } from '@angular/material';
import { ServerErrorDailogComponent } from './server-error-dailog/server-error-dailog.component';

@Component({
  selector: 'app-app-http-server-error',
  templateUrl: './app-http-server-error.component.html',
  styleUrls: ['./app-http-server-error.component.scss']
})
export class AppHttpServerErrorComponent implements OnInit {

  constructor(private serverValidationService: ServerValidationService, public dialog: MatDialog) { }

  ngOnInit() {
    this.serverValidationService.serverErrors$.subscribe((data) => {
      if(!data){
        return;
      }

      this.openDialog(data);
    });
  }
  openDialog(data): void {
    let dialogRef = this.dialog.open(ServerErrorDailogComponent, {
      width: '250px',
      data: data
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }
}
