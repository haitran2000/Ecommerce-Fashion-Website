import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-stock-inventory',
  templateUrl: './stock-inventory.component.html',
  styleUrls: ['./stock-inventory.component.scss']
})
export class StockInventoryComponent implements OnInit {

  @Input() stock: any;

  constructor() { }

  ngOnInit(): void {
  }

}
