import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AbmChallengesComponent } from './abm-challenges.component';

describe('AbmChallengesComponent', () => {
  let component: AbmChallengesComponent;
  let fixture: ComponentFixture<AbmChallengesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AbmChallengesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AbmChallengesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
