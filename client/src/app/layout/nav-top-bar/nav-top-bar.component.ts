import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { AccountDeleteComponent } from 'src/app/account/account-delete/account-delete.component';
import { AccountUpdatePasswordComponent } from 'src/app/account/account-update-password/account-update-password.component';
import { IBasket } from 'src/app/models/basket';
import { IUser } from 'src/app/models/user';
import { AccountService } from 'src/app/services/account.service';
import { BasketService } from 'src/app/services/basket.service';

@Component({
  selector: 'app-nav-top-bar',
  templateUrl: './nav-top-bar.component.html',
  styleUrls: ['./nav-top-bar.component.scss']
})
export class NavTopBarComponent implements OnInit {
  basket$: Observable<IBasket>;
  currentUser$: Observable<IUser>;

  constructor(private basketService: BasketService, private accountService: AccountService, private dialog: MatDialog) { }

  ngOnInit(): void {
    this.basket$ = this.basketService.basket$;
    this.currentUser$ = this.accountService.currentUser$;
  }

  logout(){
    this.accountService.logout();
  }

  editPassword(){
    this.dialog.open(AccountUpdatePasswordComponent);
  }

  deleteAccount(){
    this.dialog.open(AccountDeleteComponent);
  }
}
