import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AutocompleteGameDto } from '@shared/models/autocomplete';
import { MultipleChoice, MultipleChoiceGameDto } from '@shared/models/multiplechoice';
import { PairSelectionGameDto } from '@shared/models/pairselection';
import { Category } from '@shared/models/category';
import { GameType } from '@shared/models/gametype';
import { Step } from '@shared/models/step';
import { AutoCompleteService } from '@shared/services/auto-complete/auto-complete.service';
import { CategoryService } from '@shared/services/category/category.service';
import { GameTypeService } from '@shared/services/game-type/game-type.service';
import { LabelService } from '@shared/services/label/label.service';
import { MessageService } from '@shared/services/message/message.service';
import { StepService } from '@shared/services/step/step.service';
import { MultChoiceService } from '@shared/services/mult-choice/mult-choice.service';
import { PairSelectionService } from '@shared/services/pair-selection/pair-selection.service';
import { ToastrService } from 'ngx-toastr';
import { StepDetail } from '@shared/models/stepDetail';
import { AUTOCOMPLETE_MARK } from '@data/contants';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { $ } from 'protractor';
import { Challenge } from '@shared/models/challenge';
import { ChallengesService } from '@shared/services/challenge/challenge.service';
@Component({
  selector: 'app-abm-games',
  templateUrl: './abm-games.component.html',
  styleUrls: ['./abm-games.component.scss']
})
export class AbmGamesComponent implements OnInit {
  public challengeId: number;
  public challenges: number;
  public markAutocomplete = AUTOCOMPLETE_MARK;
  public steps: Array<Step> = [];
  public stepsDetail: Array<StepDetail> = [];
  public gameTypes: Array<GameType> = [];
  idToEdit: number;
  i: number;
  formStep: FormGroup;
  formAutoComplete: FormGroup;
  formMultChoice: FormGroup;
  formPairSelection: FormGroup;
  activeForm = false;
  public step: Step;
  public stepDetail: StepDetail;
  public autocomplete: AutocompleteGameDto;
  public multChoice: MultipleChoiceGameDto
  public selPares: PairSelectionGameDto;
  public isNew : boolean;


  constructor(public modal: NgbModal, private gameTypeService: GameTypeService, private stepService: StepService, private autoCompleteService: AutoCompleteService, private multChoiceService: MultChoiceService, private pairSelectionService: PairSelectionService,private challengeService : ChallengesService, public messageService: MessageService, public labelService: LabelService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.loadCategorys();
    this.loadSteps();
    this.countChallengesSteps();
    this.isNew = true;
  }

  loadCategorys() {
    this.gameTypeService.getGameTypes().subscribe(e => {
      this.gameTypes = e;
    });
  } 


  public buildForm() {
    this.formStep = new FormGroup({
      Id: new FormControl(),
      CreateDate: new FormControl(),
      Name: new FormControl(null, [Validators.required, Validators.maxLength(15)]),
      GameTypeId: new FormControl(null, [Validators.required]),
      ChallengeId: new FormControl(this.challengeId, Validators.required),
    });

    this.formAutoComplete = new FormGroup({
      Id: new FormControl(),
      IsDeleted: new FormControl(null),
      CreateDate: new FormControl(),
      Enunciate: new FormControl(null, [Validators.required, Validators.maxLength(75), this.validateMark]),
      Answer: new FormControl(null, [Validators.required, Validators.maxLength(15)]),
    });

    this.formMultChoice = new FormGroup({
      Id: new FormControl(),
      IsDeleted: new FormControl(null),
      CreateDate: new FormControl(),
      Enunciate: new FormControl(null, [Validators.required, Validators.maxLength(75)]),
      CorrectOption: new FormControl(null, [Validators.required, Validators.maxLength(40)]),
      FirstOption: new FormControl(null, [Validators.required, Validators.maxLength(40)]),
      SecondOption: new FormControl(null, [Validators.required, Validators.maxLength(40)]),
    });

    this.formPairSelection = new FormGroup({
      Id: new FormControl(),
      IsDeleted: new FormControl(null),
      CreateDate: new FormControl(),
      FirstOption: new FormControl(null, [Validators.required, Validators.maxLength(18)]),
      FirstAnswer: new FormControl(null, [Validators.required, Validators.maxLength(18)]),
      SecondOption: new FormControl(null, [Validators.required, Validators.maxLength(18)]),
      SecondAnswer: new FormControl(null, [Validators.required, Validators.maxLength(18)]),
      ThirdOption: new FormControl(null, [Validators.required, Validators.maxLength(18)]),
      ThirdAnswer: new FormControl(null, [Validators.required, Validators.maxLength(18)]),
      FourthOption: new FormControl(null, [Validators.required, Validators.maxLength(18)]),
      FourthAnswer: new FormControl(null, [Validators.required, Validators.maxLength(18)])
    });

    this.formAutoComplete.errors
  }

