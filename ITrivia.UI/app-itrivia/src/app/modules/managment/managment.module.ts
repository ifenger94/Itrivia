import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppManagmentRoutingModule } from './managment-routing.module';
import { SharedModule } from '@shared/shared.module';
import { ChartsModule } from 'ng2-charts';

import { SectionsComponent } from './section/sections.component';
import { ProfileComponent } from './profile/profile.component';
import { ChallengesComponent } from './challenge/challenges/challenges.component';
import { FilterPipe } from '@shared/pipes/filter.pipe';
import { FormsModule } from '@angular/forms';
import { AutocompleteComponent } from './game/autocomplete/autocomplete.component';
import { ForbiddenComponent } from './error/forbidden/forbidden.component';
import { WeeklyExpComponent } from './progress/weekly-exp/weekly-exp.component';
import { GralRankingComponent } from './progress/gral-ranking/gral-ranking.component';
import { MultchoiceComponent } from './game/multchoice/multchoice.component';
import { SelparesComponent } from './game/selpares/selpares.component';
import { GameComponent } from './game/game.component';


@NgModule({
  declarations: [
    SectionsComponent,
    ProfileComponent,
    ChallengesComponent,
    FilterPipe,
    AutocompleteComponent,
    ForbiddenComponent,
    WeeklyExpComponent,
    GralRankingComponent,
    MultchoiceComponent,
    SelparesComponent,
    GameComponent
  ],
  imports: [
    CommonModule,
    AppManagmentRoutingModule,
    SharedModule,
    FormsModule,
    ChartsModule
  ]
})
export class ManagmentModule { }
