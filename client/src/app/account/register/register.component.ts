import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { EmailService } from './EmailService'
import { EmailValidator } from './EmailValidator';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  promocodes = new FormArray([]);
  constructor(private formBuilder: FormBuilder, private emailService: EmailService) { }

  ngOnInit(): void {
    this.createRegisterForm();
    //this.createRegisterFormWithFormBuilder()
  }

  createRegisterForm(){
    this.registerForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email], 
      [EmailValidator.createValidator(this.emailService)]),
      password: new FormControl('', [Validators.required, Validators.minLength(8)])
    })
  }

  createRegisterFormWithFormBuilder(){
    this.registerForm = this.formBuilder.group({
      email: ['helloworld@gmail.com', [Validators.required, Validators.email]],
      password:['12345678', [Validators.required, Validators.minLength(8)]],
    });
  }

  onSubmit(){
    console.log(this.registerForm.value)
    console.log(this.promocodes.value)
  }

  addPromocode() {
    this.promocodes.push(new FormControl(''));
  }
}
