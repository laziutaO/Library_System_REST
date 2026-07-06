import { Component, OnInit, signal, computed, effect } from '@angular/core';
import { EbooksService } from '../../services/ebooks-service';
import { BookCopiesService } from '../../services/book-copies-service';
import { BookData } from '../../interfaces/book-data';
import { Router, RouterLink } from '@angular/router';
import { FilterService } from '../../services/filter-service';

@Component({
  selector: 'app-books-manage',
  imports: [RouterLink],
  templateUrl: './books-manage.html',
  styleUrl: './books-manage.css',
})
export class BooksManage {
  bookList= signal<BookData[]>([]);
  public filteredBooksList = computed(()=>this.bookList()
  .filter(book => book.title.toLowerCase()
  .includes(this.filterService.debouncedFilterBooks().toLowerCase())));

  constructor(private ebooksService: EbooksService,
    private bookCopiesService: BookCopiesService,
    public filterService: FilterService) {

  }
  ngOnInit(): void {
    this.ebooksService.getAllEbooks().subscribe((data) => {
      this.bookList.set([...this.bookList(), ...data]);
    })

    this.bookCopiesService.getAllBooks().subscribe((data) => {
      this.bookList.set([...this.bookList(), ...data]);
    })
  }

  deleteBook(bookId: String, type: String): void {
    if (type === "ebook") {
      this.ebooksService.deleteBook(bookId.toString()).subscribe(() => {
        this.bookList.set(this.bookList().filter(book => book.id !== bookId));
      });
    } else if (type === "copy") {
      this.bookCopiesService.deleteBook(bookId.toString()).subscribe(() => {
        this.bookList.set(this.bookList().filter(book => book.id !== bookId));
      });
    }
  }
}
