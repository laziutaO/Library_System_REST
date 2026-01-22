import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BookData } from '../interfaces/book-data';
import { BooksFacadeService } from '../services/books-facade-service';
import { ReviewsService } from '../services/reviews-service';
import { ReviewData } from '../interfaces/review-data';
import { CommentPanel } from '../comment-panel/comment-panel';
import { CommonModule } from '@angular/common'; 

@Component({
  selector: 'app-book-details',
  imports: [CommentPanel, CommonModule],
  templateUrl: './book-details.html',
  styleUrl: './book-details.css'
})
export class BookDetails implements OnInit {
  bookData: BookData | undefined;
  comments: ReviewData[] = [];
  bookPanelId: string = "";
  type: "ebook" | "copy" | '' = ''

  constructor(private route: ActivatedRoute,
    private booksFacade: BooksFacadeService,
    private reviewsService: ReviewsService) {
    this.bookPanelId = this.route.snapshot.paramMap.get('id')!;
  }

  ngOnInit(): void {
    this.type = this.route.snapshot.queryParamMap.get('type') as "ebook" | "copy";

    this.booksFacade.getBookById(this.bookPanelId, this.type).subscribe(data => {
      this.bookData = data;
    });

    this.reviewsService.getAllReviews().subscribe(data => {
      this.comments = data;
    });
  }
}
