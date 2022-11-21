import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { IUser } from 'src/app/models/user';
import { AccountService } from 'src/app/services/account.service';

@Component({
  selector: 'app-account-delete',
  templateUrl: './account-delete.component.html',
  styleUrls: ['./account-delete.component.scss']
})
export class AccountDeleteComponent implements OnInit {
  currentUser$: Observable<IUser>
  constructor(private accountService: AccountService, private snackBar: MatSnackBar, private router: Router) {
    this.currentUser$ = this.accountService.currentUser$;
  }

  ngOnInit(): void {
  }

  deleteAccount(email: string) {
    this.accountService.deleteUser(email).subscribe({
      next: () => {
        this.snackBar.open('Account deleted', 'Close', {
          duration: 5000
        });
      },
      error: (error) => {
        console.log(error)
      }
    });
  }

}
