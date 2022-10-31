import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { User } from '@shared/models/user';
import { LabelService } from '@shared/services/label/label.service';
import { MessageService } from '@shared/services/message/message.service';
import { UserService } from '@shared/services/user/user.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-abm-users-form',
  templateUrl: './abm-users-form.component.html',
  styleUrls: ['./abm-users-form.component.scss']
})
export class AbmUsersFormComponent implements OnInit {
  form: FormGroup
  companyId: number;
  user: User;
  changePassword: boolean

  constructor(private formBuilder: FormBuilder, private toastr: ToastrService, public modalActiveService: NgbActiveModal, private userService: UserService, public messageService: MessageService, public labelService: LabelService) { }

  ngOnInit(): void {
    this.buildForm();
  }

  public buildForm() {
    if (!this.changePassword) {
      this.form = new FormGroup({
        Id: new FormControl(!!this.user ? this.user.Id : null),
        Email: new FormControl(!!this.user ? this.user.Email : null, [Validators.required,Validators.maxLength(30),Validators.email]),
        Name: new FormControl(!!this.user ? this.user.Name : null, [Validators.required,Validators.maxLength(12)]),
        LastName: new FormControl(!!this.user ? this.user.LastName : null, [Validators.required,Validators.maxLength(12)]),
        CompanyId: new FormControl(this.companyId, [Validators.required])
      });

      if (this.user == null) {
        this.form = this.formBuilder.group({
          ...this.form.controls,
          Password: new FormControl(null, [Validators.required, Validators.minLength(6),Validators.maxLength(12)]),
          Password2: new FormControl('', [Validators.required, Validators.minLength(6),Validators.maxLength(12)]),
        });
      }
    }
    else {
      this.form = new FormGroup({
        Id: new FormControl(this.user.Id, [Validators.required]),
        Password: new FormControl(null, [Validators.required, Validators.minLength(6),Validators.maxLength(12)]),
        Password2: new FormControl('', [Validators.required, Validators.minLength(6),Validators.maxLength(12)]),
      });


    }

    if (this.user == null || this.changePassword) {
      this.form.get('Password2').setValidators(
        this.equalsValidator(this.form.get('Password'))
      );
      this.form.updateValueAndValidity();
    }
  }

  save() {
    if (this.form.valid) {
      if (this.changePassword) {
        this.userService.resetPassword(this.form.value).subscribe(e => {
          this.modalActiveService.close(true);
        });
      }
      else {
        // if (this.user == null) {
        //   let user: UserCompanyRegister = this.form.value;
        //   this.userCompany.createUserCompany(user).subscribe(e => {
        //     this.modalActiveService.close(true);
        //   }, err => {
        //     this.toastr.error(this.messageService.messages['toast-failed'], err.error.Message);
        //   });
        // } else {
        //   this.userService.updateUser(this.form.value).subscribe(e => {
        //     this.modalActiveService.close(true);
        //   }, err => {
        //     this.toastr.error(this.messageService.messages['toast-failed'], err.error.Message);
        //   });
        // }
        this.userService.updateUser(this.form.value).subscribe(e => {
          this.modalActiveService.close(true);
        }, err => {
          this.toastr.error(this.messageService.messages['toast-failed'], err.error.Message);
        });
      }
    }
  }

  close() {
    this.modalActiveService.close();
  }

  togglePassword(formId, eyeId) {
    let password: any = document.getElementById(formId);
    let icon: any = document.getElementById(eyeId);
    if (password.type === "password") {
      password.type = "text";
      icon.setAttribute('class', 'fas fa-eye')

    } else {
      password.type = "password";
      icon.setAttribute('class', 'fas fa-eye-slash')
    }
  }

  equalsValidator(otherControl: AbstractControl): ValidatorFn {
    return (control: AbstractControl): { [key: string]: any } => {
      const value: any = control.value;
      const otherValue: any = otherControl.value;
      return otherValue === value ? null : { 'notEquals': { value, otherValue } };
    };
  }

}
