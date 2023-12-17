import { Component } from '@angular/core';
import { User } from '../../../models/user.model';
import { UsersService } from '../../../services/users.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrl: './users-list.component.css'
})
export class UsersListComponent {
  users: User[] = [];

  constructor(private userService: UsersService, private router: Router) { }

  ngOnInit(): void {
    this.userService.getAllUsers().subscribe({ 
      next: (users)=> {this.users = users;},
      error: (err)=> console.log(err)
    });
  }

  redirectToNewUser() {
    this.router.navigate(['/users/new']);
  }
}
