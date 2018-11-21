import { Component } from '@angular/core';
import { Router, Params, ActivatedRoute } from '@angular/router';
import { UserModel } from '../../models/users/user.model';
import { AuthenticationService } from '../../services/authentication.service';
import { UserService } from '../../services/user.service';
import { Observable } from 'rxjs/';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import Swal from 'sweetalert2';
import { ViewChild, ElementRef } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { AlertService } from '../../services/alert.service';

declare var $: any;
@Component({
  selector: 'registerForm',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

  // user: UserModel = new UserModel;
  loading = false;
  registerForm: FormGroup;
  user: UserModel = new UserModel;
  @ViewChild('registerModal') public modal: ModalDirective;

  constructor(private formBuilder: FormBuilder,
    private userService: UserService,
    private alertService: AlertService,
    private router: Router) {

    this.registerForm = formBuilder.group({
      'fullName': [null, Validators.required],
      'username': [null, Validators.required],
      'email': [null, [Validators.required, Validators.email]],
      'password': [null, Validators.required],
      'confirmPassword': [null, Validators.required],
    });

  }

  openLogin() {
    `<loginForm></loginForm>`;
  }

  submitForm(value: any): void {
    console.log(this.router.url);
    this.user.fullName = value.fullName;
    this.user.username = value.username;
    this.user.password = value.password;
    this.user.email = value.email;
    this.user.imgUrl = '';

    this.userService.createUser(this.user).subscribe(res => {
      Swal({
        title: 'Registration successful!',
        text: 'You can login now',
        type: 'success'
      });
      $('#registerModal').modal('hide');
      this.router.navigate(['']);
    },
      (err) => {
        this.alertService.error(err._body);
        this.loading = false;
      });
  }


}

