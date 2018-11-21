import { Component, OnInit, ViewChild } from '@angular/core';
import { Router, Params, ActivatedRoute } from '@angular/router';
import { UserModel } from '../../models/users/user.model';
import { AuthenticationService } from '../../services/authentication.service';
import { UserService } from '../../services/user.service';
import { Observable } from 'rxjs/';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Http } from '@angular/http';
import { AlertService } from '../../services/alert.service';
import { ModalDirective } from 'ngx-bootstrap/modal';
import Swal from 'sweetalert2';

declare var $: any;
@Component({
  selector: 'loginForm',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  authenticated: boolean;
  user: Object;
  us: UserModel;
  loading = false;
  returnUrl: string;
  logError = false;
  error;
  @ViewChild('loginModal') public modal: ModalDirective;

  constructor(formBuilder: FormBuilder, public http: Http,
    private authenticationService: AuthenticationService,
    private route: ActivatedRoute,
    private router: Router,
    private alertService: AlertService
  ) {
    if (localStorage.getItem('currentUser')) {
      this.authenticated = true;
      this.user = JSON.parse(localStorage.getItem('currentUser'));
    }

    this.loginForm = formBuilder.group({
      'username': [null, Validators.required],
      'password': [null, Validators.required],
    });

  }

  ngOnInit() {

  }

  submitForm(value: any) {
    this.loading = true;
    this.authenticationService.login(value.username, value.password)
      .subscribe(
        data => {
          Swal({
            title: 'Login successful!',
            type: 'success'
          });
         $('#loginModal').modal('hide');
          this.router.navigate(['']);
        },
          (err) => {
            this.alertService.error(err._body);
            this.logError = true;
            this.loading = false;
          });
  }

  public logout(): void {
    // Remove tokens and expiry time from localStorage
    this.authenticationService.logout();
    // Go back to the home route
    this.router.navigate(['/']);

  }

}
