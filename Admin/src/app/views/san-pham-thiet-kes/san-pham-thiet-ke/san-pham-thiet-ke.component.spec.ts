import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SanPhamThietKeComponent } from './san-pham-thiet-ke.component';

describe('SanPhamThietKeComponent', () => {
  let component: SanPhamThietKeComponent;
  let fixture: ComponentFixture<SanPhamThietKeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SanPhamThietKeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SanPhamThietKeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
