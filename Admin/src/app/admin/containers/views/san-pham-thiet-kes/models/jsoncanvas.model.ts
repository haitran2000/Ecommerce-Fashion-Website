// import { Object } from "./object.model"

import { Objects } from "./object.model"

export class JSONCanvas{
    public version : string
    public objects : Objects
}
export class JSONCanvasHelper extends JSONCanvas{
    init(){
      this.objects = Object.assign(new Objects, this.objects )
    }
}