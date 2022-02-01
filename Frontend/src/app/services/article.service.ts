import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import { Router } from '@angular/router';
import {News} from "../interfaces/News";
import {formatDate} from "@angular/common";
import {Observable} from "rxjs";
import {GlobalConstants} from "../globals";


@Injectable({
  providedIn: 'root'
})
export class ArticleService {
  public url = GlobalConstants.apiURL;
  constructor(public http: HttpClient, private router: Router) { }

  getArticleById(id) {
    return this.http.get<News>(this.url+'/Articles/Get/'+id);
  }

  addComment(text: string, article_id: number) {
    let date = formatDate(new Date(), 'yyyy/MM/dd', 'en');
    let uid = JSON.parse(atob(localStorage.getItem('token')!.split('.')[1]))['nameid'];

    const options = {
      headers: {
        'Content-Type': 'application/json',
        "Authorization": `Bearer ${localStorage.getItem("token")}` },
    };
    let body = JSON.stringify({ content: text, articleId: article_id, userId: uid, date: date});
    return this.http.post(this.url+'/Comment/Add',body, options);


  }

  public deleteComment(comment: Comment): Observable<any> {
    const options = {
      headers: {
        'Content-Type': 'application/json',
        "Authorization": `Bearer ${localStorage.getItem("token")}` },
      body: comment
    };

    return this.http.delete(this.url+'/Comment/Delete', options);
  }



  create(title: string, categoryId: number, content: string) {
    let date = formatDate(new Date(), 'yyyy/MM/dd', 'en');
    let uid = JSON.parse(atob(localStorage.getItem('token')!.split('.')[1]))['nameid'];
    const options = {
      headers: {
        'Content-Type': 'application/json',
        "Authorization": `Bearer ${localStorage.getItem("token")}` },
    };
    let body = JSON.stringify({ title: title, content: content, date: date, categoryId: categoryId, userId: uid });
    return this.http.post(this.url+'/Articles/Add',body, options);

  }


}
