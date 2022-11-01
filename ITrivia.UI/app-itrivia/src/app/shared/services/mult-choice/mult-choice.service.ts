import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MultipleChoiceGameDto } from '@shared/models/multiplechoice';
import { Step } from '@shared/models/step';
import { Observable } from 'rxjs';
import { WebApiBaseService } from '../web-api-base/web-api-base.service';

@Injectable({
  providedIn: 'root'
})
export class MultChoiceService extends WebApiBaseService {

  constructor(public http: HttpClient) {
    super(http);
  }

  saveGame(aut:MultipleChoiceGameDto,step:Step): Observable<any> {
    let param = {
      MultipleChoiceDto : aut,
      StepDto:step
    };
    return this.http.post<any>(this.baseUrl + "MultipleChoice",param);
  }

  getDataMultChoice(id): Observable<MultipleChoiceGameDto> {
    return this.http.get<MultipleChoiceGameDto>(this.baseUrl + "MultipleChoice?id=" + id);
  }

  editMultChoice(id,mult:MultipleChoiceGameDto,step:Step): Observable<MultipleChoiceGameDto> {
    let param = {
      MultipleChoiceDto : mult,
      StepDto:step
    };
    return this.http.put<MultipleChoiceGameDto>(this.baseUrl + "MultipleChoice?id=" + mult.Id, param);
  }
}
