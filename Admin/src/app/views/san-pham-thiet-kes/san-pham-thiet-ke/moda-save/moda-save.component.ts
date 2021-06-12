import { Component, OnInit, ViewChild } from '@angular/core';
import { FabricjsEditorComponent } from '../../../../../../projects/angular-editor-fabric-js/src/public-api';

@Component({
  selector: 'app-moda-save',
  templateUrl: './moda-save.component.html',
  styleUrls: ['./moda-save.component.scss']
})
export class ModaSaveComponent implements OnInit {

  constructor() { }
  @ViewChild('canvas', {static: false}) canvas: FabricjsEditorComponent;
  ngOnInit(): void {

  }

}
