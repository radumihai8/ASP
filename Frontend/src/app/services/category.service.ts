import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Category} from "../interfaces/Category";
import {GlobalConstants} from "../globals";


@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  totalAngularPackages;
  errorMessage;

  public url = GlobalConstants.apiURL;

  constructor(
    public http: HttpClient,

  ) { }

  getAllCategories() {
    return this.http.get<any>(this.url+'/Category/GetAll');
  }

  getCategoryById(id) {
    return this.http.get<Category>(this.url+'/api/Category/Get/'+id);
  }

  createCategory(title: string){
    const options = {
      headers: {
        'Content-Type': 'application/json',
        "Authorization": `Bearer ${localStorage.getItem("token")}` },
    };

    return this.http.post(this.url+'/Category/Add', JSON.stringify({ title: title }), options);

  }
}
