import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AbmUsersComponent } from './abm-users.component';

describe('AbmUsersComponent', () => {
  let component: AbmUsersComponent;
  let fixture: ComponentFixture<AbmUsersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AbmUsersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AbmUsersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
