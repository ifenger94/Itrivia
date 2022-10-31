import { Component, Input, OnInit, Output, EventEmitter, OnChanges, SimpleChanges, ViewChild, ElementRef, AfterViewChecked, ChangeDetectorRef } from '@angular/core';
import { MultipleChoice } from '@shared/models/multiplechoice';
import { Utils } from '@shared/utils/utils';


@Component({
  selector: 'app-multchoice',
  templateUrl: './multchoice.component.html',
  styleUrls: ['./multchoice.component.scss']
})
export class MultchoiceComponent implements  OnChanges {
  @Input() item: MultipleChoice;
  @Output() accepted: EventEmitter<any> = new EventEmitter();
  @Output() failed = new EventEmitter<any>();
  showAnswer = false;
  options: string[] = [];
  loading: boolean = true;

  constructor() { }
  

  ngOnChanges(changes: SimpleChanges): void {
    this.showAnswer = false;
    this.options = [];
    this.load();
  }

  load() {
    if (!!this.item) {
      this.options.push(this.item.FirstOption);
      this.options.push(this.item.SecondOption);
      this.options.push(this.item.CorrectOption);
      Utils.shuffleArray(this.options);
      this.loading = false;
    }
  }

  validate(option: string) {
    this.showAnswer = true;
    setTimeout(() => {
      if (option == this.item.CorrectOption) {
        return this.accepted.emit();
      }
      return this.failed.emit(this.item);
    }, 1500);
  }

  isRight(index: number) {
    return this.options[index] == this.item.CorrectOption;
  }
}
