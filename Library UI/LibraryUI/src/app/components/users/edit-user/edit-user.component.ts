import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UsersService } from '../../../services/users.service';
import { User } from '../../../models/user.model';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrl: './edit-user.component.css'
})
export class EditUserComponent {
  userDeteails: User = {
    id: '',
    firstName: '',
    lastName: '',
    phone: 0
  };

  constructor(private route: ActivatedRoute, private userService: UsersService, private router: Router) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
      const userId = params.get('id');
      if (userId){
        this.userService.getUser(userId).subscribe({
          next: (responce) =>{
            this.userDeteails = responce;
          }
        })
      }
    }});
  }

  updateUser(){
    this.userService.updateUser(this.userDeteails.id, this.userDeteails).subscribe({
      next: (responce) => {this.router.navigate(['/users']);}
    })
  }

  deleteUser(id: string){
    this.userService.deleteUser(id).subscribe({
      next: (responce) => {this.router.navigate(['/users']);}
    })
  }
}
