import { Component, OnInit } from '@angular/core';
import { ChallengeService } from '../../services/challenge.service';
import { ChallengeModel } from '../../models/challenges/challenge.model';
import { UserModel } from '../../models/users/user.model';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import { NgxCarousel } from 'ngx-carousel';
import { Router } from '@angular/router';
import { groupBy, mergeMap, toArray } from 'rxjs/operators';
import { SubCategoryModel } from '../../models/subcategories/subcategories.model';
import { UserService } from '../../services/user.service';

@Component({
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  currentUser: UserModel;

  constructor(private challengeService: ChallengeService,
    private userService: UserService,
    private router: Router) {
    this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
  }
  currentRate = 3.14;
  isAdmin = false;
  challenges$: Observable<ChallengeModel[]>;
  challengesGrouped: ChallengeModel[];
  challengesByDate: ChallengeModel[];
  subCategories$: Observable<SubCategoryModel[]>;

  public carouselTileItems: Array<any>;
  public carouselTile: NgxCarousel;

  // success message shown to user after he accepts the challenge
  succcesMessages = ['Only you can change your life', 'It always seems impossible until it\'s done!',
    'Never give up!', 'If you can dream it you can do it!',
    'Set your goals high and don\'t stop till you get there!',
    'What you do today can improve all your tomorrows!', 'Aim for the moon. If you miss, you may hit a star!',
    'Go for it now. The future is promised to no one!', 'The more things you do, the more you can do!', 'You have to make it happen!'];

  messageRnd = 0;
  ngOnInit() {
    if (localStorage.getItem('currentUser')) {
      const localUser = JSON.parse(localStorage.getItem('currentUser'));
      this.isAdmin = localUser.isAdmin;
    }
    this.messageRnd = Math.floor(Math.random() * 10);
    this.challengeService.getChallengeList().subscribe((data: ChallengeModel[]) => {
      this.challenges$ = Observable.of(data);
    });

    this.challengeService.getChallengeSubCategories().subscribe((data: SubCategoryModel[]) => {
      this.subCategories$ = Observable.of(data);
    });

    this.challengeService.getChallengeList().subscribe((data: ChallengeModel[]) => {
      this.challengesGrouped = data;
      this.challengesGrouped.sort(this.compare);
    });
    this.challengeService.getChallengeList().subscribe((data: ChallengeModel[]) => {
      this.challengesByDate = data;
      this.challengesByDate.sort(this.compareByDate);

    });

    this.carouselTileItems = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13];

    this.carouselTile = {
      grid: { xs: 2, sm: 3, md: 3, lg: 5, all: 0 },
      slide: 2,
      speed: 400,
      animation: 'lazy',
      point: {
        visible: true
      },
      load: 2,
      touch: true,

      easing: 'ease'
    };

  }

  public carouselTileLoad(evt: any) {

    const len = this.carouselTileItems.length;
    if (len <= 30) {
      for (let i = len; i < len + 10; i++) {
        this.carouselTileItems.push(i);
      }
    }

  }

  redirectToChallenge(id) {
    this.router.navigate(['challenge/' + id]);
  }

  compare(a, b) {
    if (a.completedBy < b.completedBy) {
      return 1;
    }
    if (a.completedBy > b.completedBy) {
      return -1;
    }
    return 0;
  }

  compareByDate(a, b) {
    if (a.createdAt < b.createdAt) {
      return 1;
    }
    if (a.createdAt > b.createdAt) {
      return -1;
    }
    return 0;
  }

}

