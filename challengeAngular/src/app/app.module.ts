import { MatDialogModule } from '@angular/material';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CalendarModule } from 'ap-angular2-fullcalendar';
import {
  NgbModule, NgbRatingConfig, NgbPaginationConfig, NgbProgressbarConfig, NgbDatepickerConfig,
  NgbDateStruct, NgbTooltipConfig
} from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { NgxCarouselModule } from 'ngx-carousel';
import 'hammerjs';
import { Md5 } from 'ts-md5/dist/md5';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './shared/app.routing';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { ChallengeComponent } from './components/challenge/challenge.component';
import { AboutComponent } from './components/about/about.component';
import { NavbarComponent } from './shared/navbar/navbar.component';
import { FooterComponent } from './shared/footer/footer.component';
import { UserService } from './services/user.service';
import { ChallengeService } from './services/challenge.service';
import { AuthenticationService } from './services/authentication.service';
import { HttpModule } from '@angular/http';
import { ChallengeCategoriesFilterPipe } from './pipes/challenge-filter.pipe';
import { AddChallengeComponent } from './components/challenge/add-challenge.component';
import { HomeComponent } from './components/home/home.component';
import { ChallengeDetailsComponent } from './components/challenge/details/challenge-details.component';
import { UserComponent } from './components/userList/user.component';
import { UserDetailsComponent } from './components/user-details/user-details.component';
import { ChallengeCalendarComponent } from './components/calendar/challengeCalendar.component';
import { AuthGuard } from './services/guards/auth.guard';
import { Alert } from 'selenium-webdriver';
import { AlertService } from './services/alert.service';
import { FormatTimePipe } from './pipes/countdown.pipe';
import { ConfirmEqualValidatorDirective } from './shared/confirm-equal-validator.directive';
import { ChallengeFilterComponent } from './components/challenge/filter/challenge-filter.component';
import { AdminComponent } from './components/admin/admin.compponent';
import { AdminService } from './services/admin.service';
import { SubcategoryDetailsComponent } from './components/admin/subcategory-details/subcategory-details.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    ChallengeComponent,
    AboutComponent,
    NavbarComponent,
    FooterComponent,
    ChallengeCategoriesFilterPipe,
    FormatTimePipe,
    AddChallengeComponent,
    ChallengeDetailsComponent,
    UserComponent,
    UserDetailsComponent,
    ChallengeCalendarComponent,
    ChallengeFilterComponent,
    ConfirmEqualValidatorDirective,
    AdminComponent,
    SubcategoryDetailsComponent
  ],
  imports: [
    BrowserModule,
    NgxCarouselModule,
    CalendarModule,
    FormsModule,
    AngularFontAwesomeModule,
    ReactiveFormsModule,
    HttpModule,
    NgbModule.forRoot(),
    AppRoutingModule,
    BrowserAnimationsModule
  ],
  providers: [
    UserService,
    ChallengeService,
    AuthenticationService,
    AuthGuard,
    NgbPaginationConfig,
    AlertService,
    AdminService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