  close() {
    this.modal.dismissAll();
  }

  save() {
    switch (this.selectedGameType.Code) {
      case 'AUTCOMPLETADO':
        this.saveStepAutoComplete()
        break;
      case 'MULCHOICE':
        this.saveStepMultipleChoice()
        break;
      case 'SELCPARES':
        this.saveStepSelPares()
        break;
      default:
        break;
    }
  }

  saveStepAutoComplete() {
    if (this.isNew) {
      console.log('this.isNew');
      console.log(this.isNew);
      let step: Step = this.formStep.value;
      let item: AutocompleteGameDto = this.formAutoComplete.value;
      this.autoCompleteService.saveGame(item, step).subscribe(res => {
        this.activeForm = false;
        this.formStep.reset();
        this.toastr.success(this.messageService.messages['create-successful-st'], this.messageService.messages['operation-successful']);
        this.formAutoComplete.reset();
        this.loadSteps();
      }, err => {
        this.toastr.warning(this.messageService.messages['edit-failed'], err.error.Message)
      });
    } else {
      this.editAutocomplete(this.idToEdit);
    }
  }

  saveStepMultipleChoice() {
    if (this.isNew) {
    let step: Step = this.formStep.value;
    let item: MultipleChoiceGameDto = this.formMultChoice.value;
    this.multChoiceService.saveGame(item, step).subscribe(res => {
      this.activeForm = false;
      this.formStep.reset();
      this.formMultChoice.reset();
      this.loadSteps();
    });
    }else{
      this.editMultipleChoice(this.idToEdit);
    }
  }

  saveStepSelPares() {
    if(this.isNew){
    let step: Step = this.formStep.value;
    let item: PairSelectionGameDto = this.formPairSelection.value;
    this.pairSelectionService.saveGame(item, step).subscribe(res => {
      this.activeForm = false;
      this.formStep.reset();
      this.formPairSelection.reset();
      this.loadSteps();
    });
  }else{
      this.editSelPares(this.idToEdit);
    }
  }

  loadSteps() {
    this.stepService.getStepByChallengeId(this.challengeId).subscribe(stp => {
      this.steps = stp;
    });
  }

  countChallengesSteps(){
    this.challengeService.getChallenge(this.challengeId).subscribe(stp =>{
    this.challenges = stp.StepsCount;
    });
  }

  getGameTypeName(id: number): string {
    return this.gameTypes.filter(e => e.Id == id)[0].Name || null;
  }

  get selectedGameType(): GameType {
    return this.gameTypes.filter(e => e.Id == this.fStep.GameTypeId.value)[0] || null;
  }

  add() {
    this.buildForm();
    this.activeForm = true;
    this.isNew = true;
  }

  get fStep() {
    return this.formStep.controls;
  }

  getDataAutocomplete(id, i) {
    this.autoCompleteService.getDataAutocomplete(this.steps[i].AutocompleteId).subscribe(data => {
      this.autocomplete = data;
      this.formAutoComplete.patchValue({
        Id: this.autocomplete.Id,
        IsDeleted: this.autocomplete.IsDeleted,
        CreateDate: this.autocomplete.CreateDate,
        Enunciate: this.autocomplete.Enunciate,
        Answer: this.autocomplete.Answer
      });
    });
    this.formAutoComplete.reset();
  }

  getDataMultChoice(id, i) {
    this.multChoiceService.getDataMultChoice(this.steps[i].MultipleChoiceId).subscribe(data => {
      this.multChoice = data;
      this.formMultChoice.patchValue({
        Id: this.multChoice.Id,
        IsDeleted: this.multChoice.IsDeleted,
        CreateDate: this.multChoice.CreateDate,
        Enunciate: this.multChoice.Enunciate,
        CorrectOption: this.multChoice.CorrectOption,
        FirstOption: this.multChoice.FirstOption,
        SecondOption: this.multChoice.SecondOption,
      });
    });
    this.formMultChoice.reset();
  }

