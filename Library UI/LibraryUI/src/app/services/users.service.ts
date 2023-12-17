import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  baseApiUrl: string = 'https://localhost:7103';
  constructor(private http: HttpClient) { }

  getAllUsers(): Observable<User[]>{
    return this.http.get<User[]>(this.baseApiUrl + '/api/Users');
  }

  addUser(addUserRequest: User): Observable<User> {
    addUserRequest.id = "00000000-0000-0000-0000-000000000000";
    addUserRequest.authId = "00000000-0000-0000-0000-000000000000";
    return this.http.post<User>(this.baseApiUrl + '/api/Users', addUserRequest);
  }
}