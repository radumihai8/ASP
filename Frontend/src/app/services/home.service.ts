import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";


@Injectable({
  providedIn: 'root'
})
export class HomeService {
  totalAngularPackages;
  errorMessage;
  public url = "https://localhost:5001/api/Articles/GetAll";

  constructor(
    public http: HttpClient,

  ) { }

  getAllNews() {
     return this.http.get<any>(this.url);
  }

  getAllNewsByCategory(id) {
    return this.http.get<any>(`https://localhost:5001/api/Articles/GetByCategory/`+id);
  }
}
