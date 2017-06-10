import { Injectable } from "@angular/core";
import { Http, Headers, Jsonp  } from "@angular/http";
import "rxjs/add/operator/map";

@Injectable()
export class MsgService {
    constructor(private http: Http, private jsonp: Jsonp) { }

  
}