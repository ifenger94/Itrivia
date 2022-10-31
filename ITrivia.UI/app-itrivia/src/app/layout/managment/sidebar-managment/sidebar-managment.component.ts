import { Component, OnInit } from '@angular/core';
import { AuthService } from '@shared/services/auth/auth.service';
import { LabelService } from '@shared/services/label/label.service';
import { MessageService } from '@shared/services/message/message.service';
import { ES_LANGUAGE, EN_LANGUAGE, ILeftNavMenu } from '@data/contants'
import { LanguageService } from '@shared/services/language/language.service';
import { getLocaleExtraDayPeriodRules } from '@angular/common';
import { RolService } from '@shared/services/rol/rol.service';
import { Rol } from '@shared/models/rol';
import { UserService } from '@shared/services/user/user.service';
import { User } from '@shared/models/user';
import { LEFT_NAV_MENU_MANAGMENT } from '@data/contants/Menus/left-nav-menu-managment';
import { UserDetail } from '@shared/models/user-detail';
import { MenuService } from '@shared/services/menu/menu.service';
import { ProfileService } from '@shared/services/profile/profile.service';
import { ManagmentLanguageService } from '@shared/services/language/managment-language..service';

@Component({
  selector: 'app-sidebar-managment',
  templateUrl: './sidebar-managment.component.html',
  styleUrls: ['./sidebar-managment.component.scss']
})
export class SidebarManagmentComponent implements OnInit {
  showMe: boolean;
  public currentUser: UserDetail;
  public menu: ILeftNavMenu[];
  public logoutMenu: ILeftNavMenu;
  
  constructor(public menuSerivce: MenuService, private authService: AuthService, public labelService: LabelService, public messageService: MessageService, private languageService: LanguageService, public userService: UserService,public managmentLangService:ManagmentLanguageService) {
    this.menu = LEFT_NAV_MENU_MANAGMENT;
    this.logoutMenu = {
      name: 'logout',
      icon: 'fas fa-power-off',
      method: () => { this.logout(); }
    }
  }

  ngOnInit(): void {
    this.userService.loadCurrentUser();
    this.userService.currentUser.subscribe(e=>{
      this.currentUser = e;
      this.showMe=true;
      this.menuSerivce.showMenu = true;
    });
  }

  changeLanguageEs() {
    this.languageService.changeLanguage(ES_LANGUAGE)
    this.managmentLangService.refreshLanguage();
  }

  changeLanguageEn() {
    this.languageService.changeLanguage(EN_LANGUAGE)
    this.managmentLangService.refreshLanguage();

  }

  logout() {
    this.authService.logout();
  }

}
