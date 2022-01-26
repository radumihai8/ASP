import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Category} from "../interfaces/Category";


@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  totalAngularPackages;
  errorMessage;

  constructor(
    public http: HttpClient,

  ) { }

  getAllCategories() {
    return this.http.get<any>(`https://localhost:5001/api/Category/GetAll`);
  }

  getCategoryById(id) {
    return this.http.get<Category>(`https://localhost:5001/api/Category/Get/`+id);
  }

  createCategory(title: string){
    const options = {
      headers: {
        'Content-Type': 'application/json',
        "Authorization": `Bearer ${localStorage.getItem("token")}` },
    };

    return this.http.post('https://localhost:5001/api/Category/Add', JSON.stringify({ title: title }), options);

  }
}
