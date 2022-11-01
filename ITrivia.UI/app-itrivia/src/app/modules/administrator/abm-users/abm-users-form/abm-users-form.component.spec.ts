import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AbmUsersFormComponent } from './abm-users-form.component';

describe('AbmUsersFormComponent', () => {
  let component: AbmUsersFormComponent;
  let fixture: ComponentFixture<AbmUsersFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AbmUsersFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AbmUsersFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
