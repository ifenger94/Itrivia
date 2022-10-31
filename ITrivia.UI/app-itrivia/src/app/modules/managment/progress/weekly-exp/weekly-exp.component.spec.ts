import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WeeklyExpComponent } from './weekly-exp.component';

describe('WeeklyExpComponent', () => {
  let component: WeeklyExpComponent;
  let fixture: ComponentFixture<WeeklyExpComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WeeklyExpComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(WeeklyExpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
