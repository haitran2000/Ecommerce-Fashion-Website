import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { FashionOneComponent } from './fashion/fashion-one/fashion-one.component';
import { FashionTwoComponent } from './fashion/fashion-two/fashion-two.component';
import { FashionThreeComponent } from './fashion/fashion-three/fashion-three.component';
import { VegetableComponent } from './vegetable/vegetable.component';
import { WatchComponent } from './watch/watch.component';
import { FurnitureComponent } from './furniture/furniture.component';
import { FlowerComponent } from './flower/flower.component';
import { BeautyComponent } from './beauty/beauty.component';
import { ElectronicsComponent } from './electronics/electronics.component';
import { PetsComponent } from './pets/pets.component';
import { GymComponent } from './gym/gym.component';
import { ToolsComponent } from './tools/tools.component';
import { ShoesComponent } from './shoes/shoes.component';
import { BagsComponent } from './bags/bags.component';
import { MarijuanaComponent } from './marijuana/marijuana.component';

const routes: Routes = [
  {
    path: 'fashion',
    component: FashionOneComponent
  },
  {
    path: 'fashion-2',
    component: FashionTwoComponent
  },
  {
    path: 'fashion-3',
    component: FashionThreeComponent
  },
  {
    path: 'vegetable',
    component: VegetableComponent
  },
  {
    path: 'watch',
    component: WatchComponent
  },
  {
    path: 'furniture',
    component: FurnitureComponent
  },
  {
    path: 'flower',
    component: FlowerComponent
  },
  {
    path: 'beauty',
    component: BeautyComponent
  },
  {
    path: 'electronics',
    component: ElectronicsComponent
  },
  {
    path: 'pets',
    component: PetsComponent
  },
  {
    path: 'gym',
    component: GymComponent
  },
  {
    path: 'tools',
    component: ToolsComponent
  },
  {
    path: 'shoes',
    component: ShoesComponent
  },
  {
    path: 'bags',
    component: BagsComponent
  },
  {
    path: 'marijuana',
    component: MarijuanaComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
