import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { UserData } from '../interfaces/user-data';
import { UserResponce } from '../interfaces/user-responce';
import { UsersResponce } from '../interfaces/users-responce';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl = "https://localhost:7103/api/Users";

  constructor(private http: HttpClient) {
  }

  getAllUsers(): Observable<UserData[]> {
    return this.http.get<UsersResponce>(this.apiUrl).pipe(map(u => u["users"]));
  }

  getUserById(id: string): Observable<UserData> {
    return this.http.get<UserResponce>(`${this.apiUrl}/${id}`).pipe(map(u => u["user"]));
  }
}
