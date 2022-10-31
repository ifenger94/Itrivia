import { TestBed } from '@angular/core/testing';

import { WebApiBaseService } from './web-api-base.service';

describe('WebApiBaseService', () => {
  let service: WebApiBaseService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(WebApiBaseService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
