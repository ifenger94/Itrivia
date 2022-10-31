import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { AuthService } from "@shared/services/auth/auth.service";
import { LanguageService } from "@shared/services/language/language.service";
import { Observable } from "rxjs";


@Injectable()
export class JwtInterceptor implements HttpInterceptor {
    constructor(private authServie: AuthService,private languageService:LanguageService) { }
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const currentUser = this.authServie.getUser;
        if (currentUser != null && !!currentUser.Jwt) {
            req = req.clone({
                setHeaders: {
                    "Authorization": `Bearer ${currentUser.Jwt}`,
                    "Language" : this.languageService.getLanguage
                }
            });
        }
        return next.handle(req);
    }

}