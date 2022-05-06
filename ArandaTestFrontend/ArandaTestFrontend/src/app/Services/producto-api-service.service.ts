import { Injectable } from '@angular/core';
import { Producto, ProductoM } from './../models/Producto';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ProductosFiltrado } from '../models/ProductosFiltrado';

@Injectable({
  providedIn: 'root'
})
export class ProductoApiServiceService {

  serverUrl = 'https://localhost:44326/';

  constructor(private http: HttpClient) { }

  obtenerProductos() {
    return this.http.get<Producto>(this.serverUrl + 'api/Producto').pipe(
      catchError(this.handleError)
    );
  }

  obtenerProductosFiltrados(fieldFilter: string, criterioFilter: string, fieldOrder: string, orderAsc: boolean, page: number, itemxpage: number) {
    return this.http.get<ProductosFiltrado>(this.serverUrl + 'api/Producto/' + fieldOrder + '/' + orderAsc + '/' + page + '/' + itemxpage + (criterioFilter === '' ? '/ninguno' : '/') + criterioFilter + (fieldFilter === '' ? '/ninguno' : '/') + fieldFilter ).pipe(
      catchError(this.handleError)
    );
  }

  obtenerProducto(id: number) {
    return this.http.get<ProductoM>(this.serverUrl + 'api/Producto/' + id).pipe(
      catchError(this.handleError)
    );
  }

  crearProducto(producto: Producto) {
    return this.http.post<any>(this.serverUrl + 'api/Producto', producto)
    .pipe(
      catchError(this.handleError)
    );
  }

  actualizarProducto(producto: Producto, id: number) {
    return this.http.put<any>(this.serverUrl + 'api/Producto/' + id, producto)
    .pipe(
      catchError(this.handleError)
    );
  }

  eliminarProducto(id: number) {
    return this.http.delete(this.serverUrl + 'api/Producto/' + id).pipe(
      catchError(this.handleError)
    );
  }

  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      console.error('An error occurred:', error.error);
    } else {
      console.error(
        `Backend returned code ${error.status}, body was: `, error.error);
    }
    return throwError(() => new Error('Something bad happened; please try again later.'));
  }
}
