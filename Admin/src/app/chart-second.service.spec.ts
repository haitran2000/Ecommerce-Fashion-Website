import { TestBed } from '@angular/core/testing';

import { ChartSecondService } from './chart-second/chart-second.service';

describe('ChartSecondService', () => {
  let service: ChartSecondService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ChartSecondService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
