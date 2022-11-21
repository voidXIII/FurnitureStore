import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Observable } from 'rxjs';
import { IUser } from 'src/app/models/user';
import { AccountService } from 'src/app/services/account.service';

@Component({
  selector: 'app-account-update-password',
  templateUrl: './account-update-password.component.html',
  styleUrls: ['./account-update-password.component.scss']
})
export class AccountUpdatePasswordComponent implements OnInit {
  passwordForm: FormGroup;
  currentUser$: Observable<IUser>

  constructor(private accountService: AccountService, private dialog: MatDialog, private matSnackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.currentUser$ = this.accountService.currentUser$;
    this.loadPasswordForm();
  }

  loadPasswordForm() {
    this.passwordForm = new FormGroup({
      oldPassword: new FormControl('', [
        Validators.required,
        Validators.minLength(6),
        Validators.pattern(
          '^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*#?&])[A-Za-z\\d@$!%*#?&]{6,}$'
        ),
      ]),
      newPassword: new FormControl('', [
        Validators.required,
        Validators.minLength(6),
        Validators.pattern(
          '^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*#?&])[A-Za-z\\d@$!%*#?&]{6,}$'
        ),
      ]),
    });
  }


  onSubmit() {
    console.log(this.passwordForm.value);
    this.accountService.updatePassword(this.passwordForm.value).subscribe({
      next: () => {
        this.matSnackBar.open(
          'Your password was changed successfully.',
          'Close',
          {
            duration: 5000,
          }
        );
        this.dialog.closeAll();
      },
      error: (error) => {
        console.log(error);
      }
    });
  }
}
