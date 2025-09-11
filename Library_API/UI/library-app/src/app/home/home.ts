import { Component, inject } from '@angular/core';
import { BookPanel } from '../book-panel/book-panel';
import { BookData } from '../interfaces/book-data';
import { BooksService } from '../books-service';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-home',
  imports: [BookPanel, RouterLink],
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
