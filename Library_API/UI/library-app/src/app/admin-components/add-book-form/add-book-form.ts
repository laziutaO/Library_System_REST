import { Component, inject, OnInit, signal, computed, effect } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatChipInputEvent, MatChipsModule } from '@angular/material/chips';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { FormBuilder, FormControl, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthorSerivce } from '../../services/author-serivce';
import { GenresService } from '../../services/genres-service'
import { AuthorData } from '../../interfaces/author-data';
import { GenreData } from '../../interfaces/genre-data'
import { FilterService } from '../../services/filter-service';
import { MatAutocompleteModule, MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { EbooksService } from '../../services/ebooks-service';
import { BookCopiesService } from '../../services/book-copies-service';
import { EbookCreateRequest} from '../../interfaces/ebook-create-request';
import {BookCopyCreateRequest} from '../../interfaces/book-copy-create-request';
import {LibraryData} from '../../interfaces/library-data';
import {LibrariesService} from '../../services/libraries-service';

@Component({
  selector: 'app-add-book-form',
  imports: [MatChipsModule, MatFormFieldModule,
    MatButtonModule, MatIconModule,
    ReactiveFormsModule, MatAutocompleteModule],
  templateUrl: './add-book-form.html',
  styleUrl: './add-book-form.css',
})
export class AddBookForm {
  fb = inject(FormBuilder);
  authorService = inject(AuthorSerivce);
  libraryService = inject(LibrariesService);
  filterService = inject(FilterService);
  genreService = inject(GenresService);
  ebooksService = inject(EbooksService);
  bookCopiesService = inject(BookCopiesService);

  allAuthors: AuthorData[] = [];
  allGenres: GenreData[] = [];
  allLibraries: LibraryData[] = [];

  category = new FormControl('Ebook');
  author = new FormControl('');
  genres = new FormControl('');
  library = new FormControl('');

  searchedAuthors: string[] = [];
  searchedGenres: string[] = [];
  searchedLibraries: string[] = [];

  filteredAuthorsList = computed(() =>
    this.allAuthors.filter(author => author.name.toLowerCase()
      .includes(this.filterService
        .debouncedFilterAuthors().toLowerCase()) &&
      !this.searchedAuthors.includes(author.name)));

  filteredGenresList = computed(() =>
    this.allGenres.filter(genre => genre.name.toLowerCase()
      .includes(this.filterService
        .debouncedFilterGenres().toLowerCase()) &&
      !this.searchedGenres.includes(genre.name)));

  filteredLibrariesList = computed(() =>
    this.allLibraries.filter(library => library.name.toLowerCase()
      .includes(this.filterService
        .debouncedFilterLibrary().toLowerCase()) &&
      !this.searchedLibraries.includes(library.name)));

  addBookForm = this.fb.nonNullable.group({
    title: ['', Validators.required],
    isbn: ['', Validators.required],
    publisher: ['', Validators.required],
    year: [0, Validators.required],
    pagesCount: [0, Validators.required],
    description: ['', Validators.required],
    coverImageUrl: ['', Validators.required],
    fileUrl: ['', Validators.nullValidator],
    accessType: ['Free', Validators.required],
    status: ['Available', Validators.required]
  });

  private AddBookForm() {
  }
  ngOnInit() {
    this.authorService.getAllAuthors().subscribe((authors) => {
      this.allAuthors = authors;
    });

    this.genreService.getAllGenres().subscribe((genres) => {
      this.allGenres = genres;
    });

    this.libraryService.getAllLibraries().subscribe((libraries) => {
      this.allLibraries = libraries;
    });
  }
  onSubmit() {
    const copyRequest: BookCopyCreateRequest = {
      title: this.addBookForm.value.title!,
      isbn: this.addBookForm.value.isbn!,
      publisher: this.addBookForm.value.publisher!,
      year: this.addBookForm.value.year!,
      pagesCount: this.addBookForm.value.pagesCount!,
      description: this.addBookForm.value.description!,
      coverImageUrl: this.addBookForm.value.coverImageUrl!,
      authorNames: this.searchedAuthors,
      genreNames: this.searchedGenres,
      status: this.addBookForm.value.status!,
      libraryNames: this.searchedLibraries
    };

      const ebookRequest: EbookCreateRequest = {
      title: this.addBookForm.value.title!,
      isbn: this.addBookForm.value.isbn!,
      publisher: this.addBookForm.value.publisher!,
      year: this.addBookForm.value.year!,
      pagesCount: this.addBookForm.value.pagesCount!,
      description: this.addBookForm.value.description!,
      coverImageUrl: this.addBookForm.value.coverImageUrl!,
      fileUrl: this.addBookForm.value.fileUrl!,
      bookAccessType: this.addBookForm.value.accessType!,
      authorNames: this.searchedAuthors,
      genreNames: this.searchedGenres
    };
    if (this.category.value === 'Copy') {
      this.bookCopiesService.createBook(copyRequest).subscribe();
    }
    else {
      this.ebooksService.createBook(ebookRequest).subscribe();
    }
  }

  addAuthor(event: MatChipInputEvent): void {
    const value = (event.value || '').trim();
    if (value) {
      this.searchedAuthors.push(value);
    }
    event.chipInput.clear();
    this.author.setValue('');
  }
  removeAuthor(author: string) {
    this.searchedAuthors = this.searchedAuthors.filter(a => a !== author);
  }

  selectAuthor(event: MatAutocompleteSelectedEvent) {
    this.searchedAuthors.push(event.option.value);
    this.author.setValue('');
  }

  
  addGenre(event: MatChipInputEvent): void {
    const value = (event.value || '').trim();
    if (value) {
      this.searchedGenres.push(value);
    }
    event.chipInput.clear();
    this.genres.setValue('');
  }
  removeGenre(genre: string) {
    this.searchedGenres = this.searchedGenres.filter(g => g !== genre);
  }

  selectGenre(event: MatAutocompleteSelectedEvent) {
    this.searchedGenres.push(event.option.value);
    this.genres.setValue('');
  }
    
  addLibrary(event: MatChipInputEvent): void {
    const value = (event.value || '').trim();
    if (value) {
      this.searchedLibraries.push(value);
    }
    event.chipInput.clear();
    this.library.setValue('');
  }
  removeLibrary(library: string) {
    this.searchedLibraries = this.searchedLibraries.filter(l => l !== library);
  }

  selectLibrary(event: MatAutocompleteSelectedEvent) {
    this.searchedLibraries.push(event.option.value);
    this.library.setValue('');
  }

}
