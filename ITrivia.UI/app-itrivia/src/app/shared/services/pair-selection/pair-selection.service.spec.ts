import { TestBed } from '@angular/core/testing';

import { PairSelectionService } from './pair-selection.service';

describe('PairSelectionService', () => {
  let service: PairSelectionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PairSelectionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
