import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { LabelService } from '@shared/services/label/label.service';
import { MessageService } from '@shared/services/message/message.service';
import { ChallengesService } from '@shared/services/challenge/challenge.service'
import { SectionService } from '@shared/services/section/section.service';
import { Challenge } from '@shared/models/challenge';
import { Section } from '@shared/models/section';
import { HistoryPD } from '@shared/models/historypd';
import { HisProfileChallengeService } from '@shared/services/his-profile-challenge/his-profile-challenge.service';
import { AuthService } from '@shared/services/auth/auth.service';

@Component({
  selector: 'app-challenges',
  templateUrl: './challenges.component.html',
  styleUrls: ['./challenges.component.scss']
})
export class ChallengesComponent implements OnInit {
  id: any;
  section: Section;
  private hisProfileChallenge: Array<HistoryPD> = [];
  public challengesList: Array<Challenge> = [];

  constructor(private hispdService: HisProfileChallengeService, public labelService: LabelService, public messageService: MessageService, private route: ActivatedRoute, private challengeService: ChallengesService, private sectionService: SectionService, private authService: AuthService) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    this.getChallenge();
    this.getSection(this.id);
    this.getHisProfileChallenge();
  }

  //Lista los desafios segun id de sección
  getChallenge() {
    this.challengeService.getChallengesBySectionId(this.id).subscribe(data => {
      this.challengesList = data;
    });
  }

  getSection(id) {
    this.sectionService.getSection(id).subscribe(data => {
      this.section = data;
    });
  }

  getHisProfileChallenge() {
    this.hispdService.getHisProfileChallengeByProfileId(this.authService.getUser.ProfileId).subscribe(hisPd => {
      this.hisProfileChallenge = hisPd;
    })
  }

  wasPlayed(id:number):boolean{
    return this.hisProfileChallenge.findIndex(e=>e.ChallengeId == id) != -1;
  }
}