  getDataSelPares(id, i) {
    this.pairSelectionService.getDataSelPares(this.steps[i].PairSelectionId).subscribe(data => {
      this.selPares = data;
      this.formPairSelection.patchValue({
        Id: this.selPares.Id,
        IsDeleted: this.selPares.IsDeleted,
        CreateDate: this.selPares.CreateDate,
        FirstOption: this.selPares.FirstOption,
        FirstAnswer: this.selPares.FirstAnswer,
        SecondOption: this.selPares.SecondOption,
        SecondAnswer: this.selPares.SecondAnswer,
        ThirdOption: this.selPares.ThirdOption,
        ThirdAnswer: this.selPares.ThirdAnswer,
        FourthOption: this.selPares.FourthOption,
        FourthAnswer: this.selPares.FourthAnswer
      });
    });
    this.formPairSelection.reset();
  }

  editAutocomplete(id) {
    let item: AutocompleteGameDto = this.formAutoComplete.value;
    let step: Step = this.formStep.value;
    this.autoCompleteService.editAutocomplete(this.formAutoComplete.value.Id, item, step).subscribe(data => {
      this.autocomplete = data;
      this.toastr.success(this.messageService.messages['operation-successful'], this.messageService.messages['edit-successful-st']);
      this.activeForm = false;
      this.formStep.reset();
      this.formAutoComplete.reset();
      this.loadSteps();
    }, err => {
      this.toastr.warning(this.messageService.messages['edit-failed'], err.error.Message)
    })
  }

  editMultipleChoice(id) {
    let item: MultipleChoiceGameDto = this.formMultChoice.value;
    let step: Step = this.formStep.value;
    this.multChoiceService.editMultChoice(this.formMultChoice.value.Id, item, step).subscribe(data => {
      this.multChoice = data;
      this.toastr.success(this.messageService.messages['operation-successful'], this.messageService.messages['edit-successful-st']);
      this.activeForm = false;
      this.formStep.reset();
      this.formMultChoice.reset();
      this.loadSteps();
    }, err => {
      this.toastr.warning(this.messageService.messages['edit-failed'], err.error.Message)
    })
  }

  editSelPares(id) {
    let item: PairSelectionGameDto = this.formPairSelection.value;
    let step: Step = this.formStep.value;
    this.pairSelectionService.editSelPares(this.formPairSelection.value.Id, item, step).subscribe(data => {
      this.selPares = data;
      this.toastr.success(this.messageService.messages['operation-successful'], this.messageService.messages['edit-successful-st']);
      this.activeForm = false;
      this.formStep.reset();
      this.formPairSelection.reset();
      //this.modal.dismissAll();
      this.loadSteps();
    }, err => {
      this.toastr.warning(this.messageService.messages['edit-failed'], err.error.Message)
    })
  }

  edit(id, i) {
    this.buildForm();
    this.idToEdit = id;
    this.i = i;
    this.isNew = false;
    this.loadCategorys();
    this.stepService.getStepByGameType(id).subscribe(data => {
      this.stepDetail = data;
      this.formStep.patchValue({
        Id: this.stepDetail.Id,
        CreateDate: this.stepDetail.CreateDate,
        Name: this.stepDetail.Name,
        GameTypeId: this.stepDetail.GameTypeId,
        ChallengeId: this.stepDetail.ChallengeId,
      });

      console.log(this.getGameTypeName(this.stepDetail.GameTypeId));
      switch (this.getGameTypeName(this.stepDetail.GameTypeId)) {
        case 'Auto completado':
          this, this.getDataAutocomplete(this.stepDetail.Id, i);
          break;
        case 'Multiple Choice':
          this.getDataMultChoice(this.stepDetail.Id, i);
          break;
        case 'Seleccion de pares':
          this.getDataSelPares(this.stepDetail.Id, i);
          break;
        default:
          break;
      }
    });
    this.activeForm = true;
  }

  public deleteStep(id) {
    this.stepService.deleteStep(id).subscribe(data => {
      this.step = data;
      this.toastr.info(this.messageService.messages['operation-successful'], this.messageService.messages['delete-step']);
      this.loadSteps();
    })
      this.formAutoComplete.reset();
      this.formMultChoice.reset();
      this.formPairSelection.reset();
      this.formStep.reset();
  }

  validateMark: ValidatorFn = (control: FormGroup): ValidationErrors | null => {
    let value: string = control.value || '';
    if (value != '' && value.indexOf(AUTOCOMPLETE_MARK) != -1) {
      if (value.indexOf(AUTOCOMPLETE_MARK) == value.lastIndexOf(AUTOCOMPLETE_MARK)) {
        return null
      }
    }

    return { validateMark: true }
  }
}
