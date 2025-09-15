import { Injectable } from '@angular/core';
import { BookCopiesService } from './book-copies-service';
import { EbooksService } from './ebooks-service';
import { Observable } from 'rxjs';
import { BookData } from '../interfaces/book-data';

@Injectable({
  providedIn: 'root'
})
export class BooksFacadeService {
  constructor(private bookCopiesSevice: BookCopiesService,
    private ebookService: EbooksService
  )
  {}

  getBookById(id: string, type: "ebook" | "copy"): Observable<BookData>{
    return type === "ebook" ?
      this.ebookService.getEbookById(id):
      this.bookCopiesSevice.getBookById(id); 
  }
}
