import { TestBed } from '@angular/core/testing';

import { HisProfileChallengeService } from './his-profile-challenge.service';

describe('HisProfileChallengeService', () => {
  let service: HisProfileChallengeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HisProfileChallengeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
