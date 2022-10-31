import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ES_LANGUAGE } from '@data/contants';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import { LanguageService } from '../language/language.service';
import { WebApiBaseService } from '../web-api-base/web-api-base.service';

@Injectable({
  providedIn: 'root'
})
export class MessageService extends WebApiBaseService{
  public messages = {};
  
  constructor(http: HttpClient,private languageSerice:LanguageService) {
    super(http)
    this.getAllMessages();
   }

  private getAllMessages(): void {
    this.http.get<any>(`${this.baseUrl}messages/${this.languageSerice.getLanguage}`).subscribe(response => {
      this.messages = response;
    });
  }

  public refreshMessages():Observable<any>{
    return this.http.get<any>(`${this.baseUrl}messages/${this.languageSerice.getLanguage}`);
  }
}
