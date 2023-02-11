import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Category } from '../../models/category.model';
import { Item } from '../../models/item.model';
import { DataAccessService } from '../../services/data-access.service';

@Component({
  selector: 'app-add-item',
  templateUrl: './add-item.component.html',
  styleUrls: ['./add-item.component.css']
})
export class AddItemComponent implements OnInit {

  @Input('categoriesInput') categories!: Category[];
  @Output() addItemEvent = new EventEmitter<Item>();  

  public newItem: FormGroup = new FormGroup({
    name: new FormControl('', [Validators.required, Validators.minLength(1)]),
    value: new FormControl(0),
    category: new FormControl(1),
  });

  constructor(private dataAccessService: DataAccessService) { }

  ngOnInit(): void {    
  }  

  addItem() {
    const item: Item = new Item(this.newItem.value.name, this.newItem.value.value, this.newItem.value.category);
    this.dataAccessService.postItem(item).subscribe(itemId => {
      item.id = itemId;
      this.addItemEvent.emit(item);
      this.newItem = new FormGroup({
        name: new FormControl(''),
        value: new FormControl(0),
        category: new FormControl(1),
      });
    });
    console.log("add item event emmited");
  }
}
