import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SelparesComponent } from './selpares.component';

describe('SelparesComponent', () => {
  let component: SelparesComponent;
  let fixture: ComponentFixture<SelparesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SelparesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SelparesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
