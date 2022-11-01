import { Component, OnInit } from '@angular/core';
import { sectionCard } from '@shared/models/section-card';
import { SectionService } from '@shared/services/section/section.service'
import { LabelService } from '@shared/services/label/label.service';
import { MessageService } from '@shared/services/message/message.service';
import { CategoryService } from '@shared/services/category/category.service'
import { Section } from '@shared/models/section';
import { Category } from '@shared/models/category';
import { AuthService } from '@shared/services/auth/auth.service';
import { IFilterSectionManagment } from '@shared/models/filters/ifilter-section-managment';
@Component({
  selector: 'app-sections',
  templateUrl: './sections.component.html',
  styleUrls: ['./sections.component.scss']
})
export class SectionsComponent implements OnInit {

  public sectionsList: Array<Section> = [];
  public categories: Array<Category> = [];
  public filter: IFilterSectionManagment;

  constructor(private sectionService: SectionService, private categoryService: CategoryService, public labelService: LabelService, public messageService: MessageService, private authService: AuthService) { }

  ngOnInit(): void {
    this.loadFilter();
    this.getSections();
    this.getCategories();
  }

  loadFilter() {
    this.filter = {
      profileId:this.authService.getUser.ProfileId,
      categoryId: -1,
      search: ""
    }
  }

  public getSections() {
    this.sectionService.getSectionsFilter(this.filter).subscribe(data => {
      this.sectionsList = data.filter(e=>e.Activated);
    })
  }

  public getCategories() {
    this.categoryService.getCategories().subscribe(categ => {
      this.categories = categ;
    })
  }

  applyFilter(){
    this.getSections();
  }

}
