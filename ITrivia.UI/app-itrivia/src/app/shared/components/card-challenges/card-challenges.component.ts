import { Component, OnInit, Input, Output } from '@angular/core';
import { Router } from '@angular/router';
import { LabelService } from '@shared/services/label/label.service';
import { MenuService } from '@shared/services/menu/menu.service';
import { MessageService } from '@shared/services/message/message.service';

@Component({
  selector: 'app-card-challenges',
  templateUrl: './card-challenges.component.html',
  styleUrls: ['./card-challenges.component.scss']
})
export class CardChallengesComponent implements OnInit {
  @Input() nroChapter: string;
  @Input() idChallenge: string;
  @Input() nameChallenge: string;
  @Input() descChallenge: string;
  @Input() expChallenge: string;
  @Input() etapasChallenge: string;
  @Input() urlSection: string;
  @Input() wasPlayed = false;
  
  constructor(public labelService: LabelService, public messageService: MessageService, private menuService: MenuService, private route: Router) { }

  ngOnInit(): void {
  }

  navigate(challengeId) {
    this.menuService.loaderActive();
    this.route.navigateByUrl('/Managment/game/' + challengeId);
  }
}
