import { TestBed } from '@angular/core/testing';

import { MauSacService } from './mau-sac.service';

describe('MauSacService', () => {
  let service: MauSacService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MauSacService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
