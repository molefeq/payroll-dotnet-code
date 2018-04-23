import { Directive, ElementRef, Input } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Subscription } from 'rxjs/Subscription';
import { startWith } from 'rxjs/operators';

@Directive({
  selector: '[appValidationMessage]'
})
export class AppValidationMessageDirective {
  @Input('appValidationMessage') control: FormControl;
  @Input() messages: any;
  subscriptions: Subscription;

  constructor(private el: ElementRef) {
    this.subscriptions = new Subscription();
  }

  ngOnInit() {
    this.displayError();

    this.subscriptions.add(this.control.statusChanges
      .subscribe(data => {
        this.displayError();
      }));
  }

  displayError() {
    if (!Boolean(this.control.errors) || Object.keys(this.control.errors).length === 0) {
      return;
    }

    this.el.nativeElement.innerHTML = this.messages[Object.keys(this.control.errors)[0]];
  }

  ngOnDestroy() {
    this.subscriptions.unsubscribe();
  }

}
