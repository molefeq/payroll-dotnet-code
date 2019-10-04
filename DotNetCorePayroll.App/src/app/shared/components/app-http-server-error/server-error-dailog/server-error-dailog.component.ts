import { Component, Inject } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';


@Component({
  selector: 'app-server-error-dailog',
  templateUrl: './server-error-dailog.component.html',
  styleUrls: ['./server-error-dailog.component.scss']
})
export class ServerErrorDailogComponent {
  constructor(
    public dialogRef: MatDialogRef<ServerErrorDailogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) { }

  onNoClick(): void {
    this.dialogRef.close();
  }


}
