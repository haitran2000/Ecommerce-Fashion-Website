import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AspNetUserRolesComponent } from './asp-net-user-roles.component';

describe('AspNetUserRolesComponent', () => {
  let component: AspNetUserRolesComponent;
  let fixture: ComponentFixture<AspNetUserRolesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AspNetUserRolesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AspNetUserRolesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
