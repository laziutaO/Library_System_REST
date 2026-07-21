import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BookResponce } from '../interfaces/book-responce';
import { BooksResponce } from '../interfaces/books-responce';
import { map } from 'rxjs/operators';
import { BookData } from '../interfaces/book-data';
import { BookCopyCreateRequest } from '../interfaces/book-copy-create-request';

@Injectable({
  providedIn: 'root'
})
export class BookCopiesService{
  private apiUrl = "https://localhost:7103/api/BookCopies";
  private apiUrlGetByGenres = "https://localhost:7103/api/BookCopies/genres/";

  constructor(private http: HttpClient) { }

  getAllBooks(): Observable<BookData[]> {
    return this.http.get<BooksResponce>(this.apiUrl)
    .pipe(map(res => res["books"].map(b => ({ ...b, type: 'copy' as const }))));
  }
  getBookById(id: string): Observable<BookData> {
    return this.http.get<BookResponce>(`${this.apiUrl}/${id}`)
    .pipe(map(res => res["book"]));
  }
  getBooksByGenre(genre: string): Observable<BookData[]>{
    return this.http.get<BooksResponce>(this.apiUrlGetByGenres + genre)
    .pipe(map(book => book["books"].map(b => ({ ...b, type: 'copy' as const }))));
  }
  deleteBook(id: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
  createBook(book: BookCopyCreateRequest): Observable<any> {
    return this.http.post(this.apiUrl, book);
  }
}
