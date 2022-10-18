import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TypescriptTestComponent } from './typescript-test.component';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    TypescriptTestComponent
  ],
  imports: [
    CommonModule,
    FormsModule
  ],
  exports: [
    TypescriptTestComponent
  ]
})
export class TypescriptTestModule { }
