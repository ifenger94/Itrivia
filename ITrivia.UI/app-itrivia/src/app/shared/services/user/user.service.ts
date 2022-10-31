import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SummaryUserProfile } from '@shared/models/summaryuserprofile';
import { User } from '@shared/models/user';
import { UserDetail } from '@shared/models/user-detail';
import { userFields } from '@shared/models/user-fields';
import { BehaviorSubject, Observable } from 'rxjs';
import { AuthService } from '../auth/auth.service';
import { WebApiBaseService } from '../web-api-base/web-api-base.service';

@Injectable({
  providedIn: 'root'
})
export class UserService extends WebApiBaseService {

  private user: BehaviorSubject<UserDetail>;

  constructor(public http: HttpClient, private authService: AuthService) {
    super(http);
    this.user = new BehaviorSubject<UserDetail>(null);
  }

  public loadCurrentUser(): void {
    this.http.get<UserDetail>(this.baseUrl + 'user/detail/' + this.authService.getUser.UserId).subscribe(usrDetail => {
      this.user.next(usrDetail);
    });
  }

  get currentUser(): Observable<UserDetail> {
    return this.user.asObservable();
  }

  getSummaryUserProfile(): Observable<Array<SummaryUserProfile>> {
    return this.http.get<Array<SummaryUserProfile>>(this.baseUrl + "user/SummaryUserProfile");
  }

  getUsersByCompany(companyId): Observable<Array<User>> {
    return this.http.get<Array<User>>(this.baseUrl + "user/company/" + companyId);
  }

  getUser(id): Observable<User> {
    return this.http.get<User>(this.baseUrl + "User/" + id);
  }

  register(user: userFields) {
    return this.http.post(this.baseUrl + 'user', user);
  }

  updateUser(user: User) {
    console.log(user);
    return this.http.put(this.baseUrl + 'user/' + user.Id, user);
  }

  resetPassword(param:{Id:number,Password:string,Password2:string}) {
    return this.http.put(this.baseUrl + 'user/resetpassword/' + param.Id, param);
  }

  delete(id:number) {
    return this.http.delete(this.baseUrl + 'user/' + id);
  }
}
