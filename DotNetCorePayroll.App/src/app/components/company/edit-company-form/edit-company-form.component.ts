import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-edit-company-form',
  templateUrl: './edit-company-form.component.html',
  styleUrls: ['./edit-company-form.component.scss']
})
export class EditCompanyFormComponent implements OnInit {

  IsNew: boolean = true;

  constructor() { }

  ngOnInit() {
  }

}
