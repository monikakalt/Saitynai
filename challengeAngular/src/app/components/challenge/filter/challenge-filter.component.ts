import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { SubCategoryModel } from '../../../models/subcategories/subcategories.model';
import { CategoryModel } from '../../../models/categories/categories.model';

@Component({
  selector: 'app-filter',
  template: `
  <div>
    <div>
      Category
      <button type="radio" class="btn btn-primary"
      (click)="setCategory(0)"> All</button>
      <button *ngFor="let t of categories$ | async" type="radio" class="btn btn-primary mr-1"
      (click)="setCategory(t.id)">{{t.title}}</button>


    <div style="margin-top: 10px;">
      Subcategory
      <button type="button" class="btn btn-primary"
      (click)="setSubcategory(0)"> All</button>
      <button *ngFor="let t of subcategories$ | async" type="button" class="btn btn-primary mr-1"
      (click)="setSubcategory(t.id)">{{t.title}}</button>
  </div>
</div>
    `
})

export class ChallengeFilterComponent implements OnInit {

  @Input() subcategories$: Observable<SubCategoryModel[]>;
  @Input() categories$: Observable<CategoryModel[]>;
  @Output() filterEvent: EventEmitter<any> = new EventEmitter<any>();

  constructor() { }

  ngOnInit() { }

  setSubcategory(id ) {
    this.filterEvent.emit(id);
  }
  setCategory(id:number) {
    this.filterEvent.emit(id + 100);
  }

}
