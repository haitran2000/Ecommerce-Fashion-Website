import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChartThirdComponent } from './chart-third.component';

describe('ChartThirdComponent', () => {
  let component: ChartThirdComponent;
  let fixture: ComponentFixture<ChartThirdComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ChartThirdComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ChartThirdComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
