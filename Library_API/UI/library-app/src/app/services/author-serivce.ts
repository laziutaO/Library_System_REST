import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import {AuthorData} from '../interfaces/author-data';
import { AuthorsResponce } from '../interfaces/authors-responce';

@Injectable({
  providedIn: 'root',
})
export class AuthorSerivce {
    private apiUrl = "https://localhost:7103/api/Authors";
  
    constructor(private http: HttpClient) { }
  
    getAllAuthors(): Observable<AuthorData[]> {
      return this.http.get<AuthorsResponce>(this.apiUrl)
      .pipe(map(res => res["authors"]));
    }
}
