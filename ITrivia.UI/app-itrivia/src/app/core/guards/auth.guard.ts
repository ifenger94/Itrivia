import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { AuthService } from '@shared/services/auth/auth.service';
import { Observable } from 'rxjs';
import { ROUTE_LOGIN } from '@data/contants';
@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(
    private router: Router,
    private authService: AuthService) { }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    const user = this.authService.getUser;
    if (!!user && user.Jwt) {
      if (!!route.data.roles && !this.authService.hasPermission(route.data.roles)) {
        this.router.navigate(['Managment/403']);
        return false;
      }
      return true;
    }
    else {
      this.router.navigate([`${ROUTE_LOGIN}`], {
        queryParams: { returnUrl: state.url }
      })
      return false;
    }
  }

}
