import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AspNetUserLoginsComponent } from './asp-net-user-logins.component';

describe('AspNetUserLoginsComponent', () => {
  let component: AspNetUserLoginsComponent;
  let fixture: ComponentFixture<AspNetUserLoginsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AspNetUserLoginsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AspNetUserLoginsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
