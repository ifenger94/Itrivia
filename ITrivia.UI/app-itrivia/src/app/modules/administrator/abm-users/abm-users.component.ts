import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms'
import { NgbModal, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { User } from '@shared/models/user';
import { UserDetail } from '@shared/models/user-detail';
import { LabelService } from '@shared/services/label/label.service';
import { MessageService } from '@shared/services/message/message.service';
import { UserService } from '@shared/services/user/user.service';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { AbmUsersFormComponent } from './abm-users-form/abm-users-form.component';
@Component({
  selector: 'app-abm-users',
  templateUrl: './abm-users.component.html',
  styleUrls: ['./abm-users.component.scss']
})
export class AbmUsersComponent implements OnInit,OnDestroy {
  page: number = 1;
  public currentUser: UserDetail;
  public usersList: Array<User> = [];
  public id: number;
  public newUser: boolean
  private subcripcion: Subscription = null;
  public loading = false;
  constructor(public modal: NgbModal, private userService: UserService, private toastr: ToastrService, public messageService: MessageService, public labelService: LabelService) { }
  
  ngOnDestroy(): void {
    if(this.subcripcion != null)
      this.subcripcion.unsubscribe();
  }

  ngOnInit(): void {
    this.subcripcion = this.userService.currentUser.subscribe(usr => {
      if(usr){
        this.currentUser = usr;
        this.getUsersByCompany();
        this.loading = true;
      }
    });
  }

  public getUsersByCompany() {
    this.userService.getUsersByCompany(this.currentUser.BussinesId).subscribe(data => this.usersList = data);
  }

  add() {
    let modal = this.modal.open(AbmUsersFormComponent, { size: "xl" })
    modal.componentInstance.companyId = this.currentUser.BussinesId;
    modal.closed.subscribe(e => {
      if (e) {
        this.toastr.success("Los cambios se realizaron exitosamente");
        this.getUsersByCompany();
      }
    });

  }

  edit(user: User) {
    let modal = this.modal.open(AbmUsersFormComponent, { size: "xl" })
    modal.componentInstance.user = user;
    modal.componentInstance.companyId = this.currentUser.BussinesId;
    modal.closed.subscribe(e => {
      if (e) {
        this.toastr.success("Los cambios se realizaron exitosamente");
        this.getUsersByCompany();
      }
    });
  }

  delete(id: number) {
    this.userService.delete(id).subscribe(e => {
      this.toastr.success("Registro eliminado");
      this.getUsersByCompany();
    });
  }

  changePassword(user: User) {
    let modal = this.modal.open(AbmUsersFormComponent, { size: "xl" })
    modal.componentInstance.user = user;
    modal.componentInstance.changePassword = true;
    modal.componentInstance.companyId = this.currentUser.BussinesId;
  }
}
