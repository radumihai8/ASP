import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { AbstractControl, FormControl, FormGroup, ReactiveFormsModule  } from '@angular/forms';
import {DataService} from "../services/data.service";



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  public loginForm: FormGroup = new FormGroup({
    username: new FormControl(''),
    password: new FormControl(''),
  });

  constructor(
    private router: Router,
    private authService: AuthService,
    private dataService: DataService

  ) { }


  ngOnInit() {
  }


  login() {
    this.dataService.changeUserData(this.loginForm.value);
    this.authService.login(this.loginForm.value.username, this.loginForm.value.password);
  }



}
