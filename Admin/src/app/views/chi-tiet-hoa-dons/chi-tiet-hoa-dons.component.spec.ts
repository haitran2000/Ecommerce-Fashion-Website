import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChiTietHoaDonsComponent } from './chi-tiet-hoa-dons.component';

describe('ChiTietHoaDonsComponent', () => {
  let component: ChiTietHoaDonsComponent;
  let fixture: ComponentFixture<ChiTietHoaDonsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ChiTietHoaDonsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ChiTietHoaDonsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
