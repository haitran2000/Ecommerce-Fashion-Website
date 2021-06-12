import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModaSaveComponent } from './moda-save.component';

describe('ModaSaveComponent', () => {
  let component: ModaSaveComponent;
  let fixture: ComponentFixture<ModaSaveComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ModaSaveComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ModaSaveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
