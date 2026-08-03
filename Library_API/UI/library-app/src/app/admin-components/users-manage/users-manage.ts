import { Component, OnInit, signal, computed, effect, inject } from '@angular/core';
import { UserData } from '../../interfaces/user-data';
import { Router, RouterLink } from '@angular/router';
import { FilterService } from '../../services/filter-service';
import {UserService} from '../../services/user-service'
import {UserUpdateRequest} from '../../interfaces/user-update-request';

@Component({
  selector: 'app-users-manage',
  imports: [RouterLink],
  templateUrl: './users-manage.html',
  styleUrl: './users-manage.css',
})
export class UsersManage {
  usersList= signal<UserData[]>([]);

  public filteredBooksList = computed(()=>this.usersList()
  .filter(user => user.userName.toLowerCase()
  .includes(this.filterService.debouncedFilterUsers().toLowerCase())));

  constructor(private userService: UserService,
    public filterService: FilterService) {
  }
   ngOnInit(): void {
    this.userService.getAllUsers().subscribe((data) => {
      this.usersList.set([...this.usersList(), ...data]);
    })
  }

  deleteUser(userId: string): void {
    this.userService.deleteUser(userId).subscribe(() => {
      this.usersList.set(this.usersList().filter(user => user.id !== userId));
    });
  }
  blockUser(userId: string): void {
    const request: UserUpdateRequest = {
      isBlocked: true
    }
    this.userService.updateUser(userId, request).subscribe(() => {
      this.usersList.set(this.usersList().map(user => user.id === userId ? { ...user, isBlocked: true } : user));
    });
  }
  unblockUser(userId: string): void {
    const request: UserUpdateRequest = {
      isBlocked: false
    }
    this.userService.updateUser(userId, request).subscribe(() => {
      this.usersList.set(this.usersList().map(user => user.id === userId ? { ...user, isBlocked: false } : user));
    });
  }
  promoteUser(userId: string, role: string): void {
    this.userService.updateRole(userId, role).subscribe();
  }
}