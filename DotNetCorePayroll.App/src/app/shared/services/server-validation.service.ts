import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Observable } from 'rxjs/Observable';
import { responseMessage } from '../models/responseMessage';

@Injectable()
export class ServerValidationService {

  private _errors$: BehaviorSubject<Array<responseMessage>> = new BehaviorSubject(null);

  setErrors(value: Array<responseMessage>): void {
    this._errors$.next(value);
  }

  get errors$(): Observable<Array<responseMessage>> {
    return this._errors$;
  }

}
