import { Component, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BookData } from '../interfaces/book-data';
import { BooksService } from '../books-service';

@Component({
  selector: 'app-book-details',
  imports: [],
  templateUrl: './book-details.html',
  styleUrl: './book-details.css'
})
export class BookDetails {
  route: ActivatedRoute = inject(ActivatedRoute)
  booksService: BooksService = inject(BooksService)
  bookData: BookData | undefined;


  constructor(){
    const bookPanelId = <string>this.route.snapshot.params['id'];
    this.bookData = this.booksService.getBookById(bookPanelId);
  }
}
