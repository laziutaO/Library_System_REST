import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BookResponce } from '../interfaces/book-responce';
import { BooksResponce } from '../interfaces/books-responce';
import { map } from 'rxjs/operators';
import { BookData } from '../interfaces/book-data';

@Injectable({
  providedIn: 'root'
})
export class EbooksService {
  private apiUrl = "https://localhost:7103/api/EBooks";

  constructor(private http: HttpClient) { }

  getAllEbooks(): Observable<BookData[]> {
    return this.http.get<BooksResponce>(this.apiUrl).pipe(map(res => res["books"].map(b => ({ ...b, type: 'ebook' as const })))
  );
  }
  getEbookById(id: string): Observable<BookData> {
    return this.http.get<BookResponce>(`${this.apiUrl}/${id}`).pipe(map(res => res["book"]));
  }
}
