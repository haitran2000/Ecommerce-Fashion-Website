import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SanPhamSanPhamThietKeComponent } from './san-pham-san-pham-thiet-ke.component';

describe('SanPhamSanPhamThietKeComponent', () => {
  let component: SanPhamSanPhamThietKeComponent;
  let fixture: ComponentFixture<SanPhamSanPhamThietKeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SanPhamSanPhamThietKeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SanPhamSanPhamThietKeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
