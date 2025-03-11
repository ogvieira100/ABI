export class ValiditionError {

    propertyName: string;
    errorMessage: string;
    attemptedValue: any;
    customState: any;
    severity: number;
    errorCode: string;
    formattedMessagePlaceholderValues: {
      PropertyName: string | null;
      PropertyValue: any;
      PropertyPath: string;
    };
  
    constructor(
      propertyName: string,
      errorMessage: string,
      attemptedValue: any,
      customState: any,
      severity: number,
      errorCode: string,
      formattedMessagePlaceholderValues: {
        PropertyName: string | null;
        PropertyValue: any;
        PropertyPath: string;
      }
    ) {
      this.propertyName = propertyName;
      this.errorMessage = errorMessage;
      this.attemptedValue = attemptedValue;
      this.customState = customState;
      this.severity = severity;
      this.errorCode = errorCode;
      this.formattedMessagePlaceholderValues = formattedMessagePlaceholderValues;
    }
}
