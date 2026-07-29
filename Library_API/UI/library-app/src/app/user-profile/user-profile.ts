import { Component, inject, OnInit} from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserData } from '../interfaces/user-data';
import { UserService } from '../services/user-service';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from '../services/auth-service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-profile',
  imports: [CommonModule],
  templateUrl: './user-profile.html',
  styleUrl: './user-profile.css'
})
export class UserProfile implements OnInit{
  userData!: UserData
  userService = inject(UserService);
  authService = inject(AuthService);
  route = inject(ActivatedRoute)
  router = inject(Router)

ngOnInit(): void {
    this.userData.userName = this.authService.currentUser()!.userName; 
    this.userData.email = this.authService.currentUser()!.email;
}

logout():void {
  this.authService.currentUser.set(null);
  localStorage.setItem('token', '');
  this.router.navigate(['/login']);
}
}
