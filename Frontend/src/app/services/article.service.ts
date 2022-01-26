import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import { Router } from '@angular/router';
import {News} from "../interfaces/News";
import {formatDate} from "@angular/common";
import {Observable} from "rxjs";


@Injectable({
  providedIn: 'root'
})
export class ArticleService {
  public url = "https://localhost:5001/api/Articles/GetAll";
  constructor(public http: HttpClient, private router: Router) { }

  getArticleById(id) {
    this.url = "https://localhost:5001/api/Articles/Get/"+id;
    return this.http.get<News>(this.url);
  }

  addComment(text: string) {


    const requestOptions = {
      method: 'POST',
      headers: { 'Content-Type': 'application/json', "Authorization": `Bearer ${localStorage.getItem("token")}`, },
      body: JSON.stringify({ content: text, articleId: 3, userId: 2, date: "2022-01-20T07:35:23.521Z"}),
    };

    fetch('https://localhost:5001/api/Comment/Add', requestOptions)
      .then(response => response)
      .then(data => {
        console.log(data)


      })
      .catch(error => console.log(error));



  }

  public deleteComment(comment: Comment): Observable<any> {
    const options = {
      headers: new HttpHeaders(),
      body: comment
    };
    return this.http.delete(`https://localhost:5001/api/Comment/Delete`, options);
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
    return this.http.post('https://localhost:5001/api/Articles/Add',body, options);

  }


}
