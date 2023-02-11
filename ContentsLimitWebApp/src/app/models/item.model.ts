export class Item {
  public id?: number;
  public name: string;
  public value: number;
  public categoryId?: number;
  constructor(name: string, value: number, categoryId?: number, id?: number) {
    this.id = id;
    this.name = name;
    this.value = value;
    this.categoryId = categoryId;
  }
}
