import { Component, OnInit, Inject, Input } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs/';
import { ChallengeService } from '../../services/challenge.service';
import { AdminService } from '../../services/admin.service';
import { Router } from '@angular/router';
import { SubCategoryModel } from '../../models/subcategories/subcategories.model';
import { CategoryModel } from '../../models/categories/categories.model';
import { NgForm } from '@angular/forms';
import swal from 'sweetalert2';

@Component({
  styleUrls: [`admin.component.css`],
  templateUrl: 'admin.component.html'
})

export class AdminComponent implements OnInit {
  constructor(private router: Router,
    private challengeService: ChallengeService,
    private adminService: AdminService,
  ) { }

  subCategories$: Observable<SubCategoryModel[]>;
  subCategories: SubCategoryModel[];
  categories$: Observable<CategoryModel[]>;

  ngOnInit() {
    this.challengeService.getChallengeSubCategories().subscribe((data: SubCategoryModel[]) => {
      this.subCategories$ = Observable.of(data);
    });
    this.challengeService.getChallengeCategories().subscribe((data: CategoryModel[]) => {
      this.categories$ = Observable.of(data);
    });
  }

  editSubcategory(id, title) {
    swal({
      title: 'What subcategory you want to change it to?',
      input: 'text',
      inputPlaceholder: title,
      inputValue: title,
      showCancelButton: true,
      inputValidator: (value) => {
        return !value && 'You need to write something!';
      }
    }).then((result) => {
      if (result.value) {
        const obj = {
          id: id,
          title: result.value
        };
        this.adminService.updateSubcategory(id, obj)
          .subscribe((res) =>
            console.log(res)
          );
        swal(
          'Udated!',
          'Your sub has been updated.',
          'success'
        );
      }
    });
  }

  addSubcategory() {
    swal({
      title: 'What subcategory you want to add?',
      input: 'text',
      inputPlaceholder: 'Title',
      showCancelButton: true,
      inputValidator: (value) => {
        return !value && 'You need to write something!';
      }
    }).then((result) => {
      if (result.value) {
        const obj = {
          title: result.value
        };
        this.adminService.saveSubcategory(obj)
          .subscribe((res) =>
            console.log(res)
          );
        swal(
          'Added!',
          'Your sub has been added.',
          'success'
        );
      }
    });
  }

  deleteSubcategory(id) {
    swal({
      title: 'Are you sure you want to delete this subcategory?',
      type: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes'
    }).then((result) => {
      if (result.value) {
        this.adminService.deleteSubcategory(id)
          .subscribe((res) =>
            console.log(res)
          );
        swal(
          'Deleted!',
          'Your file has been deleted.',
          'success'
        );
      }
    });

  }
}
