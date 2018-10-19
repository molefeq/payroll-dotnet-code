import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { DropdownDataSource } from '../../models/dropdownDataSource';

@Component({
  selector: 'app-app-async-dropdownlist',
  templateUrl: './app-async-dropdownlist.component.html',
  styleUrls: ['./app-async-dropdownlist.component.scss']
})
export class AppAsyncDropdownlistComponent implements OnInit {
  @Input() isControlValid: boolean;
  @Input() placeholder: string;
  @Input() dropDownFormControl: FormControl;
  @Input() dropDownFormControlName: string;
  @Input() messages: any;
  @Input() dataSource: DropdownDataSource;

  constructor() { }

  ngOnInit() {
  }

}
