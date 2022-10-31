import { Component, NgModule, OnDestroy, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms'
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { Section } from '@shared/models/section';
import { AuthService } from '@shared/services/auth/auth.service';
import { SectionService } from '@shared/services/section/section.service'
import { User } from '@shared/models/user';
import { UserService } from '@shared/services/user/user.service';
import { ToastrService } from 'ngx-toastr';
import { MessageService } from '@shared/services/message/message.service';
import { CategoryService } from '@shared/services/category/category.service';
import { Category } from '@shared/models/category';
import { UserDetail } from '@shared/models/user-detail';
import { LabelService } from '@shared/services/label/label.service';
import { Subscription } from 'rxjs';


@Component({
  selector: 'app-abm-sections',
  templateUrl: './abm-sections.component.html',
  styleUrls: ['./abm-sections.component.scss']
})
export class AbmSectionsComponent implements OnInit,OnDestroy{
  private currentUser: UserDetail;
  public sectionsList: Array<Section> = [];
  public section: Section;
  public categoriesList: Array<Category> = [];
  public category: Category;
  public id: number;
  page: number = 1;
  public newSection: boolean
  form: FormGroup
  private subcripcion: Subscription = null;
  public loading = false;
  constructor(public modal: NgbModal, private sectionService: SectionService, private userService: UserService, private toastr: ToastrService, public messageService: MessageService, public labelService: LabelService, private categoryService: CategoryService) {
  }
  ngOnDestroy(): void {
    if(this.subcripcion != null)
      this.subcripcion.unsubscribe();
  }

  ngOnInit(): void {
    this.subcripcion = this.userService.currentUser.subscribe(e => {
      if(e){
        this.currentUser = e;
        this.buildForm();
        this.getCategories();
        this.newSection = true;
        this.loading = true;
      }
    });
  }

  //Abrir modal según de donde sea
  open(contenido, action) {
    this.modal.open(contenido, { size: 'xl' ,modalDialogClass:"mt-6" });
    if (action == 'create') {
      this.form.reset();
      this.newSection = true;
    } else {
      this.newSection = false;
    }
  }

  public buildForm() {
    this.form = new FormGroup({
      Id: new FormControl(),
      CreateDate: new FormControl(),
      User: new FormControl(),
      Activated: new FormControl(),
      Name: new FormControl('', [Validators.required ,Validators.maxLength(15)]),
      CategoryId: new FormControl(null,[Validators.required]),
      ChallengeCount: new FormControl(null,[Validators.required,Validators.min(1),Validators.max(15)]),
      Url_Image: new FormControl('', [Validators.required, Validators.maxLength(150)]),
      Description: new FormControl('', [Validators.required, Validators.maxLength(50)])
    });
  }

  public onSubmit(idSection) {
    if (this.newSection) {
      this.CreateSection();
    } else {
      this.editSection();
    }
  }

  //Crea sección
  public CreateSection() {
    this.form.patchValue({
      CreateDate: this.getCurrentDate(),
      //User: this.currentUser.Company.User,
    });
    this.sectionService.addSection(this.form.value).subscribe(data => {
      this.toastr.success(this.messageService.messages['create-successful-s'], this.messageService.messages['operation-successful']);
      this.modal.dismissAll();
    }, err => {
      this.toastr.warning(this.messageService.messages['edit-failed'], err.error.Message)
    })
  }

  ///Completa el formulario del modal para editar.
  getData(idSection) {
    this.form.controls.ChallengeCount.disable();
    this.sectionService.getSection(idSection).subscribe(data => {
      this.section = data;
      this.form.patchValue({
        Id: this.section.Id,
        CreateDate: this.section.CreateDate,
        User: this.section.User,
        Name: this.section.Name,
        CategoryId: this.section.CategoryId,
        ChallengeCount: this.section.ChallengeCount,
        Url_Image: this.section.Url_Image,
        Description: this.section.Description,
        Activated:this.section.Activated
      });
    });
  }

  //Edita sección.
  editSection() {
    this.sectionService.editSection(this.form.value.Id, this.form.getRawValue()).subscribe(data => {
      if (this.form.valid)
        this.section = data;
      this.toastr.success(this.messageService.messages['operation-successful'], this.messageService.messages['edit-successful-s']);
      this.modal.dismissAll();
    }, err => {
      this.toastr.warning(this.messageService.messages['edit-failed'], err.error.Message)
    })
  }

  public getSection(id) {
    this.sectionService.getSection(id).subscribe(data => {
      if (this.form.valid)
        this.section = data;
    })
  }

  public getCategories() {
    this.categoryService.getCategories().subscribe(data => { this.categoriesList = data });
  }

  public deleteSection(id) {
    this.sectionService.deleteSection(id).subscribe(data => {
      this.section = data;
      this.toastr.info(this.messageService.messages['operation-successful'], this.messageService.messages['delete-section']);
    },error=>{
      console.log(error);
      this.toastr.error(error.error.Message);
    });
  }

  getCurrentDate() {
    let day = new Date().getDate();
    let month = new Date().getMonth();
    let firstmonth = `${month}`;
    let year = new Date().getFullYear()
    let hour = new Date().getHours();
    let minute = new Date().getMinutes();
    let seconds = new Date().getSeconds();
    let milliSeconds = new Date().getMilliseconds();
    if (month < 10) firstmonth = `0` + month;
    return `${year}-${firstmonth}-${day} ${hour}:${minute}:${seconds}.${milliSeconds}`
  }
}
