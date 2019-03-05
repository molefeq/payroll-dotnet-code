import { Injectable } from '@angular/core';
import { ReferenceDataService, StaticDataModel } from '../generated';
import { Observable } from 'rxjs/Observable';
import { AppReferenceDataService } from './app-reference-data-service';
import 'rxjs/add/operator/catch'; 

@Injectable()
export class AppStartUpService {
  constructor(private referenceDataService: ReferenceDataService, private appReferenceDataService: AppReferenceDataService) { }

  public load() {
    return new Promise((resolve, reject) => {
      this.referenceDataService.getStaticData()
      .catch((error: any) => {
        console.error('Error fetching reference data.');
        resolve(error);
        return Observable.throw(error.json().error || 'Server error');
      }).subscribe((data: StaticDataModel) => {
        this.appReferenceDataService.setCountries(data.countries);
        this.appReferenceDataService.setProvinces(data.provinces);
        resolve(true);
      });
    });
  }
}
