import { Component } from '@angular/core';
import { ApiService } from './app.service';

@Component({
    selector: 'app',
    template: `
   <login></login>

`,
    providers: [ApiService]
})
export class AppComponent {
    Users: Array<any>;


    constructor(private apiService: ApiService) {}
}
//<li *ngFor="let user of Users" > {{user.email }}
      
//</li><login></login>