import { Component, OnInit } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs/';
import { ChallengeService } from '../../services/challenge.service';
import { ChallengeModel } from '../../models/challenges/challenge.model';
import { Router } from '@angular/router';
import { SubCategoryModel } from '../../models/subcategories/subcategories.model';
import { CategoryModel } from '../../models/categories/categories.model';

@Component({
  templateUrl: './challenge.component.html',
  styleUrls: ['./challenge.component.css']
})
export class ChallengeComponent implements OnInit {

  challenges$: Observable<ChallengeModel[]>;
  subCategories$: Observable<SubCategoryModel[]>;
  subCategories: SubCategoryModel[];
  categories$: Observable<CategoryModel[]>;
  typeSubcategory: string = '00';
  typeCategory: number;


  constructor(private router: Router,
    private challengeService: ChallengeService) { }

  ngOnInit() {

    this.challengeService.getChallengeList().subscribe((data: ChallengeModel[]) => {
      this.challenges$ = Observable.of(data);
    });
    this.challengeService.getChallengeSubCategories().subscribe((data: SubCategoryModel[]) => {
      this.subCategories$ = Observable.of(data);
    });
    this.challengeService.getChallengeCategories().subscribe((data: CategoryModel[]) => {
      this.categories$ = Observable.of(data);
    });
  }

  routeToChallenge(id) {
    this.router.navigate(['challenge/' + id]);
  }

  public isAuthenticated(): boolean {
    if (!localStorage.getItem('currentUser')) {
      return false;
    }
    return true;
  }

  setSubcategory(typeId: number) {
    if (typeId >= 100) {
      typeId -= 100;
      this.typeSubcategory = typeId.toString() + this.typeSubcategory.substring(1, this.typeSubcategory.length);
    } else {
      this.typeSubcategory = this.typeSubcategory.substring(0, 1) + typeId.toString();
    }
    console.log(this.typeSubcategory);
  }

}

