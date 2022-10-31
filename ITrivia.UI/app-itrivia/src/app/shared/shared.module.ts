import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule,FormControl } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { CardSectionsComponent } from './components/card-sections/card-sections.component';
import * as fromcomponents from './components';
import { CardChallengesComponent } from './components/card-challenges/card-challenges.component';
import { FilterPipe } from './pipes/filter.pipe' 

@NgModule({
  declarations: [
    ...fromcomponents.components,
    CardChallengesComponent
  ],
  imports: [
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    CommonModule,
    RouterModule

  ],
  exports:[
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    CommonModule,
    RouterModule,
    ...fromcomponents.components
  ]
})
export class SharedModule { }
