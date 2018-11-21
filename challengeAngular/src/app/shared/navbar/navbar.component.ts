import { Component, OnInit } from '@angular/core';
import { LoginComponent } from '../../components/login/login.component';
import { Router } from '@angular/router';
import { AuthenticationService } from '../../services/authentication.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  user;
  isAdmin = false;
  constructor(private router: Router,
    private authenticationService: AuthenticationService) { }

  ngOnInit() {
    if (localStorage.getItem('currentUser')) {
      const localUser = JSON.parse(localStorage.getItem('currentUser'));
      this.isAdmin = localUser.isAdmin;
    }
  }

  public isAuthenticated(): boolean {
    // Check whether the current time is past the
    // Access Token's expiry time
    if (!localStorage.getItem('currentUser')) {
      return false;
    }
    this.user = JSON.parse( localStorage.getItem('currentUser'));
    return true;
  }

  navigateToUserProfile(id) {
    this.router.navigate(['user/' + id]);
  }

  logout() {
   this.authenticationService.logout();
  }

}
