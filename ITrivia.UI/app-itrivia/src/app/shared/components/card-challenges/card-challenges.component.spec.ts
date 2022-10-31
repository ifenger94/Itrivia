import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CardChallengesComponent } from './card-challenges.component';

describe('CardChallengesComponent', () => {
  let component: CardChallengesComponent;
  let fixture: ComponentFixture<CardChallengesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CardChallengesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CardChallengesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
