import { Injectable } from '@angular/core';
import { ReferenceDataModel } from '../generated';

@Injectable()
export class AppReferenceDataService {
    private countries: Array<ReferenceDataModel>;
    private provinces: Array<ReferenceDataModel>;

    constructor() { }

    public setCountries(countries) {
        this.countries = countries;
    }

    public getCountries(): Array<ReferenceDataModel> {
        return this.countries;
    }

    public setProvinces(provinces) {
        this.provinces = provinces;
    }

    public getProvinces(): Array<ReferenceDataModel> {
        return this.provinces;
    }
}
