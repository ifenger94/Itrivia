import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AbmGamesComponent } from './abm-games.component';

describe('AbmGamesComponent', () => {
  let component: AbmGamesComponent;
  let fixture: ComponentFixture<AbmGamesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AbmGamesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AbmGamesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
