import { Component, OnInit, ViewChild, ElementRef, OnChanges } from '@angular/core';
import { Observable } from 'rxjs/';
import { FormBuilder, FormGroup, NgForm } from '@angular/forms';
import { ChallengeModel } from '../../models/challenges/challenge.model';
import { ChallengeService } from '../../services/challenge.service';
import { Router } from '@angular/router';
import { CategoryModel } from '../../models/categories/categories.model';
import { SubCategoryModel } from '../../models/subcategories/subcategories.model';
import Swal from 'sweetalert2';
import { AlertService } from '../../services/alert.service';
import { ModalDirective } from 'ngx-bootstrap/modal/modal.directive';

declare var $: any;
@Component({
  selector: 'app-add-challenge',
  templateUrl: 'add-challenge.component.html',
  styleUrls: ['challenge.component.css']
})

export class AddChallengeComponent implements OnInit {

  categoriesList$: Observable<CategoryModel[]>;
  subCategoriesList$: Observable<SubCategoryModel[]>;
  challengeInfo: ChallengeModel = new ChallengeModel();
  isPhoto = false;
  triedToSave = false;
  subcategorySelectedError = false;

  constructor(private challengeService: ChallengeService, private router: Router, private alertService: AlertService) {
  }

  @ViewChild('challengeModal') public modal: ModalDirective;

  ngOnInit() {

    this.getCategoriesList();
    this.getSubCategoriesList();

  }

  getCategoriesList() {
    this.challengeService.getChallengeCategories().subscribe((response: CategoryModel[]) => {
      this.categoriesList$ = Observable.of(response);
    });
  }

  getSubCategoriesList() {
    this.challengeService.getChallengeSubCategories().subscribe((response: CategoryModel[]) => {
      this.subCategoriesList$ = Observable.of(response);
    });
  }

  isImageUrl(url) {
    if (url.endsWith('.jpg') || url.endsWith('.jpeg') || url.endsWith('.png')) {
      return this.isPhoto = true;
    } else {
      return this.isPhoto = false;
    }
  }

  checkIfSubcategorySelected(value) {
    if (value === 'default') {
      this.subcategorySelectedError = true;
    } else {
      this.subcategorySelectedError = false;
    }
  }

  save(form: NgForm, event) {
    console.log(this.challengeInfo);
    this.challengeInfo.category = 2; // user added challenges go to userCreated category
    if (form.valid) {
      this.triedToSave = false;
      this.challengeService.postChallenge(this.challengeInfo)
        .subscribe(
          data => {
            Swal({
              title: 'Succesfully added!',
              type: 'success'
            });
            $('#challengeModal').modal('hide');
            this.router.navigate(['']);
          },
          (err) => {
            this.alertService.error(err._body);
          });
    }
  }


}
