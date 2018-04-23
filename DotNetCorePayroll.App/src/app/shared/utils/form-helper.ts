import { FormControl, FormGroupDirective, NgForm } from "@angular/forms";

export class FormHelper {
	static isErrorState(control: FormControl | null, isSubmitted: boolean | false): boolean {
        return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
	}
}
