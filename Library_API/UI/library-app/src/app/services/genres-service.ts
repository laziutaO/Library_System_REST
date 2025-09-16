import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GenreResponce } from '../interfaces/genre-responce';
import { GenresResponce } from '../interfaces/genres-responce';
import { GenreData } from '../interfaces/genre-data';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class GenresService {
  private apiUrl = "https://localhost:7103/api/Genres";
  constructor(private http: HttpClient){}

  getAllGenres(): Observable<GenreData[]> {
      return this.http.get<GenresResponce>(this.apiUrl).pipe(map(res => res["genres"])
    );
    }

  getGenreById(): Observable<GenreData> {
      return this.http.get<GenreResponce>(this.apiUrl).pipe(map(res => res["genre"])
    );
    }
}
