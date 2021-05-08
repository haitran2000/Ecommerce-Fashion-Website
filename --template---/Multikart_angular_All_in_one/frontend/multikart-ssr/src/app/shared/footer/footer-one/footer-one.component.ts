import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-footer-one',
  templateUrl: './footer-one.component.html',
  styleUrls: ['./footer-one.component.scss']
})
export class FooterOneComponent implements OnInit {

  @Input() class: string = 'footer-light' // Default class 
  @Input() themeLogo: string = 'assets/images/icon/logo.png' // Default Logo
  @Input() newsletter: boolean = true; // Default True

  public today: number = Date.now();

  constructor() { }

  ngOnInit(): void {
  }

}
