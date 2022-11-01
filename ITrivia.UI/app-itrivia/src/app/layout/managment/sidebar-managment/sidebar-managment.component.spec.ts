import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SidebarManagmentComponent } from './sidebar-managment.component';

describe('SidebarManagmentComponent', () => {
  let component: SidebarManagmentComponent;
  let fixture: ComponentFixture<SidebarManagmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SidebarManagmentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SidebarManagmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
