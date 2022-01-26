import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {UserService} from "../services/user.service";
import { AbstractControl, FormControl, FormGroup, ReactiveFormsModule  } from '@angular/forms';
import {DataService} from "../services/data.service";
import {ArticleService} from "../services/article.service";
import {CategoryService} from "../services/category.service";
import {Category} from "../interfaces/Category";
import {News} from "../interfaces/News";
import {HomeService} from "../services/home.service";
import {ToastrModule, ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class CreateComponent implements OnInit {
  public categories:Category[] = [];


  public createForm: FormGroup = new FormGroup({
    title: new FormControl(''),
    categoryId: new FormControl(''),
    content: new FormControl(''),
  });

  public createCategoryForm: FormGroup = new FormGroup({
    CategoryTitle: new FormControl(''),
  });

  constructor(
    private router: Router,
    private articleService: ArticleService,
    private dataService: DataService,
    private categoryService: CategoryService,
    private homeService: HomeService,
    private toastr: ToastrService

  ) { }

  ngOnInit(): void {

    this.categoryService.getAllCategories().subscribe({
      next: (data: Category[]) => {
        this.categories = data;
        return data;
      },
      error: error => {
        console.error('There was an error!', error);
        return false;
      }


    })



  }




  create() {
    this.articleService.create(this.createForm.value.title, this.createForm.value.categoryId, this.createForm.value.content).subscribe(
      (result) => {
        console.log(result);
        this.toastr.success("Article posted!")
      },
      (error) => {
        console.error(error);
        this.toastr.error("There was an error!")
      }
    );

  }

  createCategory() {
    this.categoryService.createCategory(this.createCategoryForm.value.CategoryTitle).subscribe(
      (result) => {
        console.log(result);
        this.toastr.success("Category created!")
      },
      (error) => {
        console.error(error);
        this.toastr.error("There was an error!")
      }
    );


  }

}
