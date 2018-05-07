import { Component, OnInit, Input } from '@angular/core';
import { ServerValidationService } from '../../services/server-validation.service';
import { messageType } from '../../models/messageType';
import { Subscription } from 'rxjs/Subscription';
import { FormGroup } from '@angular/forms';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import "rxjs/add/operator/map";
import { Observable } from 'rxjs/Observable';
import { responseMessage } from '../../models/responseMessage';

@Component({
  selector: 'app-summary-validation-messages',
  templateUrl: './summary-validation-messages.component.html',
  styleUrls: ['./summary-validation-messages.component.scss']
})
export class SummaryValidationMessagesComponent implements OnInit {
  subscriptions: Subscription;

  @Input('appForm') form: FormGroup;

  validationErrors$: BehaviorSubject<Array<string>> = new BehaviorSubject(null);

  constructor(private serverValidationService: ServerValidationService) { }

  ngOnInit() {
    this.subscriptions = new Subscription();

    this.subscriptions.add(this.serverValidationService.summaryerrors$.subscribe((res: responseMessage[]) => {
      if (!Boolean(res) || res.length == 0) {
        return;
      }

      this.validationErrors$.next(res.map(item => {
        return (
          item.message
        );
      }))
    }));

    this.subscriptions.add(this.form.statusChanges.subscribe((data) => {
      if (Boolean(this.validationErrors$.value)) {
        this.validationErrors$.next(null)
      }
    }));
  };

  ngOnDestroy() {
    this.subscriptions.unsubscribe();
  }

}
