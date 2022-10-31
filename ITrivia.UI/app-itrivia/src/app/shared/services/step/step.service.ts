import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Step } from '@shared/models/step';
import { StepDetail } from '@shared/models/stepDetail';
import { Observable } from 'rxjs';
import { WebApiBaseService } from '../web-api-base/web-api-base.service';

@Injectable({
  providedIn: 'root'
})
export class StepService extends WebApiBaseService {

  constructor(public http: HttpClient) {
    super(http);
  }

  getStepDetailByChallengeId(id:number):Observable<Array<StepDetail>>{
    return this.http.get<Array<StepDetail>>(this.baseUrl + "step/GetStepByChallenge?challengeId=" + id);
  }

  getStepByChallengeId(id:number):Observable<Array<Step>>{
    return this.http.get<Array<Step>>(this.baseUrl + "step/GetStepByChallenge?challengeId=" + id);
  }

  getStepById(id:number):Observable<Array<StepDetail>>{
    return this.http.get<Array<StepDetail>>(this.baseUrl + "step?Id=" + id);
  }

  getStepByGameType(id:number):Observable<StepDetail>{
    return this.http.get<StepDetail>(this.baseUrl + "step?Id=" + id);
  }
  save(item:Step):Observable<Step>{
    return this.http.post<Step>(this.baseUrl + "step",item);
  }

  editStep(id, step): Observable<Step> {
    return this.http.put<Step>(this.baseUrl + "Section/" + id, step);
  }

  deleteStep(id): Observable<Step> {
    return this.http.delete<Step>(this.baseUrl + "Step/" + id);
  }
}
