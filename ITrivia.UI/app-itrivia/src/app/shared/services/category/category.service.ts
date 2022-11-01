import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Category } from '@shared/models/category';
import { Observable } from 'rxjs';
import { WebApiBaseService } from '../web-api-base/web-api-base.service';


@Injectable({
  providedIn: 'root'
})
export class CategoryService extends WebApiBaseService {
  constructor(public http: HttpClient) {
    super(http);
  }


  getCategory(id:number): Observable<Array<Category>> {
    return this.http.get<Array<Category>>(this.baseUrl + "Category" + id);
  }

  getCategories(): Observable<Array<Category>> {
    return this.http.get<Array<Category>>(this.baseUrl + "Category");
  }

}
