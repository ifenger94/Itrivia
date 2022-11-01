import { ThrowStmt } from '@angular/compiler';
import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { PairSelection } from '@shared/models/pairselection';
import { PairSelectionService } from '@shared/services/pair-selection/pair-selection.service';
import { Utils } from '@shared/utils/utils';


@Component({
  selector: 'app-selpares',
  templateUrl: './selpares.component.html',
  styleUrls: ['./selpares.component.scss']
})
export class SelparesComponent implements OnChanges {
  @Input() item: PairSelection;
  @Output() accepted: EventEmitter<any> = new EventEmitter();
  @Output() failed = new EventEmitter<any>();

  disableButton:boolean;
  waitSecondOption = false;
  attemptCount: number;

  pairOptions: Array<{ Index: number, Option: string, Pair: string }> = [];

  pairSelectedOne: { Index: number, Option: string, Pair: string };
  pairSelectedTwo: { Index: number, Option: string, Pair: string };

  pairAssert: Array<number> = []
  pairNotAssert: Array<number> = []

  constructor(private pairSelectionService: PairSelectionService) { }

  ngOnChanges(changes: SimpleChanges): void {
    this.resetGame();
    console.log(this.item);
    this.generateOptions();
  }

  resetGame() {
    this.attemptCount = 2;
    this.pairOptions = [];
    this.pairAssert = [];
    this.pairNotAssert = [];
    this.resetSelected();
  }

  generateOptions() {
    for (let index = 0; index < this.item.PairOptions.length; index++) {
      this.pairOptions.push(
        { Index: index, Option: this.item.PairOptions[index].Option, Pair: this.item.PairOptions[index].Pair });
    }
    Utils.shuffleArray(this.pairOptions);
  }

  validate(obj: { Index: number, Option: string, Pair: string }) {
    if (!this.waitSecondOption) {
      this.pairSelectedOne = obj;
      this.waitSecondOption = true;
    }
    else {
      this.disableButton = true;
      this.pairSelectedTwo = obj;
      this.pairSelectionService.validatePair(this.pairSelectedOne.Option, this.pairSelectedTwo.Pair).subscribe(valid => {
        this.waitSecondOption = false;
        if (valid) {
          this.pairAssert.push(this.pairSelectedOne.Index);
          this.pairAssert.push(this.pairSelectedTwo.Index);
          setTimeout(() => {
            this.removeItemPairOption(this.pairSelectedOne.Index)
            this.removeItemPairOption(this.pairSelectedTwo.Index)
            this.resetSelected();
            this.disableButton = false;
            this.stateGame();
          }, 1500);
        }
        else {
          this.attemptCount--;
          this.pairNotAssert.push(this.pairSelectedOne.Index);
          this.pairNotAssert.push(this.pairSelectedTwo.Index);
          setTimeout(() => {
            this.pairNotAssert = [];
            this.resetSelected();
            this.disableButton = false;
            this.stateGame();
          }, 1500);
        }
      });
    }
  }

  stateGame() {
    if (this.attemptCount == 0) {
      this.failed.emit(this.item);
    } else {
      if (this.pairOptions.length == 0) {
        this.accepted.emit();
        console.log('Entrando')
      }
    }
  }

  wasAssert(index: number) {
    return this.pairAssert.findIndex(e => e == index) != -1;
  }

  wasNotAssert(index: number) {
    return this.pairNotAssert.findIndex(e => e == index) != -1;
  }

  removeItemPairOption(index: number) {
    let i = this.pairOptions.findIndex(e => e.Index == index);
    this.pairOptions.splice(i, 1);
  }

  resetSelected() {
    this.pairSelectedOne = null;
    this.pairSelectedTwo = null;
  }

}
