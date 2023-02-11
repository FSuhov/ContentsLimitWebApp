import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { AddItemComponent } from './components/add-item/add-item.component';
import { ItemComponent } from './components/item/item.component';
import { CategoryComponent } from './components/category/category.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AddItemComponent,
    ItemComponent,
    CategoryComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
