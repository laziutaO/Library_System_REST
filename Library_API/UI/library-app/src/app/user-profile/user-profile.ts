import { Component, inject, OnInit} from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserData } from '../interfaces/user-data';
import { UserService } from '../services/user-service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-user-profile',
  imports: [CommonModule],
  templateUrl: './user-profile.html',
  styleUrl: './user-profile.css'
})
export class UserProfile implements OnInit{
  userData!: UserData;
  userService = inject(UserService);
  route = inject(ActivatedRoute)
  userId: string="";
  constructor(){
    this.userId = this.route.snapshot.paramMap.get('id')!;
  }
ngOnInit(): void {
    this.userService.getUserById(this.userId).subscribe(data=>{
      this.userData = data;
    })
}
}
