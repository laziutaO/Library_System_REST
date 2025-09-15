import { Component, inject, OnInit } from '@angular/core';
import { BookPanel } from '../book-panel/book-panel';
import { BookData } from '../interfaces/book-data';
import { EbooksService } from '../services/ebooks-service';
import { BookCopiesService } from '../services/book-copies-service';
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

  constructor(private ebooksService: EbooksService, 
    private booksCopyService: BookCopiesService){

  }

  ngOnInit(): void {
      this.ebooksService.getAllEbooks().subscribe((data)=>{
        this.bookList.push(...data);
      }
      )

      this.booksCopyService.getAllBooks().subscribe((data)=>{
        this.bookList.push(...data);
      }
      )
  }
}
