import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MenuService {
  fullLoader: boolean;
  showMenu: boolean;

  constructor() {
    this.fullLoader = false;
    this.showMenu = true;
  }

  loaderActive() {
    this.fullLoader = true;
    setTimeout(() => {
      this.fullLoader = false;
    }, 1000);
  }
}
