import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { HomeComponent } from '../components/home/home.component';
import { LoginComponent } from '../components/login/login.component';
import { RegisterComponent } from '../components/register/register.component';
import { AboutComponent } from '../components/about/about.component';
import { ChallengeComponent } from '../components/challenge/challenge.component';
import { ChallengeDetailsComponent } from '../components/challenge/details/challenge-details.component';
import { UserComponent } from '../components/userList/user.component';
import { UserDetailsComponent } from '../components/user-details/user-details.component';
import { ChallengeCalendarComponent } from '../components/calendar/challengeCalendar.component';
import { AuthGuard } from '../services/guards/auth.guard';
import { AdminComponent } from '../components/admin/admin.compponent';

@NgModule({
  imports: [
      RouterModule.forRoot([
          { path: '' , component: HomeComponent},
          { path: 'login' , component: LoginComponent},
          { path: 'register' , component: RegisterComponent},
          { path: 'about' , component: AboutComponent},
          { path: 'challenges' , component: ChallengeComponent},
          { path: 'challenge/new', component: ChallengeDetailsComponent },
          { path: 'challenge/:id', component: ChallengeDetailsComponent },
          { path: 'user/:id', component: UserDetailsComponent },
          { path: 'users', component: UserComponent },
          { path: 'admin', component: AdminComponent },
          { path: 'calendar', component: ChallengeCalendarComponent, canActivate: [AuthGuard]}  ,

          // otherwise redirect to home
          { path: '**', redirectTo: '' }
      ])
  ],
  exports: [
      RouterModule
  ]
})
export class AppRoutingModule {}
