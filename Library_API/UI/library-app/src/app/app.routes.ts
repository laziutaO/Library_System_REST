import { Routes } from '@angular/router';
import { Home } from './home/home';
import { BookDetails } from './book-details/book-details';
import { Browse } from './browse/browse';
import { Libraries } from './libraries/libraries';
import { LibraryDetails } from './library-details/library-details';
import { UserProfile } from './user-profile/user-profile';
import { Login } from './login/login';
import { Register } from './register/register';
import { adminGuard } from './guards/admin-guard';
import { UsersManage } from './admin-components/users-manage/users-manage';
import { BooksManage } from './admin-components/books-manage/books-manage';
import { LibsManage } from './admin-components/libs-manage/libs-manage';
import { AdminHome } from './admin-components/admin-home/admin-home';

export const routes: Routes = [
    { path: '', component: Home },
    { path: 'details/:id', component: BookDetails },
    { path: 'browse', component: Browse },
    { path: 'libraries', component: Libraries },
    { path: 'libraries/details/:id', component: LibraryDetails },
    { path: 'user', component: UserProfile },
    { path: 'register', component: Register },
    { path: 'login', component: Login },
    {
        path: 'admin',
        canActivateChild: [adminGuard],
        children: [
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            {path: 'home', component: AdminHome },
            {path: 'users', component: UsersManage},
            {path: 'books', component: BooksManage},
            {path: 'libraries', component: LibsManage}
        ]
    }
];


