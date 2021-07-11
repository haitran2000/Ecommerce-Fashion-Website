import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JobSeekesComponent } from './job-seekes.component';

describe('JobSeekesComponent', () => {
  let component: JobSeekesComponent;
  let fixture: ComponentFixture<JobSeekesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ JobSeekesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(JobSeekesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
