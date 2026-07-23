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
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { signal } from '@angular/core';
import { ReservationsService } from '../services/reservations-service';
import { ReservationGetData } from '../interfaces/reservation-get-data';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-book-details',
  imports: [CommentPanel, CommonModule, LibraryPanel, ReactiveFormsModule],
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
  reservationForm = new FormControl('');
  showReservationSuccessMessage = signal(false);
  showReservationConfirmation = signal(false);
  reservationData: ReservationGetData | null = null;
  meanReviewScore: number | null = null;
  reviewCount: number = 0;

  constructor(private route: ActivatedRoute,
    private booksFacade: BooksFacadeService,
    private reviewsService: ReviewsService,
  private librariesService: LibrariesService,
private reservationsService: ReservationsService,
private snackBar: MatSnackBar) {
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
      let reviewSum = 0;
      for(let rev of reviews){
        reviewSum += rev.rating;
      }
      this.reviewCount = reviews.length;
      this.meanReviewScore = reviews.length > 0 ? reviewSum / this.reviewCount : null;
    })
  }

  reserveBook(): void{
    if(this.reservationForm.value)
      this.reservationsService.createReservation(this.reservationForm.value, this.bookPanelId)
    .subscribe(resData =>{
      this.reservationData = resData;
      this.showReservationSuccessMessage.set(true);
      this.showReservationConfirmation.set(false);
      this.snackBar.open('Reservation successful!', 'Close', 
        { duration: 3000,
          horizontalPosition: 'right'
        });
    });
  }
}
