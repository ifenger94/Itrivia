import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators, AbstractControl, FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { userFields } from '@shared/models/user-fields';
import { AuthService } from '@shared/services/auth/auth.service';
import { LabelService } from '@shared/services/label/label.service';
import { MessageService } from '@shared/services/message/message.service';
import { UserService } from '@shared/services/user/user.service';
import { ToastrService } from 'ngx-toastr';
import { debounceTime } from 'rxjs/operators';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  public form: FormGroup
  public formCompany: FormGroup
  public loading:boolean;
  checked: boolean;
  letpassword = "secret";
  show = false;

  constructor(public labelService: LabelService, public messageService: MessageService, private formBuilder: FormBuilder, private userService: UserService, private toastr: ToastrService, private router: Router) {
    this.loading = false;
    this.buildForm();
  }

  ngOnInit(): void {
  }

  //Defino objeto que se va a encargar de las validaciones.
  public buildForm() {
    this.form = this.formBuilder.group({
      name: ['', [Validators.required]],
      lastname: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email ,Validators.maxLength(30)]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      password2: ['', [Validators.required]]
    }, { validator: this.passwordMatchValidator });
  }

  //Función que valida que ambos campos sean iguales para confirmar contraseña.
  passwordMatchValidator(frm: FormGroup) {
    return frm.controls['password'].value === frm.controls['password2'].value ? null : { 'mismatch': true };
  }

  save(event: Event) {

    event.preventDefault();//Cancelo el evento evitando la recarga de la pagina para hacerlo asincronoco
    if (this.form.valid) {
      const value = this.form.value;
      console.log(value);
    } else {
      this.form.markAllAsTouched();
    }
  }

  //Para obtener el nombre al momento de validar en el HTML ,y no repetir form.get('name').
  get nameField() {
    return this.form.get('name');
  }

  get lastnameField() {
    return this.form.get('lastname');
  }

  get emailField() {
    return this.form.get('email');
  }

  get passwordField() {
    return this.form.get('password');
  }

  get confirmPasswordField() {
    return this.form.get('password2');
  }

  get cuitField() {
    return this.formCompany.get('cuit');
  }
  get companyNameField() {
    return this.formCompany.get('companyName');
  }

  get phoneField() {
    return this.formCompany.get('phone');
  }
  //Validar formulario de administrador solo si el ngModel checked es true.
  // checkState() {
  //   this.checked = !this.checked;
  //   if (this.checked) {
  //     this.form.get('cuit').setValidators([Validators.required, Validators.minLength(8)]);
  //     this.form.get('phone').setValidators([Validators.required, Validators.minLength(8)]);
  //   } else {
  //     this.form.get('cuit').clearValidators();
  //     this.form.get('phone').clearValidators();
  //   }
  //   this.form.get('cuit').updateValueAndValidity();
  //   this.form.get('phone').updateValueAndValidity();
  // }
  //Oculto y mestro formulario de admin en Registro.
  // showContent() {
  //   let element = document.getElementById("content");
  //   let check = document.getElementById("check");
  //   if (check.click && element.style.display == 'none') {
  //     element.style.display = 'block';
  //   } else {
  //     element.style.display = 'none';
  //   }
  // }

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
  toggleConfirmPassword() {
    let password: any = document.getElementById("password2");
    let icon: any = document.getElementById("eye2");
    if (password.type === "password") {
      password.type = "text";
      icon.setAttribute('class', 'fas fa-eye')

    } else {
      password.type = "password";
      icon.setAttribute('class', 'fas fa-eye-slash')
    }
  }

  //Función para llamar al registro.
  onSubmit() {
    if (!this.form.invalid) {
      this.loading = true;
      this.userService.register(this.form.value).subscribe(
        (res: any) => {
          this.toastr.success(this.messageService.messages['toast-success'], this.messageService.messages['toast-success2']);
          this.form.reset();
          this.router.navigate(['login']);
        },
        err => {
          this.toastr.error(this.messageService.messages['toast-failed'], this.messageService.messages['toast-failed2']);
          this.loading = false;
        }

      );
    }
  }

}