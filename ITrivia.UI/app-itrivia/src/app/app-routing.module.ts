import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '@core/guards/auth.guard';
import { NoAuthGuard } from '@core/guards/no-auth.guard';
import { SkeletonComponent } from '@layout/init/skeleton/skeleton.component';
import { SkeletonManagmentComponent } from '@layout/managment/skeleton-managment/skeleton-managment.component';

const routes: Routes = [
  {
    path:'',
    component : SkeletonComponent,
    canActivate: [NoAuthGuard],
    children:[
      {
        path:'',
        loadChildren: ()=> import('@modules/init/init.module').then(m=>m.InitModule)
      }
    ]
  },
  {
    path:'Managment',
    component : SkeletonManagmentComponent,
    canActivate: [AuthGuard],
    children:[
      {
        path:'',
        loadChildren: ()=> import('@modules/managment/managment.module').then(m=>m.ManagmentModule)
      }
    ]
  },
  {
    path:'Administrator',
    component : SkeletonManagmentComponent,
    canActivate: [AuthGuard],
    children:[
      {
        path:'',
        loadChildren: ()=> import('@modules/administrator/administrator.module').then(m=>m.AdministratortModule)
      }
    ]
  },
  {
    path:'**',
    redirectTo:'/login',
    pathMatch:'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes,{ useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
