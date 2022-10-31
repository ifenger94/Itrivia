import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { AuthService } from "@shared/services/auth/auth.service";
import { LanguageService } from "@shared/services/language/language.service";
import { Observable } from "rxjs";


@Injectable()
export class LanguageInterceptor implements HttpInterceptor {
    constructor(private languageService: LanguageService) { }
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        req = req.clone({
            setHeaders: {
                "Language": this.languageService.getLanguage
            }
        });
        return next.handle(req);
    }

}