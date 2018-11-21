import { Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/toPromise';
import { SubCategoryModel } from '../models/subcategories/subcategories.model';

@Injectable()
export class AdminService {


  constructor(private http: Http) { }

  baseUrl = 'http://localhost:59372/';
// Subcategories
  saveSubcategory(item): Observable<SubCategoryModel> {
    return this.http.post(this.baseUrl + 'Subcategories', item)
        .map((res: Response) => res.json() as SubCategoryModel[])
        .catch((error: any) => Observable.throw(error));
}

  updateSubcategory(id, sub): Observable<SubCategoryModel> {
    return this.http.put(this.baseUrl + 'Subcategories' + '/' + id, sub)
      .map((res: Response) => res.json() as SubCategoryModel)
      .catch((error: any) => Observable.throw(error));
  }


  deleteSubcategory(id): Observable<SubCategoryModel> {
    return this.http.delete(this.baseUrl + 'Subcategories' + '/' + id)
      .map((res: Response) => res.json() as SubCategoryModel)
      .catch((error: any) => Observable.throw(error));
  }
}
