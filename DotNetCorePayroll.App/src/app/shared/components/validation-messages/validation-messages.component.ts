import { Component, OnInit, Input } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-validation-messages',
  templateUrl: './validation-messages.component.html',
  styleUrls: ['./validation-messages.component.scss']
})
export class ValidationMessagesComponent {

  @Input() vmcontrol: FormControl;
  @Input() messages: any;
  @Input() placeholder: string;
  @Input() type: String;

  constructor() {
  }

  errorsAsArray() {
    console.log(this.placeholder);
    console.log(this.type);

    for (let x in this.vmcontrol.errors) {
      console.log(x);
      console.log(this.messages[x]);

      if (this.vmcontrol.errors[x]) return [x];
    }
  }
}
