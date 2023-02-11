import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { CategoryItems } from '../../models/categoryItems.model';
import { Item } from '../../models/item.model';

@Component({
  selector: '[app-category]',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {

  @Input('categoryInput') category!: CategoryItems;
  @Input('itemsInput') items!: Item[];  
  @Input('deleteItem') deletedItem!: number;
  @Output() deleteItemEvent = new EventEmitter<Item>();

  constructor() { }

  ngOnInit(): void {
  }

  show(): boolean {
    return this.items.length > 0;
  }

  onItemDeleted(item: Item) {
    this.deleteItemEvent.emit(item);
  }
}
