import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';

@Injectable({
  providedIn: 'root'
})
export class WebApiBaseService {
  public baseUrl = environment.uri;
  constructor(protected http: HttpClient) { }
}
