import { Component, OnInit } from '@angular/core';
import { ChallengeModel } from '../../../models/challenges/challenge.model';
import { ActivatedRoute, Router, Params } from '@angular/router';
import { ChallengeService } from '../../../services/challenge.service';
import { UserModel } from '../../../models/users/user.model';
import { UserService } from '../../../services/user.service';
import { Observable } from 'rxjs/Observable';
import { SubCategoryModel } from '../../../models/subcategories/subcategories.model';
import { CategoryModel } from '../../../models/categories/categories.model';
import Swal from 'sweetalert2';
import { Title } from '@angular/platform-browser';
import { debug } from 'util';
import { UserChallengesModel } from '../../../models/userChallenges/userchallenges.model';
import { isEmpty } from 'rxjs/operator/isEmpty';


@Component({
  styleUrls: ['./challenge-details.component.css'],
  templateUrl: './challenge-details.component.html'
})

export class ChallengeDetailsComponent implements OnInit {
  accept = 'Accept challenge';
  challengeInfo: ChallengeModel = new ChallengeModel();
  obj: UserChallengesModel = new UserChallengesModel();
  user_Id;
  activeParameter: any;
  usersList$: Observable<UserModel[]>;
  subCategories$: Observable<SubCategoryModel[]>;
  categories$: Observable<CategoryModel[]>;
  constructor(private router: Router,
    private challengeService: ChallengeService,
    private activeRoute: ActivatedRoute,
    private userService: UserService
  ) { }

  ngOnInit() {
    this.isAuthenticated();
    if (localStorage.getItem('currentUser')) {
      const local = JSON.parse(localStorage.getItem('currentUser'));
      this.user_Id = local.id;
    } else {
      this.user_Id = 0;
    }
    this.activeRoute.params.subscribe((params: Params) => {
      this.activeParameter = params['id'];
    });
    if (this.activeParameter) {
      this.challengeService.getChallengeById(this.activeParameter).subscribe((response: ChallengeModel) => {
        this.challengeInfo = response;
        this.checkIfTaken(this.challengeInfo.id);


      });
    } else {
      //  this.challengeInfo = new ChallengeModel();
    }

    this.challengeService.getChallengeSubCategories().subscribe((data: SubCategoryModel[]) => {
      this.subCategories$ = Observable.of(data);
    });
    this.challengeService.getChallengeCategories().subscribe((data: CategoryModel[]) => {
      this.categories$ = Observable.of(data);
    });

  }
  startChallenge(challengeId) {
    this.challengeService.acceptChallenge(challengeId, this.user_Id)
      .subscribe(res => {
        console.log(res);
        this.router.navigate(['/challenges']);
      });
    Swal({
      title: 'Challenge accepted!',
      text: 'Good luck!',
      type: 'success'
    });
    this.accept = 'Accepted';
  }
  // Check if user has already taken the challenge
  checkIfTaken(challengeId) {
    if (this.user_Id) {
      this.userService.getChallengeByUserIdChallengeId(challengeId, this.user_Id).subscribe((res: UserChallengesModel) =>
      {
        if(res['userId'] == this.user_Id) this.accept = "Accepted";
        
      });
    }
  }
  Disabled()
  {
    if (this.accept == "Accepted")
    {
      return true;
    } 
    else return false;
  }
  public isAuthenticated(): boolean {
    if (!localStorage.getItem('currentUser')) {
      return false;
    }
    return true;
  }

}
