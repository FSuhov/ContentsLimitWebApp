import { Component, OnInit } from '@angular/core';
import { Category } from '../../models/category.model';
import { Item } from '../../models/item.model';
import { CategoryItems } from '../../models/categoryItems.model';
import { DataAccessService } from '../../services/data-access.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  categories: Category[] = [];
  categoryItems: CategoryItems[] = [];
  totalAmount!: number;  

  constructor(private dataAccessService: DataAccessService) { }

  ngOnInit(): void {
    this.fetchData();
  }

  fetchData(): void {
    this.dataAccessService.fetchCategories().subscribe((categoryResponse: Category[]) => {
      if (categoryResponse) {
        this.categories = categoryResponse;
        this.dataAccessService.fetchItems().subscribe((itemsResponse: Item[]) => {
          if (itemsResponse) {            
            this.initCategoryItems(categoryResponse, itemsResponse);
          }
        })
      }
    })
  }

  onItemAdded(item: Item) {
    console.log("add item event received");    
    var category = this.categoryItems.find(c => c.categoryId == item.categoryId);
    if (category) {
      category.items.push(item);
      category.totalAmount += item.value;
      this.totalAmount += item.value;
    }    
  }

  onItemDeleted(item: Item) {
    console.log("delete event received");
    var category = this.categoryItems.find(c => c.categoryId == item.categoryId);
    if (category) {
      if (item.id) {
        this.dataAccessService.deleteItem(item.id).subscribe();
      }
      var indexOfItem = category.items.findIndex(q => q.id == item.id);
      category.items.splice(indexOfItem, 1);
      category.totalAmount -= item.value;
      this.totalAmount -= item.value;
    }
  }

  show(): boolean {
    if (this.categoryItems.length > 0) {
      for (let i = 0; i < this.categoryItems.length; i++) {
        if (this.categoryItems[i].items.length > 0) {
          return true;
        }
      }      
    }
    return false;
  }

  private initCategoryItems(categories: Category[], items: Item[]) {
    let fetchedCategoryItems: CategoryItems[] = [];
    categories.forEach(category => {
      const filteredItems = items.filter(i => i.categoryId === category.id);
      const categoryItems = new CategoryItems(category.id, category.name, filteredItems);
      fetchedCategoryItems.push(categoryItems);
    })
    this.categoryItems = fetchedCategoryItems;
    this.setTotalAmount();
    console.log("Category initialized, number " + this.categoryItems.length);
  }

  private setTotalAmount() {
    let amount = 0;
    this.categoryItems.forEach(ci => amount += ci.totalAmount);
    this.totalAmount = amount;
  }
}
