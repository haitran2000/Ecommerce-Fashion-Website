import { NgModule,CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import {ProductsRoutingModule} from './products-routing.module'
import { ProductsComponent } from './products.component';
import {MatDialogModule, MatDialogRef} from '@angular/material/dialog';
import {MatTableModule} from '@angular/material/table'
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import { ProductComponent } from './product/product.component';
import {MatTabsModule} from '@angular/material/tabs';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';

import { MatChipsModule } from '@angular/material/chips';
import { MatRippleModule } from '@angular/material/core';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatFormFieldModule } from '@angular/material/form-field';

import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSelectModule } from '@angular/material/select';
import {MatStepperModule} from '@angular/material/stepper';
import { MatSortModule } from '@angular/material/sort';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RegistrationFormComponent } from '../account/registration-form/registration-form.component';
import { ProductdetailComponent } from './productdetail/productdetail.component';
@NgModule({
  imports: [
    CommonModule,
    ProductsRoutingModule,
    MatDialogModule,
    MatTableModule,
    MatIconModule,
    MatButtonModule,
    MatSnackBarModule,
    MatTabsModule,
    MatFormFieldModule,
    MatInputModule ,
    MatPaginatorModule,
    MatSelectModule ,
    CKEditorModule,
    MatStepperModule,
    FormsModule,
    ReactiveFormsModule,
    MatSortModule,
  ],
  exports: [
    MatSortModule,
  ],
  declarations: [ProductsComponent,
                ProductComponent,
                RegistrationFormComponent,
                ProductdetailComponent,
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class ProductsModule { }
