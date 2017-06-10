import { Component } from '@angular/core';
import { ApiService } from './app.service';

@Component({
    selector: 'app',
    templateUrl: './html/singin/singin.html',
    providers: [ApiService]
})
export class AppComponent {
    Users: Array<any>;

    email: String;
    password: string;
    errorMesage: Boolean;
    log: Boolean;

    exep: String;

    constructor(private apiService: ApiService) {
        this.log = false;
        this.errorMesage = false;

    }

    addUser() {
        var user = {
            email: "Google"
        }
        this.apiService.addUserGoogle(user);

    }
}
