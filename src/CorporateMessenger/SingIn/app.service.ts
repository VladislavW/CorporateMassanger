import { Injectable } from "@angular/core";
import { Http, Headers, Jsonp  } from "@angular/http";
import "rxjs/add/operator/map";

@Injectable()
export class ApiService {
    constructor(private http: Http, private jsonp: Jsonp) { }

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