import { Injectable } from '@angular/core';
import { ReviewsResponce } from '../interfaces/reviews-responce';
import { Observable } from 'rxjs';
import { map } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ReviewData } from '../interfaces/review-data';
import { ReviewResponce } from '../interfaces/review-responce';

@Injectable({
  providedIn: 'root',
})
export class ReviewsService {
    private apiUrl = "https://localhost:7103/api/Reviews";

  constructor(private http: HttpClient) {
  }
    getAllReviews(): Observable<ReviewData[]> {
      return this.http.get<ReviewsResponce>(this.apiUrl).pipe(map(r => r["reviews"]));
    }
  
    getReviewById(id: string): Observable<ReviewData> {
      return this.http.get<ReviewResponce>(`${this.apiUrl}/${id}`).pipe(map(r => r["review"]));
    }

    getReviewsByBookId(bookId: string): Observable<ReviewData[]> {
      return this.http.get<ReviewsResponce>(`${this.apiUrl}/book`, { params: {bookId}}).pipe(map(r => r["reviews"]));
    }
}
