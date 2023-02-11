import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Category } from '../models/category.model';
import { Item } from '../models/item.model';
import { environment } from 'src/environments/environment';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class DataAccessService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  fetchCategories() {
    return this.http
      .get<Category[]>(this.baseUrl + 'categories')
      .pipe(
        tap(_ => this.log('fetched categories')),
        catchError(this.handleError<Category[]>('getCategories', []))
      );
  }

  fetchItems() {
    return this.http
      .get<Item[]>(this.baseUrl + 'items')
      .pipe(
        tap(_ => this.log('fetched items')),
        catchError(this.handleError<Item[]>('getItems', []))
      );
  }

  postItem(item: Item) {
    return this.http.post(this.baseUrl + 'items', item).pipe(map((data: any) => data));
  }

  deleteItem(id: number) {
    const url = `${this.baseUrl}items?id=${id}`
    return this.http.delete(url).pipe(map((data: any) => data));
  }

  private handleError<T>(_operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {      
      console.error(error);
      return of(result as T);
    };
  }

  private log(message: string) {
    console.log(message);
  }
}
