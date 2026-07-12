import { Component, OnInit, signal, computed, effect } from '@angular/core';
import { GenresService } from '../services/genres-service';
import { GenreData } from '../interfaces/genre-data';
import { BookData } from '../interfaces/book-data';
import { EbooksService } from '../services/ebooks-service';
import { BookCopiesService } from '../services/book-copies-service';
import { BookPanel } from '../book-panel/book-panel';
import { RouterLink, ActivatedRoute } from '@angular/router';
import { BooksFacadeService } from '../services/books-facade-service';
import { FilterService } from '../services/filter-service';

@Component({
  selector: 'app-browse',
  imports: [BookPanel],
  templateUrl: './browse.html',
  styleUrl: './browse.css'
})
export class Browse implements OnInit {
  genreList: GenreData[] = [];
  booksList = signal<BookData[]>([]);
  selectedGenre: string = "All Books";
  searchedBooks = computed(()=>this.booksList()
  .filter(book => book.title.toLowerCase()
  .includes(this.filterService.debouncedFilterText().toLowerCase())));

  constructor(private genresService: GenresService,
    private ebooksService: EbooksService,
    private bookcopiesService: BookCopiesService,
    private booksFacadeService: BooksFacadeService,
    private route: ActivatedRoute,
  private filterService: FilterService) {
    
  }

  ngOnInit(): void {
    this.genresService.getAllGenres().subscribe((data) => {
      this.genreList = data;
    });
    this.filterBooks("");
  }

  filterBooks(text: string | null) {
    if (!text) {
      this.selectedGenre = 'All Books';
      this.booksList.set([]);
      this.ebooksService.getAllEbooks().subscribe((data) => {
        this.booksList.update(prevItem => [...prevItem, ...data]);
      }
      )

      this.bookcopiesService.getAllBooks().subscribe((data) => {
        this.booksList.update(prevItem => [...prevItem, ...data]);
      }
      )
    }
    else {
      this.selectedGenre = text;
      this.booksList.set([]);
      this.ebooksService.getBooksByGenre(text).subscribe((data) => {
        this.booksList.update(prevItem => [...prevItem, ...data]);
      })

      this.bookcopiesService.getBooksByGenre(text).subscribe((data) => {
        this.booksList.update(prevItem => [...prevItem, ...data]);
      })
    }

  }
}
