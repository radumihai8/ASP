import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import {catchError} from "rxjs";
import {AbstractControl} from "@angular/forms";
import {ToastrService} from "ngx-toastr";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private router: Router,
  private toastr: ToastrService
  ) { }

  login(username: string, password: string) {


    const requestOptions = {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ email: username, password: password}),
    };

    fetch('https://localhost:5001/api/Auth/Login', requestOptions)
      .then(response => response.json())
      .then(data =>
      {
        localStorage.setItem('token', data['accessToken']);
        localStorage.setItem('role', JSON.parse(atob(data['accessToken'].split('.')[1]))['role']);
      })
      .catch(error => console.log("Error"));

    this.router.navigate(['']);
    this.toastr.success("You are logged in!")
  }


  logout() {
    localStorage.clear();
    this.router.navigate(['/login']);
    this.toastr.error("You are logged out!")
  }

  isAuthenticated(): boolean {
    return !!localStorage.getItem('token');
  }
  isAdmin(): boolean {
    return localStorage.getItem('role')==='Admin';
  }

}
