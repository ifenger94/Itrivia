import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { HistoryPD } from '@shared/models/historypd';
import { UserDetail } from '@shared/models/user-detail';
import { AuthService } from '@shared/services/auth/auth.service';
import { HisProfileChallengeService } from '@shared/services/his-profile-challenge/his-profile-challenge.service';
import { LabelService } from '@shared/services/label/label.service';
import { MessageService } from '@shared/services/message/message.service';
import { UserService } from '@shared/services/user/user.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {
  public currentUser:UserDetail;
  public hisProfileChallenge: Array<HistoryPD> = [];
  
  constructor(private auth:AuthService,public userService: UserService,private hispdService: HisProfileChallengeService,private authService: AuthService,public labelService: LabelService, public messageService: MessageService) { }

  ngOnInit(): void {
    this.userService.currentUser.subscribe(e=>{
      this.currentUser = e;
    });
    this.getHisProfileChallenge();
    console.log('this.currentUser');
    console.log(this.currentUser);
  }

  getHisProfileChallenge() {
    this.hispdService.getHisProfileChallengeByProfileId(this.authService.getUser.ProfileId).subscribe(hisPd => {
      this.hisProfileChallenge = hisPd;
      console.log(this.hisProfileChallenge);
    })
  }

}
