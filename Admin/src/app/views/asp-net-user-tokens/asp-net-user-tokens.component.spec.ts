import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AspNetUserTokensComponent } from './asp-net-user-tokens.component';

describe('AspNetUserTokensComponent', () => {
  let component: AspNetUserTokensComponent;
  let fixture: ComponentFixture<AspNetUserTokensComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AspNetUserTokensComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AspNetUserTokensComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
