import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GralRankingComponent } from './gral-ranking.component';

describe('GralRankingComponent', () => {
  let component: GralRankingComponent;
  let fixture: ComponentFixture<GralRankingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GralRankingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GralRankingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
