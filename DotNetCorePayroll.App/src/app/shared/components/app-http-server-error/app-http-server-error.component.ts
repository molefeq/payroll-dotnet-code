import { Component, OnInit, Inject } from '@angular/core';
import { ServerValidationService } from '../../services/server-validation.service';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialog } from '@angular/material';
import { ServerErrorDailogComponent } from './server-error-dailog/server-error-dailog.component';
import { Subscription } from 'rxjs/Subscription';

@Component({
  selector: 'app-app-http-server-error',
  templateUrl: './app-http-server-error.component.html',
  styleUrls: ['./app-http-server-error.component.scss']
})
export class AppHttpServerErrorComponent implements OnInit {

  subscriptions: Subscription;
  constructor(private serverValidationService: ServerValidationService, public dialog: MatDialog) { }

  ngOnInit() {
    this.subscriptions = new Subscription();
    this.subscriptions.add(this.serverValidationService.serverErrors$.subscribe((data) => {
      if (!data) {
        return;
      }

      this.openDialog(data);
    }));
  }

  openDialog(data): void {
    let dialogRef = this.dialog.open(ServerErrorDailogComponent, {
      width:'250px',
      height:'250px',
      data: data,
      disableClose:true
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  };

  ngOnDestroy() {
    this.subscriptions.unsubscribe();
  };
}
