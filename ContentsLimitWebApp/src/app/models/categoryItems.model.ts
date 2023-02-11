import { Item } from "./item.model";

export class CategoryItems {
  public categoryId: number;
  public categoryName: string;
  public items: Item[];
  public totalAmount: number;
  constructor(id: number, name: string, items: Item[]) {
    this.categoryId = id;
    this.categoryName = name;
    this.items = items;
    this.totalAmount = this.getSum();
  }

  getSum(): number {
    var sum = 0;
    this.items.forEach(q => sum += q.value);
    return sum;
  }
}
