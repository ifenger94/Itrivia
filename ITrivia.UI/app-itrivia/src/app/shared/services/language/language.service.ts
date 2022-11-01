import { Injectable } from '@angular/core';
import { DEFAULT_LANGUAGE ,ES_LANGUAGE} from '@data/contants';
import { BehaviorSubject } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class LanguageService {
  private languageStorage = 'language';
  public defaultLanguaje: BehaviorSubject<string>;


  constructor() {
    this.defaultLanguaje = new BehaviorSubject
      (
        JSON.parse(localStorage.getItem(this.languageStorage)) || DEFAULT_LANGUAGE
      )
  }

  public changeLanguage(code: "es" | "en") {
    this.defaultLanguaje.next(code);
    this.setLanguageLocalStorage(code);
  }

  public get getLanguage() {
    return this.defaultLanguaje.value;
  }

  setLanguageLocalStorage(code: "es" | "en") {
    localStorage.setItem(this.languageStorage, JSON.stringify(code));
  }
}