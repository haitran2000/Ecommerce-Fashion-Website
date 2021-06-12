import { TestBed } from '@angular/core/testing';

import { SanPhamThietKeService } from './san-pham-thiet-ke.service';

describe('SanPhamThietKeService', () => {
  let service: SanPhamThietKeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SanPhamThietKeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
