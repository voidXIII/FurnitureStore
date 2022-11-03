import { AsyncValidatorFn } from '@angular/forms';
import { of, timer } from 'rxjs';
import { map, switchMap } from 'rxjs/operators';
import { AccountService } from 'src/app/services/account.service';

export class Validator {
  constructor(private accountService: AccountService) {}

  public validateEmailNotTaken(): AsyncValidatorFn {
    return (control) => {
      return timer(500).pipe(
        switchMap(() => {
          if (!control.value) {
            return of(null);
          }
          return this.accountService.checkEmailExists(control.value).pipe(
            map((res) => {
              return res ? { emailExist: true } : null;
            })
          );
        })
      );
    };
  }
}