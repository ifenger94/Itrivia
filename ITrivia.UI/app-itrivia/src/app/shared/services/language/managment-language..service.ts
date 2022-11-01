import { Injectable } from '@angular/core';
import { LabelService } from '../label/label.service';
import { MenuService } from '../menu/menu.service';
import { MessageService } from '../message/message.service';


@Injectable({
    providedIn: 'root'
})
export class ManagmentLanguageService {

    constructor(private menuService: MenuService, private labelService: LabelService, private messageService: MessageService) { }

    public refreshLanguage() {
        this.menuService.fullLoader = true;
        setTimeout(() => {
            this.labelService.refreshLabels().subscribe(e => {
                this.labelService.labels = e;
                this.messageService.refreshMessages().subscribe(e => {
                    this.messageService.messages = e;
                    this.menuService.fullLoader = false;
                })
            })
        }, 1200);
    }
}