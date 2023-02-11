import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { Item } from '../../models/item.model';

@Component({
  selector: '[app-item]',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.css']
})
export class ItemComponent implements OnInit {
  @Input('itemInput') item!: Item;
  @Output() deleteItemEvent = new EventEmitter<Item>();

  constructor() { }

  ngOnInit(): void {
  }

  deleteItem(item: Item) {
    this.deleteItemEvent.emit(item);
  }
}
