import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { DEFAULT_ROUTE_AUTH, DEFAULT_ROUTE_AUTH_USERS, DEFAULT_ROUTE_LOGOUT, ROLES_ENUM } from '@data/contants';
import { IApiUserAuthenticated } from '@shared/interfaces/IApiUserAuthenticated';
import { IApiUserToken } from '@shared/interfaces/IApiUserToken';
import { userCredentials } from '@shared/models/user-credentials';
import { userFields } from '@shared/models/user-fields';
import { environment } from 'environments/environment';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { WebApiBaseService } from '../web-api-base/web-api-base.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService extends WebApiBaseService {
  private userLocalStorage = 'currentUser';
  private rememberLocalStorage = 'remember';
  private timeoutRefreshToken;

  public currentUser: BehaviorSubject<IApiUserAuthenticated>;

  constructor(http: HttpClient, private route: Router) {
    super(http);
    this.currentUser = new BehaviorSubject
      (
        JSON.parse(localStorage.getItem(this.userLocalStorage))
      )

    if (this.getUser != null && JSON.parse(localStorage.getItem(this.rememberLocalStorage)))
      this.setRefreshToken();
  }

  get getUser(): IApiUserAuthenticated {
    return this.currentUser.value;
  }

  get rememberSession(): boolean {
    return JSON.parse(localStorage.getItem(this.rememberLocalStorage));
  }

  login(user: userCredentials, remember: boolean): Observable<IApiUserAuthenticated> {
    return this.http.post<IApiUserAuthenticated>(`${this.baseUrl}Login/Authenticate`, user)
      .pipe(
        map(r => {
          if (remember) {
            this.setUserLocalStorage(r);
            this.setRememberLocalStorage(remember);
          }
          else {
            this.CleanUserLocalStorage();
            this.CleanRememberLocalStorage();
          }

          this.currentUser.next(r)
          this.redirectByRol();
          this.setRefreshToken();
          return r;
        })
      )
  }

  refreshToken() {
    if (this.getUser != null) {
      this.http.get<IApiUserToken>(`${this.baseUrl}Login/RefreshToken`).subscribe(userToken => {
        var user = this.getUser;
        user.Jwt = userToken.Token;
        user.LifeTime = userToken.ExpirationDate;
        if (this.rememberSession)
          this.setUserLocalStorage(user);
        this.currentUser.next(user);
        this.setRefreshToken();
      });
    }
  }

  setUserLocalStorage(user: IApiUserAuthenticated) {
    localStorage.setItem(this.userLocalStorage, JSON.stringify(user));
  }

  setRememberLocalStorage(remember: boolean) {
    localStorage.setItem(this.rememberLocalStorage, JSON.stringify(remember));
  }

  CleanUserLocalStorage() {
    localStorage.removeItem(this.userLocalStorage);
  }

  CleanRememberLocalStorage() {
    localStorage.removeItem(this.rememberLocalStorage);
  }

  logout() {
    localStorage.removeItem(this.userLocalStorage);
    this.currentUser.next(null);

    if (this.timeoutRefreshToken != null)
      clearTimeout(this.timeoutRefreshToken);

    this.route.navigateByUrl(DEFAULT_ROUTE_LOGOUT);
  }

  setRefreshToken() {
    var refreshDate = new Date(this.getUser.LifeTime);
    refreshDate.setMinutes(refreshDate.getMinutes() - 1);
    this.timeoutRefreshToken = setTimeout(() => {
      this.refreshToken();
    }, refreshDate.getTime() - Date.now());
  }

  hasPermission(roles: ROLES_ENUM[]): boolean {
    return roles.includes(this.getUser.RolCode);
  }

  redirectByRol() {
    switch (this.getUser.RolCode) {
      case ROLES_ENUM.USER:
        this.route.navigateByUrl(DEFAULT_ROUTE_AUTH_USERS);
        break
      default:
        this.route.navigateByUrl(DEFAULT_ROUTE_AUTH);
        break;
    }
  }
}
