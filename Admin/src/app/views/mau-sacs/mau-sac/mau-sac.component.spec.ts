import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MauSacComponent } from './mau-sac.component';

describe('MauSacComponent', () => {
  let component: MauSacComponent;
  let fixture: ComponentFixture<MauSacComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MauSacComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MauSacComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
