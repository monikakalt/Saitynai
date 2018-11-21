import { Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/toPromise';
import { UserModel } from '../models/users/user.model';
import { UserChallengesModel } from '../models/userChallenges/userchallenges.model';
import { ChallengeModel } from '../models/challenges/challenge.model';

@Injectable()
export class UserService {
  url = 'http://localhost:59372/users';
  urlUserChallenges = 'http://localhost:59372/userchallenges/';

  constructor(private http: Http) { }
  private jwt() {
    // create authorization header with jwt token
    const currentUser = JSON.parse(localStorage.getItem('currentUser'));
    if (currentUser && currentUser.token) {
      const headers = new Headers({ 'Authorization': 'Bearer ' + currentUser.token });
      return new RequestOptions({ headers: headers });
    }
  }

  // Users
  getAll() {
    return this.http.get(this.url, this.jwt())
      .map((response: Response) => response.json());
  }

  getUsersList(): Observable<UserModel[]> {
    return this.http.get(this.url)
      .map((res: Response) => res.json() as UserModel[])
      .catch((error: any) => Observable.throw(error));
  }

  getChallengesByUserId(id): Promise<UserChallengesModel[]> {
    return this.http.get(this.urlUserChallenges + id)
      .toPromise()
      .then((response) => {
        return response.json() as UserChallengesModel[];
      });
  }

  // Single user by id
  getUserById(id): Observable<UserModel> {
    return this.http.get(this.url + '/' + id)
      .map((res: Response) => res.json() as UserModel)
      .catch((error: any) => Observable.throw(error));
  }
  // Single user by username
  getUserByUsername(username): Observable<UserModel> {
    return this.http.get(this.url + '/username=' + username)
      .map((res: Response) => res.json() as UserModel)
      .catch((error: any) => Observable.throw(error));
  }
  // Single user by email
  getUserByEmail(email): Observable<UserModel> {
    return this.http.get(this.url + '/email=' + email)
      .map((res: Response) => res.json() as UserModel)
      .catch((error: any) => Observable.throw(error));
  }

  updateUser(user): Observable<UserModel> {
    return this.http.put(this.url + '/' + user.id, user, this.jwt())
      .map((res: Response) => res.json() as UserModel)
      .catch((error: any) => Observable.throw(error));
  }

  createUser(user): Observable<UserModel> {
    return this.http.post(this.url, user, this.jwt())
      .map((res: Response) => res.json() as UserModel)
      .catch((error: any) => Observable.throw(error));
  }


  deleteUserChallenge(userId, challengeId): Observable<UserChallengesModel[]> {
    return this.http.delete(this.url + '/' + userId, challengeId)
      .map((res: Response) => res.json() as UserChallengesModel)
      .catch((error: any) => Observable.throw(error));
  }

  getUserChallenges(id): Observable<UserChallengesModel[]> {
    return this.http.get(this.urlUserChallenges + id, this.jwt())
      .map((res: Response) => res.json() as UserChallengesModel[])
      .catch((error: any) => Observable.throw(error));
  }

  updateUserChallenge(challengeId, userId, user): any {
    return this.http.put('http://localhost:59372/userChallenges' + '/' + challengeId + '?userId=' + userId, user)
      .map((res: Response) => res.json() as any)
      .catch((error: any) => Observable.throw(error));
  }

  getChallengeByUserIdChallengeId(challengeId, userId): any {
    return this.http.get('http://localhost:59372/userChallenges' + '/' + challengeId + 'userId=' + userId, '')
      .map((res: Response) => res.json() as any)
      .catch((error: any) => Observable.throw(error));
  }

}
