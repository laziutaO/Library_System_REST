import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { UserData } from '../interfaces/user-data';
import { UserResponce } from '../interfaces/user-responce';
import { UsersResponce } from '../interfaces/users-responce';
import { UserUpdateRequest } from '../interfaces/user-update-request';

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

  getCurrentUser():Observable<UserData> {
    return this.http.get<UserResponce>(`${this.apiUrl}/current`).pipe(map(u => u["user"]));
  }
  updateUser(id: string, userRequest: UserUpdateRequest): Observable<HttpResponse<void>>{
    return this.http.patch<HttpResponse<void>>(`${this.apiUrl}/${id}`, userRequest);
  }

  deleteUser(id: string):Observable<HttpResponse<void>> {
     return this.http.delete<HttpResponse<void>>(`${this.apiUrl}/${id}`);
  }

  updateRole(id: string, role: string): Observable<void> {
    return this.http.patch<void>(`${this.apiUrl}/${id}`, {role});
  }
}
