import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BookData } from '../interfaces/book-data';
import { BooksFacadeService } from '../services/books-facade-service';
import { ReviewsService } from '../services/reviews-service';
import { ReviewData } from '../interfaces/review-data';
import { CommentPanel } from '../comment-panel/comment-panel';
import { CommonModule } from '@angular/common'; 
import { LibrariesService } from '../services/libraries-service';
import { LibraryData } from '../interfaces/library-data';
import { LibraryPanel } from '../library-panel/library-panel';
import {combineLatest} from 'rxjs';

@Component({
  selector: 'app-book-details',
  imports: [CommentPanel, CommonModule, LibraryPanel],
  templateUrl: './book-details.html',
  styleUrl: './book-details.css'
})
export class BookDetails implements OnInit {
  bookData: BookData | undefined;
  libraryList: LibraryData[] = [];
  comments: ReviewData[] = [];
  bookPanelId: string = "";
  type: "ebook" | "copy" | '' = '';
  havebookLibraries: LibraryData[] = [];

  constructor(private route: ActivatedRoute,
    private booksFacade: BooksFacadeService,
    private reviewsService: ReviewsService,
  private librariesService: LibrariesService) {
    this.bookPanelId = this.route.snapshot.paramMap.get('id')!;
  }

  ngOnInit(): void {
    this.type = this.route.snapshot.queryParamMap.get('type') as "ebook" | "copy";
    combineLatest([
      this.booksFacade.getBookById(this.bookPanelId, this.type),
      this.librariesService.getAllLibraries()
    ]).subscribe(([bookData, libraries]) => {
      this.bookData = bookData;
      this.libraryList = libraries;
      this.havebookLibraries = this.libraryList.filter(lib => this.bookData?.libraryNames?.includes(lib.name));
    });
    this.reviewsService.getReviewsByBookId(this.bookPanelId).subscribe(reviews =>{
      this.comments = reviews;
    })
  }
}
