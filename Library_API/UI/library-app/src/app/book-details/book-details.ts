import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BookData } from '../interfaces/book-data';
import { BooksService } from '../services/books-service';
import { BookResponce } from '../interfaces/book-responce';

@Component({
  selector: 'app-book-details',
  imports: [],
  templateUrl: './book-details.html',
  styleUrl: './book-details.css'
})
export class BookDetails implements OnInit{
  bookData: BookData | undefined;
  bookResponce: BookResponce = {};
  bookPanelId: string= "";

  constructor(private route: ActivatedRoute, private booksService: BooksService){
    route = inject(ActivatedRoute)
    booksService = inject(BooksService)
    this.bookPanelId = <string>this.route.snapshot.params['id'];
  }

  ngOnInit(): void {
    this.booksService.getBookById(this.bookPanelId).subscribe(data => {
      this.bookResponce = data;
      this.bookData = this.bookResponce["book"];
    })
  }

}
