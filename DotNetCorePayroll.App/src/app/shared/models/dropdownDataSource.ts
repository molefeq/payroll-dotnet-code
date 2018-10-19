import { BehaviorSubject, Observable } from 'rxjs';
import { ReferenceDataModel } from '../generated';

export interface DropdownDataSource {
    data$: Observable<ReferenceDataModel[]>;
    inprogess$: BehaviorSubject<boolean>;
}
