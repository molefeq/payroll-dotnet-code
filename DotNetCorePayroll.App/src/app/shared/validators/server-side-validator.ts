import { ValidatorFn, AbstractControl } from "@angular/forms";

export function serverValidation(): ValidatorFn {
    return (control: AbstractControl): { [key: string]: any } => {
        const isValid = true;
        return isValid ? null : { 'serverValidation': { value: control.value } };
    };
}