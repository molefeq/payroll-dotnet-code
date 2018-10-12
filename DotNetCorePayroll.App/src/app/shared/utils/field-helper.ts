export class FieldHelper {
	static toCamelCase(fieldValue: string): string {
		return fieldValue[0].toUpperCase() + fieldValue.slice(1);
	}
}

