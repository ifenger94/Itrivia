import { Component, OnInit } from '@angular/core';
import { SummaryUserProfile } from '@shared/models/summaryuserprofile';
import { LabelService } from '@shared/services/label/label.service';
import { UserService } from '@shared/services/user/user.service';

@Component({
  selector: 'app-gral-ranking',
  templateUrl: './gral-ranking.component.html',
  styleUrls: ['./gral-ranking.component.scss']
})
export class GralRankingComponent implements OnInit {
  public summaryUserProfile: Array<SummaryUserProfile> = [];
  constructor(public labelService:LabelService, private UserService : UserService) { }

  ngOnInit(): void {
    this.getSummaryUserProfiles();
  }

  public getSummaryUserProfiles() {
    this.UserService.getSummaryUserProfile().subscribe(data => {
      this.summaryUserProfile = data;
    })
  }

}
