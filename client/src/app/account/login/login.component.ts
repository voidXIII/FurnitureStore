import { Component} from '@angular/core';
import { IUser } from 'src/app/models/user';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  userModel: IUser = {} as IUser;

  submitForm(){
    console.log(this.userModel.email + ' ' + this.userModel.password)
  }

}
