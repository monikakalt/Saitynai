import { Injectable } from '@angular/core';
import { Http, Headers, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Router } from '@angular/router';

@Injectable()
export class AuthenticationService {
  constructor(private http: Http, public router: Router) { }

  url = 'http://localhost:59372';

  login(username: string, password: string) {
    return this.http.post(this.url + '/users/authenticate', { username: username, password: password })
      .map((response: Response) => {
        // login successful if there's a jwt token in the response
        const user = response.json();
        if (user && user.token) {
          // store user details and jwt token in local storage to keep user logged in between page refreshes
          localStorage.setItem('currentUser', JSON.stringify(user));
        }
      });
  }

  logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('currentUser');
    localStorage.clear();
    this.router.navigate(['/']);
  }

  public userHasScopes(scopes: Array<string>): boolean {
    const grantedScopes = JSON.parse(localStorage.getItem('scopes')).split(' ');
    return scopes.every(scope => grantedScopes.includes(scope));
  }

}
