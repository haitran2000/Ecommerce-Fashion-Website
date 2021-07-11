import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AspNetUserClaimsComponent } from './asp-net-user-claims.component';

describe('AspNetUserClaimsComponent', () => {
  let component: AspNetUserClaimsComponent;
  let fixture: ComponentFixture<AspNetUserClaimsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AspNetUserClaimsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AspNetUserClaimsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
