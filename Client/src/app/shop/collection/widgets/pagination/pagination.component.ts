import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Product } from '../../../../shared/classes/product';

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.scss']
})
export class PaginationComponent implements OnInit {

  @Input() products: Product[] = [];
  @Input() paginate: any = {};

  @Output() setPage  : EventEmitter<any> = new EventEmitter<any>();
    
  constructor() { 
  }

  ngOnInit(): void {
  }

  pageSet(page: number) {
    this.setPage.emit(page);  // Set Page Number  
  }

}
