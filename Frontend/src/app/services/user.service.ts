import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(
    private router: Router,
    public http: HttpClient,

  ) { }



  register(username: string, password: string) {
    const options = {
      headers: {
        'Content-Type': 'application/json',
      },
    };
    let body = JSON.stringify({ email: username, password: password});
    return this.http.post('https://localhost:5001/api/Auth/Register', body, options);

  }

}
