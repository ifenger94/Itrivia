import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CONFIGURATION_ACCESS, ROLES_ENUM } from '@data/contants';
import { AuthGuard } from '@core/guards/auth.guard';
import { AbmSectionsComponent } from './abm-sections/abm-sections.component';
import { AbmChallengesComponent } from './abm-challenges/abm-challenges.component';
import { ForbiddenComponent } from '@modules/managment/error/forbidden/forbidden.component';
import { AbmUsersComponent } from './abm-users/abm-users.component';
import { SkeletonComponent } from '@layout/init/skeleton/skeleton.component';



const routes: Routes = [
  {
    path: 'abm-sections',
    component: AbmSectionsComponent,
    canActivate:[AuthGuard],
    data : {roles : CONFIGURATION_ACCESS.MANAGMENT_ABM_SECTIONS}
  },
  {
    path: 'abm-challenges',
    component: AbmChallengesComponent,
    canActivate:[AuthGuard],
    data : {roles : CONFIGURATION_ACCESS.MANAGMENT_ABM_CHALLENGES}
  },
  {
    path: 'abm-users',
    component: AbmUsersComponent,
    canActivate:[AuthGuard],
    data : {roles : CONFIGURATION_ACCESS.MANAGMENT_ABM_USERS}
  },
  {
    path: '403',
    component: ForbiddenComponent
  },
  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule] 
})
export class AppAdministratorRoutingModule { }

