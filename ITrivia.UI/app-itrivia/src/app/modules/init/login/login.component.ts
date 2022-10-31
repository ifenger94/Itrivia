import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '@shared/services/auth/auth.service';
import { LabelService } from '@shared/services/label/label.service';
import { MessageService } from '@shared/services/message/message.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  public loginForm: FormGroup;
  public remember: boolean;
  public loading:boolean;
  public errorLogin = false;

  constructor(private authService: AuthService, private formBuilder: FormBuilder, public labelService: LabelService, public messageService: MessageService) {
    this.loading = false;
    this.loginForm = this.formBuilder.group(
      {
        email: ['', [Validators.required, Validators.email]],
        password: ['', [Validators.required]]
      }
    );
  }

  ngOnInit(): void {
    this.remember = this.authService.rememberSession;
  }

  public Authenticate() {
    this.loading = true;
    if (!this.loginForm.invalid) {
      this.authService.login(this.loginForm.value, this.remember).subscribe(res => {
      }, err => {
        this.errorLogin = true;
        this.loading = false;
      })
    }
  }

  get form() {
    return this.loginForm.controls;
  }

  changeForm() {
    this.errorLogin = false;
  }

  //Función que muestra la contraseña.
  togglePassword() {
    let password: any = document.getElementById("password");
    let icon: any = document.getElementById("eye");
    if (password.type === "password") {
      password.type = "text";
      icon.setAttribute('class', 'fas fa-eye')

    } else {
      password.type = "password";
      icon.setAttribute('class', 'fas fa-eye-slash')
    }
  }
}
