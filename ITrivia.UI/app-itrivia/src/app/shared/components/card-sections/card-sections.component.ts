import { Component, Input, OnInit } from '@angular/core';
import { LabelService } from '@shared/services/label/label.service';
import { MessageService } from '@shared/services/message/message.service';

@Component({
  selector: 'app-card-sections',
  templateUrl: './card-sections.component.html',
  styleUrls: ['./card-sections.component.scss']
})
export class CardSectionsComponent implements OnInit {
  @Input() nameSection: string;
  @Input() descSection: string;
  @Input() imageSection: string;
  @Input() idSection: string;
  @Input() countChallenge: number;
  constructor(public labelService: LabelService, public messageService: MessageService) { }

  ngOnInit(): void {
  }

  public formatLabelChallenge(label: string) {
    if (this.countChallenge == 1) {
      label = label.substr(0, label.length - 1);
    }
    return label || '';
  }

}
