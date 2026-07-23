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
import { EbookRequest } from '../../interfaces/ebook-create-request';
import { BookCopyRequest } from '../../interfaces/book-copy-create-request';
import { LibraryData } from '../../interfaces/library-data';
import { LibrariesService } from '../../services/libraries-service';
import { ActivatedRoute } from '@angular/router';
import { BooksFacadeService } from '../../services/books-facade-service';
import { BookData } from '../../interfaces/book-data';

@Component({
  selector: 'app-edit-book-form',
  imports: [MatChipsModule, MatFormFieldModule,
    MatButtonModule, MatIconModule,
    ReactiveFormsModule, MatAutocompleteModule],
  templateUrl: './edit-book-form.html',
  styleUrl: './edit-book-form.css',
})
export class EditBookForm {
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

  type: "ebook" | "copy";
  bookId: string = '';
  bookData!: BookData;
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

  editBookForm = this.fb.nonNullable.group({
    title: ['', Validators.required],
    isbn: ['', Validators.required],
    publisher: ['', Validators.required],
    year: [0, Validators.required],
    pagesCount: [0, Validators.required],
    description: ['', Validators.required],
    coverImageUrl: ['', Validators.required],
    fileUrl: ['', Validators.nullValidator],
    accessType: [this.bookData?.bookAccessType, Validators.required],
    status: [this.bookData?.status, Validators.required]
  });

  constructor(private route: ActivatedRoute,
    private booksFacade: BooksFacadeService) {
    this.type = this.route.snapshot.queryParamMap.get('type') as "ebook" | "copy";
    this.bookId = this.route.snapshot.paramMap.get('id')!;
  }
  ngOnInit() {
    this.booksFacade.getBookById(this.bookId, this.type).subscribe(book => {
      this.bookData = book;
      this.editBookForm.patchValue({
        title: book.title,
        isbn: book.isbn,
        publisher: book.publisher,
        year: book.year,
        pagesCount: book.pagesCount,
        description: book.description,
        coverImageUrl: book.coverImageUrl,
        fileUrl: book.fileUrl,
        accessType: book.bookAccessType,
        status: book.status
      });
      this.searchedAuthors = book.authorNames || [];
      this.searchedGenres = book.genreNames || [];
      this.searchedLibraries = book.libraryNames || [];
    });


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
    const copyRequest: BookCopyRequest = {
      title: this.editBookForm.value.title!,
      isbn: this.editBookForm.value.isbn!,
      publisher: this.editBookForm.value.publisher!,
      year: this.editBookForm.value.year!,
      pagesCount: this.editBookForm.value.pagesCount!,
      description: this.editBookForm.value.description!,
      coverImageUrl: this.editBookForm.value.coverImageUrl!,
      authorNames: this.searchedAuthors,
      genreNames: this.searchedGenres,
      status: this.editBookForm.value.status!,
      libraryNames: this.searchedLibraries
    };

    const ebookRequest: EbookRequest = {
      title: this.editBookForm.value.title!,
      isbn: this.editBookForm.value.isbn!,
      publisher: this.editBookForm.value.publisher!,
      year: this.editBookForm.value.year!,
      pagesCount: this.editBookForm.value.pagesCount!,
      description: this.editBookForm.value.description!,
      coverImageUrl: this.editBookForm.value.coverImageUrl!,
      fileUrl: this.editBookForm.value.fileUrl!,
      bookAccessType: this.editBookForm.value.accessType!,
      authorNames: this.searchedAuthors,
      genreNames: this.searchedGenres
    };
    if (this.type === 'copy') {
      this.bookCopiesService.updateBook(this.bookId, copyRequest).subscribe();
    }
    else {
      this.ebooksService.updateBook(this.bookId, ebookRequest).subscribe();
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
