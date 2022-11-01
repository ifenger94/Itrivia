import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import { LanguageService } from '../language/language.service';
import { WebApiBaseService } from '../web-api-base/web-api-base.service';

@Injectable({
  providedIn: 'root'
})
export class LabelService extends WebApiBaseService {
  
  public labels = {};
  
  constructor(http: HttpClient,private languageService:LanguageService) {
    super(http);
    this.getAllLabels();

   }

  private getAllLabels(): void {
    this.http.get<any>(`${this.baseUrl}label/${this.languageService.getLanguage}`).subscribe(response => {
      this.labels = response;
    });
  }

  public refreshLabels():Observable<any>{
    return this.http.get<any>(`${this.baseUrl}label/${this.languageService.getLanguage}`);
  }
}
