import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AsyncValidatorFn } from '@angular/forms';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/services/account.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { map, of, switchMap, timer } from 'rxjs';
import { Validator } from 'src/app/shared/validators/emailnottaken';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  emailNotTakenValidator = new Validator(this.accountService)

  constructor(private formBuilder: FormBuilder, private accountService: AccountService, private router: Router, private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.createRegisterForm();
  }

  createRegisterForm(){
    this.registerForm = this.formBuilder.group({
      displayName: [null, [Validators.required]],
      email: [null, [Validators.required, Validators.email], [this.emailNotTakenValidator.validateEmailNotTaken()]],
      password:[null, [Validators.required, Validators.minLength(6), Validators.pattern('^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*#?&])[A-Za-z\\d@$!%*#?&]{6,}$')]]
    });
  }


  onSubmit(){
    this.accountService.register(this.registerForm.value).subscribe(
      () => { 
        this.router.navigateByUrl('/book') 
      }, error => {
        this.snackBar.open(error.errors.message, 'Close', {
          duration: 5000
        });
    })
  }

}
