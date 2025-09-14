import { Injectable, Type } from '@angular/core';
import { BookData } from '../interfaces/book-data';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BookResponce } from '../interfaces/book-responce';
import { BooksResponce } from '../interfaces/books-responce';

@Injectable({
  providedIn: 'root'
})
export class BooksService {
  private apiUrl = "https://localhost:7103/api/EBooks";

  constructor(private http: HttpClient) { }

  getAllBooks(): Observable<BooksResponce> {
    return this.http.get<BooksResponce>(this.apiUrl);
  }
  getBookById(id: string): Observable<BookResponce> {
    return this.http.get<BookResponce>(`${this.apiUrl}/${id}`);
  }
}
