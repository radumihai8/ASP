import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {UserService} from "../services/user.service";
import { AbstractControl, FormControl, FormGroup, ReactiveFormsModule  } from '@angular/forms';
import {DataService} from "../services/data.service";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  public registerForm: FormGroup = new FormGroup({
    email: new FormControl(''),
    username: new FormControl(''),
    password: new FormControl(''),
  });

  constructor(
    private router: Router,
    private userService: UserService,
    private dataService: DataService,
    private toastr: ToastrService

  ) { }

  ngOnInit(): void {
  }



  register() {
    this.dataService.changeUserData(this.registerForm.value);
    this.userService.register(this.registerForm.value.email, this.registerForm.value.username, this.registerForm.value.password).subscribe(
      (result) => {
        //console.log(result);
        this.toastr.success("Your account was created!")
      },
      (error) => {
        console.error(error);
        this.toastr.error("There was an error!")
      }
    );
    this.router.navigate(['']);

  }

}
