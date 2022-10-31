import { Component, OnInit } from '@angular/core';
import { MessageService } from '@shared/services/message/message.service';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent implements OnInit {

  constructor(public messageService:MessageService) { }

  ngOnInit(): void {
  }

}
