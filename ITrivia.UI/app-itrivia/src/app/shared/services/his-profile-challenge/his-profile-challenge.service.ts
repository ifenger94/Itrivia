import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ExperienceHistory } from '@shared/models/experience-history';
import { HistoryPD } from '@shared/models/historypd';
import { Observable } from 'rxjs';
import { WebApiBaseService } from '../web-api-base/web-api-base.service';

@Injectable({
  providedIn: 'root'
})
export class HisProfileChallengeService extends WebApiBaseService {

  constructor(public http: HttpClient) {
    super(http);
  }

  getHisProfileChallengeByProfileId(id:number):Observable<Array<HistoryPD>>{
    return this.http.get<Array<HistoryPD>>(this.baseUrl + "HistoryPD?profileId=" + id );
  }

  getExpHistoryByProfile(id:number):Observable<Array<ExperienceHistory>>{
    return this.http.get<Array<ExperienceHistory>>(this.baseUrl + "HistoryPD/WeeklyExperienceByProfile/" + id );
  }
}
