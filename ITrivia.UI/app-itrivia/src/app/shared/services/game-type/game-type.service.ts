import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { GameType } from '@shared/models/gametype';
import { Observable } from 'rxjs';
import { WebApiBaseService } from '../web-api-base/web-api-base.service';

@Injectable({
  providedIn: 'root'
})
export class GameTypeService extends WebApiBaseService {

  constructor(public http: HttpClient) {
    super(http);
  }

  getGameTypes(): Observable<Array<GameType>> {
    return this.http.get<Array<GameType>>(this.baseUrl + `Gametype`);
  }
}
