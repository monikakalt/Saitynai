import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { UserModel } from '../../models/users/user.model';
import { UserService } from '../../services/user.service';
import { Router } from '@angular/router';
import * as $ from 'jquery';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  page = 4;
  users$: Observable<UserModel[]>;
  sortedUsers$: UserModel[];
  constructor(private userService: UserService,
    private router: Router, ) { }

  ngOnInit() {
    this.userService.getUsersList().subscribe((data: UserModel[]) => {
      this.users$ = Observable.of(data);
      this.sortedUsers$ = data;
      this.sortedUsers$.sort(this.compare);
    });
  }

  public getRandomColor() {
    const letters = '0123456789ABCDEF'.split('');
    let color = '#';
    for (let i = 0; i < 6; i++) {
      color += letters[Math.floor(Math.random() * 16)];
    }
    return color;
  }

  compare(a, b) {
    if (a.points > b.points) {
      return -1;
    }
    if (a.points < b.points) {
      return 1;
    }
    return 0;
  }

  routeToUser(id) {
    this.router.navigate(['user/' + id]);
  }

  getPoints(id, max) {
    const x = this.sortedUsers$[id].points * 100 / (max + 100);
    return x + '%';
  }
}
