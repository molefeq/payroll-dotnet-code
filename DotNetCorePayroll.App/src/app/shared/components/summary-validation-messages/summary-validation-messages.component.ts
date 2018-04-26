import { Component, OnInit, Input } from '@angular/core';
import { ServerValidationService } from '../../services/server-validation.service';
import { messageType } from '../../models/messageType';
import { Subscription } from 'rxjs/Subscription';
import { FormGroup } from '@angular/forms';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import "rxjs/add/operator/map";

@Component({
  selector: 'app-summary-validation-messages',
  templateUrl: './summary-validation-messages.component.html',
  styleUrls: ['./summary-validation-messages.component.scss']
})
export class SummaryValidationMessagesComponent implements OnInit {
  subscriptions: Subscription;
  @Input('appFormValidator') form: FormGroup;
  validationErrors: Array<string> = null;

  constructor(private serverValidationService: ServerValidationService) { }

  ngOnInit() {


    this.subscriptions = new Subscription();
    this.validationErrors =
      this.serverValidationService.summaryerrors$.map(res => {
        return res.map(item => {
          return (
            item.message
          );
        })
      );

        this.subscriptions.add(this.form.statusChanges.subscribe((data) => {

        }))
      }

}
