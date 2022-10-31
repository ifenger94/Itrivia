import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { WebApiBaseService } from '../web-api-base/web-api-base.service';
import { sectionCard } from '@shared/models/section-card';
import { Section } from '@shared/models/section';
import { SectionDetail } from '@shared/models/section-detail';
import { IFilterSectionManagment } from '@shared/models/filters/ifilter-section-managment';


@Injectable({
  providedIn: 'root'
})

export class SectionService extends WebApiBaseService {
  constructor(public http: HttpClient) {
    super(http);
  }


  getSections(): Observable<Array<Section>> {
    return this.http.get<Array<Section>>(this.baseUrl + "Section");
  }

  getSectionsFilter(filter:IFilterSectionManagment): Observable<Array<Section>> {
    return this.http.get<Array<Section>>(this.baseUrl + 
      `Section/GetSectionFilter?profileId=${filter.profileId}&categoryId=${filter.categoryId == -1 ? '':filter.categoryId}&search=${filter.search}`);
  }

  getSection(id): Observable<Section> {
    return this.http.get<Section>(this.baseUrl + "Section/" + id);
  }

  getSectionByProfile(id): Observable<Array<Section>> {
    return this.http.get<Array<Section>>(this.baseUrl + "Section?profileId=" + id);
  }

  deleteSection(id): Observable<Section> {
    return this.http.delete<Section>(this.baseUrl + "Section/" + id);
  }

  addSection(section): Observable<Section> {
    return this.http.post<Section>(this.baseUrl + 'Section', section);
  }


  editSection(id, section): Observable<Section> {
    return this.http.put<Section>(this.baseUrl + "Section/" + id, section);
  }
}
