import { Injectable } from "@angular/core";
import { Http, Headers, Jsonp  } from "@angular/http";
import "rxjs/add/operator/map";

@Injectable()
export class LoginService {
    constructor(private http: Http, private jsonp: Jsonp) { }

    addUser(user) {
        var headers = new Headers();
        headers.append('Content-Type', 'application/json');
        return this.http.post('/api/values', JSON.stringify(user), { headers: headers })
            .map(responce => responce)                     
    }
    addUserGoogle(user) {
        var headers = new Headers();
        headers.append('Content-Type', 'application/json');
        headers.append('Access-Control-Allow-Origin', '*');
        console.log(user);
        return this.http.post('/apicvprofgoo/singinwithgoogle', JSON.stringify(user), { headers: headers })
            .subscribe(data => {
                
                window.location.href = data.url;
            });
    }
}