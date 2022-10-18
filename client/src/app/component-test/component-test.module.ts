import { NgModule, Pipe } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ParentComponent } from './parent/parent.component';
import { ChildComponent } from './child/child.component';
import { MyPipe } from './model';

@Pipe({
  name:"pipeTest"
})
class PipeTest{
  transform(value: string){
    let text = value + "beautiful"
    return text;
  }
}

@NgModule({
  declarations: [
    ParentComponent,
    ChildComponent,
    MyPipe
  ],
  imports: [
    CommonModule
  ],
  exports: [
    ParentComponent
  ]

})
export class ComponentTestModule { }
