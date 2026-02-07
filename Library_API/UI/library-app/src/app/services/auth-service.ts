import { Injectable, signal } from '@angular/core';
import { UserAuthData } from '../interfaces/user-auth-data';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  currentUser = signal<UserAuthData | undefined | null>(undefined);
  
}
