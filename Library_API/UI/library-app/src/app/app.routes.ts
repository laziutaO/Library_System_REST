import { Routes } from '@angular/router';
import { Home } from './home/home';
import { BookDetails } from './book-details/book-details';

export const routes: Routes = [
    { path: '', component: Home },
    { path: 'details/:id', component: BookDetails }
];
