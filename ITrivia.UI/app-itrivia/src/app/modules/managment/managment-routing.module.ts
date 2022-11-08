import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {SectionsComponent } from './section/sections.component';
import { ProfileComponent } from './profile/profile.component';
import { ChallengesComponent } from './challenge/challenges/challenges.component';
import { AutocompleteComponent } from './game/autocomplete/autocomplete.component';
import { ForbiddenComponent } from './error/forbidden/forbidden.component';
import { CONFIGURATION_ACCESS, ROLES_ENUM } from '@data/contants';
import { AuthGuard } from '@core/guards/auth.guard';
import { WeeklyExpComponent } from './progress/weekly-exp/weekly-exp.component';
import { GralRankingComponent } from './progress/gral-ranking/gral-ranking.component';
import { MultchoiceComponent } from './game/multchoice/multchoice.component';
import { SelparesComponent } from './game/selpares/selpares.component';
import { GameComponent } from './game/game.component';


const routes: Routes = [
  {
    path: 'sections',
    component: SectionsComponent,
    canActivate:[AuthGuard],
    data : {roles : CONFIGURATION_ACCESS.MANAGMENT_EXPLORE}
  },
  {
    path: 'profile',
    component: ProfileComponent,
    canActivate:[AuthGuard],
    data : {roles : CONFIGURATION_ACCESS.MANAGMENT_PROFILE}
  },
  {
    path: 'challenges',
    component: ChallengesComponent,
    canActivate:[AuthGuard],
    data : {roles : CONFIGURATION_ACCESS.MANAGMENT_CHALLENGES}
  },
  {
    path: 'challenges/:id',
    component: ChallengesComponent,
    canActivate:[AuthGuard],
    data : {roles : CONFIGURATION_ACCESS.MANAGMENT_CHALLENGES}
  },
  {
    path: 'weeklyexp',
    component: WeeklyExpComponent,
    canActivate:[AuthGuard],
    data : {roles : CONFIGURATION_ACCESS.MANAGMENT_PROGRESS_EXPWEEKLY}
  },
  {
    path: 'rankgen',
    component: GralRankingComponent,
    canActivate:[AuthGuard],
    data : {roles : CONFIGURATION_ACCESS.MANAGMENT_PROGRESS_RANKGEN}
  },
  {
    path: 'game/:id',
    component: GameComponent,
    canActivate:[AuthGuard],
    data : {roles : CONFIGURATION_ACCESS.MANAGMENT_PROGRESS_RANKGEN}
  },
  {
    path: '403',
    component: ForbiddenComponent
  },
  {
    path: '',
    component: SectionsComponent,
    canActivate:[AuthGuard],
    data : {roles : CONFIGURATION_ACCESS.MANAGMENT_EXPLORE}
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule] 
})
export class AppManagmentRoutingModule { }

