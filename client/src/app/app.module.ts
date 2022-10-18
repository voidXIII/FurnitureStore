import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LayoutModule } from './layout/layout.module';
import { TypescriptTestModule } from './typescript-test/typescript-test.module';
import { ComponentTestModule } from './component-test/component-test.module';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    LayoutModule,
    HttpClientModule,
    TypescriptTestModule,
    ComponentTestModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
