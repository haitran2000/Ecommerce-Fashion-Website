import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TaoPhieuNhapComponent } from './tao-phieu-nhap.component';

describe('TaoPhieuNhapComponent', () => {
  let component: TaoPhieuNhapComponent;
  let fixture: ComponentFixture<TaoPhieuNhapComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TaoPhieuNhapComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TaoPhieuNhapComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
