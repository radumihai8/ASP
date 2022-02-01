import {Component, OnDestroy, OnInit} from '@angular/core';
import { HomeService } from "../services/home.service";
import { Subscription } from 'rxjs';
import { DataService } from '../services/data.service';
import {HttpClient} from "@angular/common/http";
import {News} from "../interfaces/News";
import {Category} from "../interfaces/Category";
import {CategoryService} from "../services/category.service";
import {ActivatedRoute, Router} from "@angular/router";
import {AuthService} from "../services/auth.service";
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  errorMessage;
  public news:News[] = [];
  public categories:Category[] = [];
  public currentCategory:Category = {
    id: 0, title: ""
  };

  category_id: number = 1;
  constructor(
    private homeService: HomeService,
    private categoryService: CategoryService,
    private dataService: DataService,
    private route: ActivatedRoute,
    private authService: AuthService,
    private toastr: ToastrService,
    private router: Router



  ) {
    //subscribe la router events, atunci cand se schimba ruta sa se reia articolele in functie de categorie
    router.events.subscribe((val) => {
      this.get_news();
    });
  }



  get_news(){
    if(!this.category_id){
      this.homeService.getAllNews().subscribe({
        next: (data: News[]) => {
          this.news = data;
        },
        error: error => {
          this.errorMessage = error.message;
          console.error('There was an error!', error);
        }
      })
    }
    else {
      console.log(this.category_id);
      this.homeService.getAllNewsByCategory(this.category_id).subscribe({
        next: (data: News[]) => {
          this.news = data;
        },
        error: error => {
          this.errorMessage = error.message;
          console.error('There was an error!', error);
        }
      })
      this.categoryService.getCategoryById(this.category_id).subscribe({
        next: (data: Category) => {
          //console.log(data);
          this.currentCategory = data;
        },
        error: error => {
          this.errorMessage = error.message;
          console.error('There was an error!', error);
        }
      })

    }
  }

  ngOnInit(): void {

    this.route.params.subscribe((params) => {
      this.category_id = params['id'];
    });

    this.get_news();

    this.categoryService.getAllCategories().subscribe({
      next: (data: Category[]) => {
        //console.log(data);
        this.categories = data;
      },
      error: error => {
        this.errorMessage = error.message;
        console.error('There was an error!', error);
      }
    })
  }




}
