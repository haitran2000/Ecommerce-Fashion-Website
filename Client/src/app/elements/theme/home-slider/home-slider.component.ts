import { Component, OnInit } from '@angular/core';
import { HomeSlider } from '../../../shared/data/slider';

@Component({
  selector: 'app-home-slider',
  templateUrl: './home-slider.component.html',
  styleUrls: ['./home-slider.component.scss']
})
export class HomeSliderComponent implements OnInit {

  public HomeSliderConfig: any = HomeSlider;
  
  constructor() { }

  ngOnInit(): void {
  }

}
