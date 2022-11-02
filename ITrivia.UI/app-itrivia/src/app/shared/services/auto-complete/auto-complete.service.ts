import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AutoCompleteResult } from '@shared/models/auto-complete-result';
import { AutocompleteGameDto } from '@shared/models/autocomplete';
import { Step } from '@shared/models/step';
import { Observable } from 'rxjs';
import { WebApiBaseService } from '../web-api-base/web-api-base.service';

@Injectable({
  providedIn: 'root'
})
export class AutoCompleteService extends WebApiBaseService {

  constructor(public http: HttpClient) {
    super(http);
  }

  validateAnswer(id: number, answer: string): Observable<AutoCompleteResult> {
    return this.http.get<AutoCompleteResult>(this.baseUrl + "Autocomplete/" + id + "/validateanswer?answer=" + answer);
  }

  saveGame(aut:AutocompleteGameDto,step:Step): Observable<any> {
    let param = {
      AutoCompleteDto : aut,
      StepDto:step
    };
    return this.http.post<any>(this.baseUrl + "Autocomplete",param);
  }

  getDataAutocomplete(id): Observable<AutocompleteGameDto> {
    return this.http.get<AutocompleteGameDto>(this.baseUrl + "Autocomplete?id=" + id);
  }

  editAutocomplete(id,aut:AutocompleteGameDto,step:Step): Observable<AutocompleteGameDto> {
    let param = {
      AutoCompleteDto : aut,
      StepDto:step
    };
    return this.http.put<AutocompleteGameDto>(this.baseUrl + "Autocomplete?id=" + aut.Id, param);
  }

}
