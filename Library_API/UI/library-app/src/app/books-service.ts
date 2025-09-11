import { Injectable } from '@angular/core';
import { BookData } from './interfaces/book-data';

@Injectable({
  providedIn: 'root'
})
export class BooksService {
  protected bookList: BookData[] = [{
    id: '1',
    title: 'The Angular Journey',
    isbn: '978-1-23456-789-0',
    publisher: 'TechPress',
    year: 2023,
    pagesCount: 320,
    description: 'A practical guide to mastering Angular applications from scratch.',
    coverImageUrl: 'testCover1.jpg',
    fileUrl: 'assets/books/angular-journey.pdf',
    bookAccessType: 1
  },
  {
    id: '2',
    title: 'TypeScript in Depth',
    isbn: '978-0-98765-432-1',
    publisher: 'CodeWorld',
    year: 2021,
    pagesCount: 280,
    description: 'Deep dive into TypeScript for large-scale applications.',
    coverImageUrl: 'testCover2.jpg',
    fileUrl: 'assets/books/typescript-depth.pdf',
    bookAccessType: 2
  },
  {
    id: '3',
    title: 'Clean Code for Libraries',
    isbn: '978-9-87654-321-0',
    publisher: 'DevBooks',
    year: 2019,
    pagesCount: 400,
    description: 'Principles of writing clean, maintainable code applied to digital library systems.',
    coverImageUrl: 'testCover3.jpg',
    fileUrl: 'assets/books/clean-code.pdf',
    bookAccessType: 1
  }];

  constructor(){}

  getAllBooks() : BookData[]{
    return this.bookList;
  } 
    getBookById(id: string): BookData | undefined{
    const bookSample = this.bookList.find((book) => book.id === id);
    return bookSample;
  }
}
