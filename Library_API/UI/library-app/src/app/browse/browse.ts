import { Component, OnInit } from '@angular/core';
import { GenresService } from '../services/genres-service';
import { GenreData } from '../interfaces/genre-data';
import { BookData } from '../interfaces/book-data';
import { EbooksService } from '../services/ebooks-service';
import { BookCopiesService } from '../services/book-copies-service';
import { BookPanel } from '../book-panel/book-panel';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-browse',
  imports: [BookPanel, RouterLink],
  templateUrl: './browse.html',
  styleUrl: './browse.css'
})
export class Browse implements OnInit {
  genreList: GenreData[] = [];
  booksList: BookData[] = [];
  selectedGenre: string = "All Books";

  constructor(private genresService: GenresService,
    private ebooksService: EbooksService,
    private bookcopiesService: BookCopiesService) { }

  ngOnInit(): void {
    this.genresService.getAllGenres().subscribe((data) => {
      this.genreList = data;
    });
    this.filterBooks("");
  }

  filterBooks(text: string) {
    console.log(text);
    if(!text){
      this.booksList = [];
      this.ebooksService.getAllEbooks().subscribe((data)=>{
        this.booksList.push(...data);
      }
      )

      this.bookcopiesService.getAllBooks().subscribe((data)=>{
        this.booksList.push(...data);
      }
      )
    } 
    else{
      this.selectedGenre = text;
      this.booksList = [];
      this.ebooksService.getBookByGenres(text).subscribe((data)=>{
        this.booksList.push(...data);
      })

      this.bookcopiesService.getBookByGenres(text).subscribe((data)=>{
        this.booksList.push(...data);
      })
    }

  }
}
