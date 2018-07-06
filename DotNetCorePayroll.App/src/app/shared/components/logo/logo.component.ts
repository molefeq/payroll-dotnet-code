import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FileUploader } from 'ng2-file-upload';
import { logoModel } from '../../models/logoModel';

@Component({
  selector: 'app-logo',
  templateUrl: './logo.component.html',
  styleUrls: ['./logo.component.scss']
})
export class LogoComponent implements OnInit {
  @Input() apiUrl: string;
  @Input() logoUrl: string;
  @Output() logoChanged: EventEmitter<logoModel> = new EventEmitter<logoModel>();

  public fileUploader: FileUploader;

  constructor() { }

  ngOnInit() {
    this.fileUploader = new FileUploader({
      url: this.apiUrl,
      autoUpload: true,
    });
    
    this.fileUploader.onSuccessItem = (item, response, status, headers) => {
      const jResponse = JSON.parse(response);
      const model: logoModel = {
        logoUrl: jResponse['imageUrl'],
        logoFilename: jResponse['filename']
      }

      this.logoUrl = model.logoUrl;
      this.logoChanged.emit(model);
    };
  }

}
