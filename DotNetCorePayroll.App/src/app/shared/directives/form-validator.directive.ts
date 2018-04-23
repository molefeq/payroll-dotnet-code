import { Directive, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ServerValidationService } from '../services/server-validation.service';
import { Subscription } from 'rxjs/Subscription';
import { responseMessage } from '../models/responseMessage';
import { messageType } from '../models/messageType';

@Directive({
  selector: '[appFormValidator]'
})
export class FormValidatorDirective {
  @Input('appFormValidator') form: FormGroup;

  subscriptions: Subscription;
  summaryErrors: Array<responseMessage>;

  constructor(private serverValidationService: ServerValidationService) {

  }

  ngOnInit() {
    this.subscriptions = new Subscription();
    this.subscriptions.add(this.serverValidationService.errors$.subscribe(errors => {
      if (!Boolean(errors) || errors.length == 0) {
        return;
      }

      this.summaryErrors = new Array<responseMessage>();

      for (let error of errors) {
        if (error.messageType !== messageType.ERROR) {
          continue;
        }

        if (!Boolean(this.form.get(error.fieldName))) {
          this.summaryErrors.push(error);
          continue;
        }

        this.form.get(error.fieldName).setErrors({ "serverValidation": true });
      }

    }));

    // this.subscriptions.add(this.form.valueChanges.subscribe(data => {
    //   this.serverValidationService.setErrors([]);
    // }));
  }


  ngOnDestroy() {
    this.subscriptions.unsubscribe();
  }
}
