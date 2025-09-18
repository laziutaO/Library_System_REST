import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BookData } from '../interfaces/book-data';
import { BookResponce } from '../interfaces/book-responce';
import { BooksFacadeService } from '../services/books-facade-service';

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
  type: "ebook" | "copy" | '' = ''

  constructor(private route: ActivatedRoute, 
    private booksFacade: BooksFacadeService){
    this.bookPanelId = this.route.snapshot.paramMap.get('id')!;
  }

  ngOnInit(): void {
    this.type = this.route.snapshot.queryParamMap.get('type') as "ebook" | "copy";
    this.booksFacade.getBookById(this.bookPanelId, this.type).subscribe(data => {
      this.bookData = data;
    })
  }

}
