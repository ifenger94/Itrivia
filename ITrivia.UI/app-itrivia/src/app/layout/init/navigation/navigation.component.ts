import { Component, OnInit } from '@angular/core';
import { LabelService } from '@shared/services/label/label.service';
import { MessageService } from '@shared/services/message/message.service';
import {ES_LANGUAGE,EN_LANGUAGE} from '@data/contants'
import { LanguageService } from '@shared/services/language/language.service';
import { ManagmentLanguageService } from '@shared/services/language/managment-language..service';



@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss']
})


export class NavigationComponent implements OnInit {

  constructor(public labelService:LabelService ,public messageService: MessageService,private languageService:LanguageService,public managmentLangService:ManagmentLanguageService) { }

  ngOnInit(): void {
    console.log(this.labelService.labels);
  }

  changeLanguageEs(){
    this.languageService.changeLanguage(ES_LANGUAGE);
    this.managmentLangService.refreshLanguage();
  }
  
  changeLanguageEn(){
    this.languageService.changeLanguage(EN_LANGUAGE);
    this.managmentLangService.refreshLanguage();
  }
  
  //Transición de navBar About Us hacia abajo
  toAboutUs(){
    document.getElementById("aboutUs").scrollIntoView({behavior:"smooth"});
  }

 
  onWindowScroll(){
   
    let element = document.querySelector('.container');
    if (window.pageYOffset > element.clientHeight) {
      element.classList.add('nav-color');
    } else {
      element.classList.remove('nav-color');
    }
  }
}