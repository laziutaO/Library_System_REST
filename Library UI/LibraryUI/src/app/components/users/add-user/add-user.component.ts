import { Component } from '@angular/core';
import { User } from '../../../models/user.model';
import { UsersService } from '../../../services/users.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrl: './add-user.component.css'
})
export class AddUserComponent {
  addUserRequest: User = {
    id: '',
    authId: '',
    firstName: '',
    lastName: '',
    phone: ''
  };

  constructor(private userService: UsersService, private router: Router) { }

  addUser(){
    this.userService.addUser(this.addUserRequest).subscribe(
      {
        next: (user)=> {this.router.navigate(['/users']);}
      }
    )
  }
}
