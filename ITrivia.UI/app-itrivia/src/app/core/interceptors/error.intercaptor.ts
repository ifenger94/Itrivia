import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { AuthService } from "@shared/services/auth/auth.service";
import { Observable, throwError } from "rxjs";
import { catchError } from "rxjs/operators";


@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    constructor(private route: Router,private authService:AuthService) { }
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(req).pipe(
            catchError((err) =>{
                if([401,403].indexOf(err.status) !== -1)
                {
                    this.authService.currentUser.next(null);
                    this.authService.CleanUserLocalStorage();
                    this.route.navigateByUrl("/login");
                }
               return throwError(err);
            })
        );
    }
}