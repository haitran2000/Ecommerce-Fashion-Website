import { TestBed } from '@angular/core/testing';

import { SanPhamSanPhamThietKeService } from './san-pham-san-pham-thiet-ke.service';

describe('SanPhamSanPhamThietKeService', () => {
  let service: SanPhamSanPhamThietKeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SanPhamSanPhamThietKeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
