import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemSanPhamThietKeComponent } from './item-san-pham-thiet-ke.component';

describe('ItemSanPhamThietKeComponent', () => {
  let component: ItemSanPhamThietKeComponent;
  let fixture: ComponentFixture<ItemSanPhamThietKeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ItemSanPhamThietKeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemSanPhamThietKeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
