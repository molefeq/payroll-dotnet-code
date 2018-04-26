import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Observable } from 'rxjs/Observable';
import { responseMessage } from '../models/responseMessage';

@Injectable()
export class ServerValidationService {

  private _serverError$: BehaviorSubject<string> = new BehaviorSubject(null);
  private _errors$: BehaviorSubject<Array<responseMessage>> = new BehaviorSubject(null);
  private _summaryerrors$: BehaviorSubject<Array<responseMessage>> = new BehaviorSubject(null);

  setErrors(value: Array<responseMessage>): void {
    this._errors$.next(value);
  }

  get errors$(): Observable<Array<responseMessage>> {
    return this._errors$;
  }

  setSummaryerrors(value: Array<responseMessage>): void {
    this._summaryerrors$.next(value);
  }

  get summaryerrors$(): Observable<Array<responseMessage>> {
    return this._summaryerrors$;
  }
  
  setServerErrors(value: string): void {
    this._serverError$.next(value);
  }

  get serverErrors$(): Observable<string> {
    return this._serverError$;
  }
}
