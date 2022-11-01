import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SkeletonManagmentComponent } from './skeleton-managment.component';

describe('SkeletonManagmentComponent', () => {
  let component: SkeletonManagmentComponent;
  let fixture: ComponentFixture<SkeletonManagmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SkeletonManagmentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SkeletonManagmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
