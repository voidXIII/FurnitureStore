import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { delay } from 'rxjs/operators';


@Injectable({
  providedIn: 'root',
})

export class EmailService {
  private existingEmails = ['ion@gmail.com', 'hello@gmail.com', 'amdaris@gmail.com'];

  checkIfEmailExists(value: string) {
    return of(this.existingEmails.some((a) => a === value)).pipe(
      delay(500)
    );
  }
}

