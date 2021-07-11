import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductInCategoryComponent } from './product-in-category.component';

describe('ProductInCategoryComponent', () => {
  let component: ProductInCategoryComponent;
  let fixture: ComponentFixture<ProductInCategoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductInCategoryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductInCategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
