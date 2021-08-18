import { TestBed } from '@angular/core/testing';

import { ChartThirdService } from './chart-third.service';

describe('ChartThirdService', () => {
  let service: ChartThirdService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ChartThirdService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
