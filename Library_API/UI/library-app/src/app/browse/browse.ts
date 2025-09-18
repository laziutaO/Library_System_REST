import { Component, OnInit, signal } from '@angular/core';
import { GenresService } from '../services/genres-service';
import { GenreData } from '../interfaces/genre-data';
import { BookData } from '../interfaces/book-data';
import { EbooksService } from '../services/ebooks-service';
import { BookCopiesService } from '../services/book-copies-service';
import { BookPanel } from '../book-panel/book-panel';
import { RouterLink, ActivatedRoute } from '@angular/router';
import { BooksFacadeService } from '../services/books-facade-service';

@Component({
  selector: 'app-browse',
  imports: [BookPanel],
  templateUrl: './browse.html',
  styleUrl: './browse.css'
})
export class Browse implements OnInit {
  genreList: GenreData[] = [];
  booksList: BookData[] = [];
  selectedGenre: string = "All Books";
  filterTextString: string | null;
  filterText = signal('');


  constructor(private genresService: GenresService,
    private ebooksService: EbooksService,
    private bookcopiesService: BookCopiesService,
    private booksFacadeService: BooksFacadeService,
    private route: ActivatedRoute) {
    this.filterTextString = this.route.snapshot.paramMap?.get('q');
  }

  ngOnInit(): void {
    this.genresService.getAllGenres().subscribe((data) => {
      this.genreList = data;
    });
    this.filterBooks("");
  }

  filterBooks(text: string | null) {
    console.log(text);
    if (!text) {
      this.selectedGenre = 'All Books';
      this.booksList = [];
      this.ebooksService.getAllEbooks().subscribe((data) => {
        this.booksList.push(...data);
      }
      )

      this.bookcopiesService.getAllBooks().subscribe((data) => {
        this.booksList.push(...data);
      }
      )
    }
    else {
      this.selectedGenre = text;
      this.booksList = [];
      this.ebooksService.getBooksByGenre(text).subscribe((data) => {
        this.booksList.push(...data);
      })

      this.bookcopiesService.getBooksByGenre(text).subscribe((data) => {
        this.booksList.push(...data);
      })
    }

  }
}
