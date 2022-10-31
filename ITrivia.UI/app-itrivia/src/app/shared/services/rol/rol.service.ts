import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Rol } from '@shared/models/rol';
import { Observable } from 'rxjs';
import { WebApiBaseService } from '../web-api-base/web-api-base.service';

@Injectable({
  providedIn: 'root'
})
export class RolService extends WebApiBaseService{

  constructor(public http: HttpClient) {
    super(http);
  }

  public getRolById(id):Observable<Rol>{
    return this.http.get<Rol>(this.baseUrl + 'Rol/' + id);
  }
}
