import {
  Component, ChangeDetectionStrategy,
  ViewChild,
  TemplateRef,
  OnInit
} from '@angular/core';
import * as $ from 'jquery';
import { Router } from '@angular/router';
import { UserService } from '../../services/user.service';
import { ChallengeService } from '../../services/challenge.service';
import Swal from 'sweetalert2';
import { UserChallengesModel } from '../../models/userChallenges/userchallenges.model';
import { Observable } from 'rxjs/Observable';
import { ChallengeModel } from '../../models/challenges/challenge.model';
import { Calendar } from 'fullcalendar';
import swal from 'sweetalert2';

interface Event {
  id: number;
  title: string;
  start: Date;
  end: Date;
}

@Component({
  selector: 'app-calendar',
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.css']
})

export class ChallengeCalendarComponent implements OnInit {
  obj: {};
  calendarChallenges: ChallengeModel[] = new Array<ChallengeModel>();
  title = 'app';

  constructor(private router: Router, private userService: UserService, private challengeService: ChallengeService) { }
  id = 1;
  userChallenges$: Observable<UserChallengesModel[]>;
  challengesList$: Observable<ChallengeModel[]>;
  challenges: ChallengeModel[] = new Array<ChallengeModel>();
  user_Id;
  // KALENDORIUI
  userChallenges: UserChallengesModel[];
  calendarEvents: Event[] = [];

  calendarOptions: any = {
    height: 'parent',
    header: {
      left: 'title',
      center: '',
      right: 'today prev,next'
    },
    defaultDate: Date.now(),
    editable: false,
    eventLimit: true, // allow "more" link when too many events
    views: {
      month: {
        eventLimit: 5
      }
    },
    eventClick: this.alertOnEventClick,
    events: []
  };

  ngOnInit() {
    if (localStorage.getItem('currentUser')) {
      const local = JSON.parse(localStorage.getItem('currentUser'));
      this.user_Id = local.id;
      this.loadInfo(this.user_Id);
    }
  }



  loadInfo(id) {
    this.userService.getChallengesByUserId(id).then(data => {
      this.userChallenges = data;
      this.userChallenges.forEach(ch => {
        const obj = {
          id: ch.challengeId,
          title: ch.challengeId.toString(),
          start: ch.startDate,
          end: ch.endDate
        };
        this.calendarEvents.push(obj);
      });
      this.calendarOptions.events = this.calendarEvents;
      $('#myCalendar').fullCalendar('renderEvents', this.calendarEvents, true);
    });
  }

  alertOnEventClick(obj, jsEvent, view) {
    localStorage.setItem('ob', obj.id);
    swal({
      title: obj.title + obj.id.toString(),
    }).then((result) => {
      if (result.value) {
      }
    });
  }

  redirectToChallenge(id) {
    this.router.navigate(['challenge/' + id]);
  }

  onCalendarInit(initialized: boolean) {
    this.loadInfo(this.user_Id);
    $('#myCalendar').fullCalendar('refetchEvents');
  }

}
