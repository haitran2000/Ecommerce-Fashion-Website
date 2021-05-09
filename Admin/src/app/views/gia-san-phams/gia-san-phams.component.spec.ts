import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GiaSanPhamsComponent } from './gia-san-phams.component';

describe('GiaSanPhamsComponent', () => {
  let component: GiaSanPhamsComponent;
  let fixture: ComponentFixture<GiaSanPhamsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GiaSanPhamsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GiaSanPhamsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
