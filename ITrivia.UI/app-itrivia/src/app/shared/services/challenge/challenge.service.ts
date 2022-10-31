import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { WebApiBaseService } from '../web-api-base/web-api-base.service';
import { sectionCard } from '@shared/models/section-card';
import { Challenge } from '@shared/models/challenge';


@Injectable({
  providedIn: 'root'
})
export class ChallengesService extends WebApiBaseService {
  section: Observable<any>;

  constructor(public http: HttpClient) {
    super(http);
  }


  getChallengesBySectionId(id):Observable<Array<Challenge>>{
    return this.http.get<Array<Challenge>>(`${this.baseUrl}Section/${id}/Challenge`);
  }

  getChallengeByCompany(companyId):Observable<Array<Challenge>>{
    return this.http.get<Array<Challenge>>(`${this.baseUrl}Challenge/${companyId}/Company`);
  }

  getChallenge(id): Observable<Challenge> {
    return this.http.get<Challenge>(this.baseUrl + "Challenge/" + id);
  }

  editChallenge(id,challenge): Observable<Challenge> {
    return this.http.put<Challenge>(this.baseUrl +"Challenge/" + id,challenge);
  }

  addChallenge(section): Observable<Challenge> {
    return this.http.post<Challenge>(this.baseUrl + 'Challenge', section);
  }

  deleteSection(id): Observable<Challenge> {
    return this.http.delete<Challenge>(this.baseUrl + "Challenge/" + id);
  }
}
