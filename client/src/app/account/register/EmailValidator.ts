import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import {
    AbstractControl,
    AsyncValidatorFn,
    ValidationErrors,
  } from '@angular/forms';
import { EmailService } from './EmailService';

export class EmailValidator {
    static createValidator(emailService: EmailService): AsyncValidatorFn {
      return (control: AbstractControl): Observable<ValidationErrors> => {
        return emailService
          .checkIfEmailExists(control.value)
          .pipe(
            map((result: boolean) =>
              result ? { emailAlreadyExists: true } : null
            )
          );
      };
    }
}