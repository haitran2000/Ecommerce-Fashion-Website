import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HoaDonsComponent } from './hoa-dons.component';

describe('HoaDonsComponent', () => {
  let component: HoaDonsComponent;
  let fixture: ComponentFixture<HoaDonsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HoaDonsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HoaDonsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
