import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PairSelectionGameDto } from '@shared/models/pairselection';
import { Step } from '@shared/models/step';
import { Observable } from 'rxjs';
import { WebApiBaseService } from '../web-api-base/web-api-base.service';

@Injectable({
  providedIn: 'root'
})
export class PairSelectionService extends WebApiBaseService {

  constructor(public http: HttpClient) {
    super(http);
  }

  validatePair(option: string, pair: string): Observable<boolean> {
    let obj = { Option: option, Pair: pair }
    return this.http.post<boolean>(`${this.baseUrl}PairSelection/Validate`, obj);
  }

  saveGame(aut: PairSelectionGameDto,step:Step): Observable<any> {
    let param = {
      PairSelectionDto : aut,
      StepDto:step
    };
    return this.http.post<any>(this.baseUrl + "PairSelection",param);
  }

  getDataSelPares(id): Observable<PairSelectionGameDto> {
    return this.http.get<PairSelectionGameDto>(this.baseUrl + "PairSelection?id=" + id);
  }

  editSelPares(id,slp:PairSelectionGameDto,step:Step): Observable<PairSelectionGameDto> {
    let param = {
      PairSelectionDto : slp,
      StepDto:step
    };
    return this.http.put<PairSelectionGameDto>(this.baseUrl + "PairSelection?id=" + slp.Id, param);
  }
}
