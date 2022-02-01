import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import {HttpClient} from "@angular/common/http";
import {GlobalConstants} from "../globals";

@Injectable({
  providedIn: 'root'
})
export class UserService {
  public url = GlobalConstants.apiURL;
  constructor(
    private router: Router,
    public http: HttpClient,

  ) { }



  register(email: string, username: string, password: string) {
    const options = {
      headers: {
        'Content-Type': 'application/json',
      },
    };
    let body = JSON.stringify({ email: email, username: username, password: password});
    return this.http.post(this.url + 'Auth/Register', body, options);

  }

}
