import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuthHistoriesComponent } from './auth-histories.component';

describe('AuthHistoriesComponent', () => {
  let component: AuthHistoriesComponent;
  let fixture: ComponentFixture<AuthHistoriesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AuthHistoriesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AuthHistoriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
