import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TaoPhieuNhapsComponent } from './tao-phieu-nhaps.component';

describe('TaoPhieuNhapsComponent', () => {
  let component: TaoPhieuNhapsComponent;
  let fixture: ComponentFixture<TaoPhieuNhapsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TaoPhieuNhapsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TaoPhieuNhapsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
