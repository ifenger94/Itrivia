import { Component, OnInit } from '@angular/core';
import { MenuService } from '@shared/services/menu/menu.service';

@Component({
  selector: 'app-skeleton-managment',
  templateUrl: './skeleton-managment.component.html',
  styleUrls: ['./skeleton-managment.component.scss']
})
export class SkeletonManagmentComponent implements OnInit {
  constructor(public menuService:MenuService) { }

  ngOnInit(): void {
  }

}
