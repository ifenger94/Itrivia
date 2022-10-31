import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NoAuthGuard } from '@core/guards/no-auth.guard';
import { LoginComponent } from './login/login.component';
import { RecoveryPasswordComponent } from './recovery-password/recovery-password.component';
import { RegisterComponent } from './register/register.component';


const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'register',
    component: RegisterComponent
  },
  {
    path: 'recovery-password',
    component: RecoveryPasswordComponent
  },
  {
    path:'',
    redirectTo:'/login',
    pathMatch:'full'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule] 
})
export class AppInitRoutingModule { }

