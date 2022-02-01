import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {GlobalConstants} from "../globals";


@Injectable({
  providedIn: 'root'
})
export class HomeService {
  totalAngularPackages;
  errorMessage;
  public url = GlobalConstants.apiURL;

  constructor(
    public http: HttpClient,

  ) { }

  getAllNews() {
     return this.http.get<any>(this.url+'/Articles/GetAll');
  }

  getAllNewsByCategory(id) {
    return this.http.get<any>(this.url+'/Articles/GetByCategory/'+id);
  }
}
