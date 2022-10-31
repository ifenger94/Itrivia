import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '@shared/shared.module';
import { AppAdministratorRoutingModule } from './administrator-routing.module';
import { AbmSectionsComponent } from './abm-sections/abm-sections.component';
import { AbmChallengesComponent } from './abm-challenges/abm-challenges.component';
import { AbmUsersComponent } from './abm-users/abm-users.component';
import {NgxPaginationModule} from 'ngx-pagination';
import { AbmGamesComponent } from './abm-challenges/abm-games/abm-games.component';
import { AbmUsersFormComponent } from './abm-users/abm-users-form/abm-users-form.component';


@NgModule({
  declarations: [
      AbmSectionsComponent,
      AbmChallengesComponent,
      AbmUsersComponent,
      AbmGamesComponent,
      AbmUsersFormComponent

  ],
  imports: [
     CommonModule,
     AppAdministratorRoutingModule,
     SharedModule,
     NgxPaginationModule

  ]
})
export class AdministratortModule { }
