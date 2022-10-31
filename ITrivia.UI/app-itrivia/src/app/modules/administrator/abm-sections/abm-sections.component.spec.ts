import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AbmSectionsComponent } from './abm-sections.component';

describe('AbmSectionsComponent', () => {
  let component: AbmSectionsComponent;
  let fixture: ComponentFixture<AbmSectionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AbmSectionsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AbmSectionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
