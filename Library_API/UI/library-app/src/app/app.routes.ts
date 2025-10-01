import { Routes } from '@angular/router';
import { Home } from './home/home';
import { BookDetails } from './book-details/book-details';
import { Browse } from './browse/browse';
import { Libraries } from './libraries/libraries';
import { LibraryDetails } from './library-details/library-details';
import { UserProfile } from './user-profile/user-profile';
import { Login } from './login/login';
import { Register } from './register/register';
import { Component } from '@angular/core';
import { MainLayoutComponent } from './main-layout-component/main-layout-component';
import { AuthLayoutComponent } from './auth-layout-component/auth-layout-component';

export const routes: Routes = [{
    path: '',
    component: MainLayoutComponent,
    children: [
        { path: '', component: Home },
        { path: 'details/:id', component: BookDetails },
        { path: 'browse', component: Browse },
        { path: 'libraries', component: Libraries },
        { path: 'libraries/details/:id', component: LibraryDetails },
        { path: 'user/:id', component: UserProfile }
    ]
},
{
    path: '',
    component: AuthLayoutComponent,
    children: [
        { path: 'register', component: Register },
        { path: 'login', component: Login }
    ]
}];


