import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UsersListComponent } from './components/users/users-list/users-list.component';
import { AddUserComponent } from './components/users/add-user/add-user.component';

export const routes: Routes = [
  {
      path: '',
      component: UsersListComponent
  },
  {
      path: 'users',
      component: UsersListComponent
  },
  {
    path: 'users/new',
    component: AddUserComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
