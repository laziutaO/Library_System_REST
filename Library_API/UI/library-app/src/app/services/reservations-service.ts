import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ReservationGetData } from '../interfaces/reservation-get-data';
import { ReservationGetResponce } from '../interfaces/reservation-get-responce';

@Injectable({
  providedIn: 'root',
})
export class ReservationsService {
  private apiUrl = "https://localhost:7103/api/Reservations";

  constructor(private http: HttpClient) { }
  createReservation(libraryId: string, bookCopyId: string): Observable<ReservationGetData> {
    const body = { libraryId, bookCopyId };
    return this.http.post<ReservationGetResponce>(this.apiUrl, body).pipe(map(r => r["reservation"]));
  }

}
