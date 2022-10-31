import { Component, OnDestroy, OnInit } from '@angular/core';
import { NgbModal, ModalDismissReasons, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Challenge } from '@shared/models/challenge';
import { ChallengesService } from '@shared/services/challenge/challenge.service';
import { MessageService } from '@shared/services/message/message.service';
import { SectionService } from '@shared/services/section/section.service';
import { UserService } from '@shared/services/user/user.service';
import { ToastrService } from 'ngx-toastr';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms'
import { Section } from '@shared/models/section';
import { LabelService } from '@shared/services/label/label.service';
import { UserDetail } from '@shared/models/user-detail';
import { AbmGamesComponent } from './abm-games/abm-games.component';
import { typeofExpr } from '@angular/compiler/src/output/output_ast';
import { Subscription } from 'rxjs';



@Component({
  selector: 'app-abm-challenges',
  templateUrl: './abm-challenges.component.html',
  styleUrls: ['./abm-challenges.component.scss']
})

export class AbmChallengesComponent implements OnInit,OnDestroy {
  currentUser: UserDetail;
  page: number = 1;
  public challenge: Challenge;
  public section: Section;
  public challengeList: Array<Challenge> = [];
  public totalchallenge: Array<Challenge> = [];
  public sectionsList: Array<Section> = [];
  public id: number;
  form: FormGroup;
  public newChallenge: boolean
  public challengeBySection: Array<Challenge> = [];
  public selectedSectionId: number = -1;
  public loading = false;
  private subcripcion: Subscription = null;
  constructor(public modal: NgbModal, private sectionService: SectionService, private userService: UserService, private toastr: ToastrService, public messageService: MessageService, public labelService: LabelService, private challengesService: ChallengesService) {
  }
  ngOnDestroy(): void {
    if(this.subcripcion != null)
      this.subcripcion.unsubscribe();
  }

  ngOnInit(): void {
    this.subcripcion = this.userService.currentUser.subscribe(e => {
      if (!!e) {
        this.currentUser = e;
        this.newChallenge = true;
        this.buildForm();
        this.getchallengesByCompany(this.currentUser.BussinesId);
        this.getSections(this.currentUser.BussinesId);
        this.loading = true;
      }
    });
  }

  //Abrir modal según de donde sea
  open(contenido, action, id: number) {
    if (action == 'create') {
      // this.form.controls.StepsCount.enable();
       this.buildForm();
       this.getChallengeBySection();
      this.newChallenge = true;
    } else {
      this.getData(id);
      this.newChallenge = false;
    }

    //this.getSections(id);
    this.modal.open(contenido, { size: 'xl' });
  }

  public buildForm() {
    this.form = new FormGroup({
      Id: new FormControl(),
      CreateDate: new FormControl(),
      User: new FormControl(),
      Activated: new FormControl(),
      Name: new FormControl('', [Validators.required, Validators.maxLength(30)]),
      Description: new FormControl('', [Validators.required, Validators.maxLength(80)]),
      SectionId: new FormControl(null, [Validators.required]),
      StepsCount: new FormControl('', [Validators.required, Validators.min(1), Validators.max(20)]),
      Experience: new FormControl('', [Validators.required, Validators.min(1), Validators.max(1000)])
    });
  }

  public getchallengesByCompany(id: number) {
    this.challengesService.getChallengeByCompany(id).subscribe(data => {
      //this.challengeList = data
      this.totalchallenge = data
      this.challengeList = data;
      this.getChallengeBySection();
    });
    // this.challengesService.getChallengeByCompany(id).subscribe(data => this.totalchallenge = data
    // );
  }

  public onSubmit(idChallenge) {
    if (this.newChallenge) {
      this.CreateChallenge();
    } else {
      this.editChallenge();
    }
  }
  ///Completa el formulario del modal para editar.
  getData(idChallenge) {
    this.form.controls.StepsCount.disable();
    
    this.challengesService.getChallenge(idChallenge).subscribe(data => {
      this.challenge = data;
      this.form.patchValue({
        Id: this.challenge.Id,
        CreateDate: this.challenge.CreateDate,
        User: this.challenge.User,
        Name: this.challenge.Name,
        Description: this.challenge.Description,
        SectionId: this.challenge.SectionId,
        StepsCount: this.challenge.StepsCount,
        Experience: this.challenge.Experience,
        Activated:this.challenge.Activated
      });
    });
  }

  //Edita Desafío.
  editChallenge() {
    this.challengesService.editChallenge(this.form.value.Id, this.form.getRawValue()).subscribe(data => {
      if (this.form.valid) this.challenge = data;
      this.toastr.success(this.messageService.messages['edit-successful-c'], this.messageService.messages['operation-successful']);
      this.modal.dismissAll();
      this.form.reset();
      this.getchallengesByCompany(this.currentUser.BussinesId);
    }, err => {
      this.toastr.warning(this.messageService.messages['edit-failed'], err.error.Message)
    })
  }

  public deleteChallenge(id) {
    this.challengesService.deleteSection(id).subscribe(data => {
      this.challenge = data;

      this.toastr.info(this.messageService.messages['delete-challenge'], this.messageService.messages['operation-successful']);
      this.getchallengesByCompany(this.currentUser.BussinesId);
      // this.getChallengeBySection();

    })

  }

  //Crea sección
  public CreateChallenge() {
    this.form.patchValue({
      CreateDate: this.getCurrentDate(),
      //User: this.currentUser.Company.User,
    });
    this.challengesService.addChallenge(this.form.value).subscribe(data => {
      this.toastr.success(this.messageService.messages['create-successful-c'], this.messageService.messages['operation-successful']);
      this.modal.dismissAll();
      this.getchallengesByCompany(this.currentUser.BussinesId);
      this.form.reset();
    }, err => {
      this.toastr.warning(this.messageService.messages['edit-failed'], err.error.Message)
    })
  }


  getSections(id: number) {
    // this.sectionService.getSectionByCompany(this.currentUser.BussinesId, false).subscribe(data => {
    //   this.sectionsList = data
    // });
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

  openGame(challengeId: number) {
    let modal = this.modal.open(AbmGamesComponent, { size: 'xl' });
    modal.componentInstance.challengeId = challengeId;
    modal.dismissed.subscribe(e => {
        this.getchallengesByCompany(this.currentUser.BussinesId);
    });
  }

  getChallengeBySection() {
    if (this.selectedSectionId == -1) {
      this.challengeList = this.totalchallenge;
      this.section = null;
    }
    else {
      this.form.controls.SectionId.setValue(this.selectedSectionId);
      this.section = this.sectionsList.filter(e => e.Id == this.selectedSectionId)[0];
      this.challengeList = this.totalchallenge.filter(e => e.SectionId == this.selectedSectionId);
    }
  }

  getSectionName(sectionId:number){
    let name = '';
    if(this.sectionsList.length > 0){
      name = this.sectionsList.filter(e=>e.Id == sectionId)[0].Name;
    }
    return name;
  }
}
