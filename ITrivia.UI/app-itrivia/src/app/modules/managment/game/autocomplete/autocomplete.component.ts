import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { AutocompleteGame } from '@shared/models/autocomplete';
import { AutoCompleteService } from '@shared/services/auto-complete/auto-complete.service';

@Component({
  selector: 'app-autocomplete',
  templateUrl: './autocomplete.component.html',
  styleUrls: ['./autocomplete.component.scss']
})
export class AutocompleteComponent implements OnChanges {
  @Input() item: AutocompleteGame;
  mark = '<#aut>'
  showAnswer = false;
  enunciate: Array<String> = [];
  answer = "";
  isValid: boolean;
  inputText: string;
  loading: boolean

  @Output() accepted = new EventEmitter();
  @Output() failed = new EventEmitter<any>();

  constructor(private autcmpService: AutoCompleteService) { }
  
  ngOnChanges(changes: SimpleChanges): void {
    this.init();
  }
  
  init(){
    this.inputText="";
    this.answer = "____________";
    this.showAnswer = false;
    this.enunciate=[];
    this.formatEnunciate();
  }
  
  formatEnunciate() {
    this.enunciate = this.item.Enunciate.split(this.mark);
  }

  validate() {
    this.loading = true;
    this.showAnswer = true;
    this.autcmpService.validateAnswer(this.item.Id, this.inputText).subscribe(resp => {
      this.answer = resp.answer;
      this.isValid = resp.valid;
      this.loading = false;

      setTimeout(() => {
        if (this.isValid) return this.accepted.emit();
        else return this.failed.emit(this.item);
      }, 1500);

    }, error => {
      this.showAnswer = false;
      this.loading = false;
    })
  }
}
