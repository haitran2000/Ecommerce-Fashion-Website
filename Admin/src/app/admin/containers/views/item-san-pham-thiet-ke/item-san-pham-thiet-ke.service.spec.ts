import { TestBed } from '@angular/core/testing';

import { ItemSanPhamThietKeService } from './item-san-pham-thiet-ke.service';

describe('ItemSanPhamThietKeService', () => {
  let service: ItemSanPhamThietKeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ItemSanPhamThietKeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
