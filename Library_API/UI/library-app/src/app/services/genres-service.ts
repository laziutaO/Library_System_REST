import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class GenresService {
  private apiUrl = "https://localhost:7103/api/EBooks";
  constructor(private http: HttpClient){}

  get
}
