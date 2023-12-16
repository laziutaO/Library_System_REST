import { Routes } from '@angular/router';
import { UsersListComponent } from './components/users/users-list/users-list.component';

export const routes: Routes = [
    {
        path: '',
        component: UsersListComponent
    },
    {
        path: 'users',
        component: UsersListComponent
    }
];
