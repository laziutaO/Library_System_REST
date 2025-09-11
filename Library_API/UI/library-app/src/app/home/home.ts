import { Component, inject } from '@angular/core';
import { BookPanel } from '../book-panel/book-panel';
import { BookData } from '../interfaces/book-data';
import { BooksService } from '../books-service';

@Component({
  selector: 'app-home',
  imports: [BookPanel],
  templateUrl: './home.html',
  styleUrl: './home.css'
})
export class Home {
  bookList: BookData[] = [];
  booksService: BooksService = inject(BooksService);
  constructor(){
    this.bookList = this.booksService.getAllBooks();
  }
}
