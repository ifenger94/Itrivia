import { Component, OnInit } from '@angular/core';
import { MenuService } from '@shared/services/menu/menu.service';

@Component({
  selector: 'app-skeleton',
  templateUrl: './skeleton.component.html',
  styleUrls: ['./skeleton.component.scss']
})
export class SkeletonComponent implements OnInit {

  constructor(public menuService:MenuService) { }

  ngOnInit(): void {
  }

}
