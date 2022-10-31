import { Component, Input, OnInit } from '@angular/core';
import { ILeftNavMenu, ROLES_ENUM } from '@data/contants';
import { AuthService } from '@shared/services/auth/auth.service';
import { LabelService } from '@shared/services/label/label.service';

@Component({
  selector: 'app-left-nav-menu',
  templateUrl: './left-nav-menu.component.html',
  styleUrls: ['./left-nav-menu.component.scss']
})
export class LeftNavMenuComponent implements OnInit {
  @Input() leftNavMenu: ILeftNavMenu
  showMenu: boolean
  
  constructor(public labelService: LabelService,public authService:AuthService) {
    this.showMenu = false;
  }

  ngOnInit(): void {
  }

  hasPermission(roles: ROLES_ENUM[]): boolean {
    if (roles) {
      return this.authService.hasPermission(roles);
    }
    return true;
  }
}
