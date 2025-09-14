import { Component, inject, OnInit } from '@angular/core';
import { BookPanel } from '../book-panel/book-panel';
import { BookData } from '../interfaces/book-data';
import { BooksService } from '../services/books-service';
import { RouterLink } from '@angular/router';
import { BooksResponce } from '../interfaces/books-responce';

@Component({
  selector: 'app-home',
  imports: [BookPanel, RouterLink],
  templateUrl: './home.html',
  styleUrl: './home.css'
})
export class Home implements OnInit{
  bookList: BookData[] = [];
  booksResponce: BooksResponce = {};
  constructor(private booksService: BooksService){
    booksService = inject(BooksService)
  }

  ngOnInit(): void {
      this.booksService.getAllBooks().subscribe((data)=>{
        this.booksResponce = data;
        console.log(this.booksResponce)
        this.bookList = this.booksResponce["books"];
      }
      )
  }
}
