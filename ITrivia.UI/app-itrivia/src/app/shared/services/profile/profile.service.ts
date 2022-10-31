import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Profile } from '@shared/models/profile';
import { BehaviorSubject } from 'rxjs';
import { Observable } from 'rxjs';
import { AuthService } from '../auth/auth.service';
import { WebApiBaseService } from '../web-api-base/web-api-base.service';

@Injectable({
  providedIn: 'root'
})
export class ProfileService extends WebApiBaseService {

  constructor(public http: HttpClient, private authService: AuthService) {
    super(http);
  }

  getProfileById(id: number): Observable<Profile> {
    return this.http.get<Profile>(this.baseUrl + "Profile/" + id);
  }

  addExperienceAndHistory(challengeId: number): Observable<any> {
    const profileId = this.authService.getUser.ProfileId;
    return this.http.put(this.baseUrl + "Profile/AddExperence/" + profileId + "?challengeId=" + challengeId, null);
  }

}
