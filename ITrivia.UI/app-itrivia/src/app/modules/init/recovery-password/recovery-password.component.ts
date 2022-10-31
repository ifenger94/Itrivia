import { Component, OnInit } from '@angular/core';
import { LabelService } from '@shared/services/label/label.service';
import { MessageService } from '@shared/services/message/message.service';

@Component({
  selector: 'app-recovery-password',
  templateUrl: './recovery-password.component.html',
  styleUrls: ['./recovery-password.component.scss']
})
export class RecoveryPasswordComponent implements OnInit {

  constructor(public labelService:LabelService,public messageService:MessageService) { }

  ngOnInit(): void {
  }

}
