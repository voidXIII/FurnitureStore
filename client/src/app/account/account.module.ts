import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AccountRoutingModule } from './account-routing.module';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';
import { AccountUpdatePasswordComponent } from './account-update-password/account-update-password.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { AccountDeleteComponent } from './account-delete/account-delete.component';

@NgModule({
  declarations: [
    LoginComponent,
    RegisterComponent,
    AccountUpdatePasswordComponent,
    AccountDeleteComponent
  ],
  imports: [
    CommonModule,
    AccountRoutingModule,
    MatButtonModule,
    MatCardModule,
    MatInputModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule,
    MatDialogModule,
    MatSnackBarModule
  ]
})
export class AccountModule { }
