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
import { AdminHome } from './admin-components/admin-home/admin-home';
import { AdminLayoutComponent } from './admin-components/admin-layout-component/admin-layout-component';
import { EditBookForm} from './admin-components/edit-book-form/edit-book-form';
import { AddBookForm} from './admin-components/add-book-form/add-book-form';
import { LibrariesManage } from './admin-components/libraries-manage/libraries-manage';
import { EditLibraryForm } from './admin-components/edit-library-form/edit-library-form';
import { AddLibraryForm } from './admin-components/add-library-form/add-library-form';

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
        component: AdminLayoutComponent,
        children: [
            {path: '', redirectTo: 'home', pathMatch: 'full' },
            {path: 'home', component: AdminHome },
            {path: 'users', component: UsersManage},
            {path: 'books', component: BooksManage},
            {path: 'libraries', component: LibrariesManage},
            {path: 'books/edit/:id', component: EditBookForm },
            {path: 'books/add', component: AddBookForm },
            {path: 'libraries/edit/:id', component: EditLibraryForm },
            {path: 'libraries/add', component: AddLibraryForm },
        ]
    }
];


