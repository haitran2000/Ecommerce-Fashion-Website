import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SanPhamThietKesComponent } from './san-pham-thiet-kes.component';

describe('SanPhamThietKesComponent', () => {
  let component: SanPhamThietKesComponent;
  let fixture: ComponentFixture<SanPhamThietKesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SanPhamThietKesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SanPhamThietKesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
