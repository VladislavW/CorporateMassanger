import { Component } from '@angular/core';
import { LoginService } from './login.service';
import * as md5 from 'ts-md5/dist/md5';

@Component({
    selector: 'login',
    templateUrl: "./html/login/login.html",
    providers: [LoginService]
})
export class LoginComponent {
    Users: Array<any>;

    email: String;
    password: string;
    errorMesage: Boolean;
    log: Boolean;

    exep: String;

    constructor(private loginService: LoginService) {
        this.log = false;
        this.errorMesage = false;
       
    }

    addUser() {
       // this.log = true;
       // var user = {
       //     email: this.email,
       //     password: md5.Md5.hashStr(this.password)
       // }
       //// this.loginService.addUserGoogle();
       // this.loginService.addUser(user)
       //     .subscribe(data => {
                
       //     if (data.status == 201) {
       //         window.location.href = "/Home/Index";
       //         window.location.reload();
       //     }
       //     else {
       //         this.log = false;
       //         this.errorMesage = true;
       //         this.exep = "Аккаунта с таким Email или паролем не существует.";
       //         setTimeout(() => {
       //             this.errorMesage = false;
       //         }, 3000);
       //     }
       // }) ;
       // this.log = true;
        var user = {
            email: "Google"
        }
        console.log(user);
       // this.loginService.addUserGoogle();
        this.loginService.addUserGoogle(user);

    }
}