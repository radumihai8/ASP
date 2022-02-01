import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {ArticleService} from "../services/article.service";
import {News} from "../interfaces/News";
import {DataService} from "../services/data.service";
import {FormControl, FormGroup} from "@angular/forms";
import {Subscription} from "rxjs";
import {User} from "../interfaces/User";
import {AuthService} from "../services/auth.service";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.scss']
})
export class ArticleComponent implements OnInit {

  public subscription: Subscription;
  public loggedUser: User;

  public commentForm: FormGroup = new FormGroup({
    text: new FormControl(''),
  });



  id: number = 0;
  errorMessage;
  public news:News = {
    content: "",
    date: "",
    id: 0,
    title: "",
    category: {
      id:0,
      title: "Category title"
    },
    user: {
      userName: "",
      email: ""
    },
    articleComment: [{
      content: "",
      user: {
        userName: "",
        email: ""
      }
    }]
  };

  constructor(private route: ActivatedRoute,
    private articleService: ArticleService,
    private dataService: DataService,
    public authService: AuthService,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.subscription = this.dataService.currentUser.subscribe((user: User) => this.loggedUser = user);

    this.route.params.subscribe((params) => {
      this.id = params['id'];
    });
    this.articleService.getArticleById(this.id).subscribe(
      (result: News) => {
        //console.log(result);
        this.news = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }


  addComment() {
    this.articleService.addComment(this.commentForm.value.text, this.id).subscribe(
      (result) => {
        //console.log(result);
        this.toastr.success("Comment posted!")
      },
      (error) => {
        //console.error(error);
        this.toastr.error("There was an error!")
      }
    );
  }

  public deleteComment(comment): void {
    this.articleService.deleteComment(comment).subscribe(
      (result) => {
        //console.log(result);
        this.toastr.success("Comment deleted!")
      },
      (error) => {
        //console.error(error);
        this.toastr.success("Comment deleted!")
      }
    );
  }


}
