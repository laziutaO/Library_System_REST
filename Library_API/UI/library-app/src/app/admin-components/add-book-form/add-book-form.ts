import { Component, inject, OnInit, signal, computed, effect } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatChipInputEvent, MatChipsModule } from '@angular/material/chips';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthorSerivce } from '../../services/author-serivce';
import { AuthorData } from '../../interfaces/author-data';
import { FilterService } from '../../services/filter-service';
import { MatAutocompleteModule } from '@angular/material/autocomplete';

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
  filterService = inject(FilterService);
  allAuthors: AuthorData[] = [];
  searchedAuthors: AuthorData[] = [];
  filteredAuthorsList = computed(() => 
    this.allAuthors.filter(author => author.name.toLowerCase()
  .includes(this.filterService
    .debouncedFilterAuthors().toLowerCase())));

  addBookForm = this.fb.nonNullable.group({
    title: ['', Validators.required],
    isbn: ['', Validators.required],
    publisher: ['', Validators.required],
    publicationYear: ['', Validators.required],
    numberOfPages: ['', Validators.required],
    description: ['', Validators.required],
    coverImageUrl: ['', Validators.required],
    file: [''],
    accessType: ['', Validators.required],
    category: ['', Validators.required],
    author: ['', Validators.required]
  });

  ngOnInit() {
    this.authorService.getAllAuthors().subscribe((authors) => {
      this.allAuthors = authors;
    });

  }

  addAuthor(event: MatChipInputEvent): void {
    const value = (event.value || '').trim();
    if (value) {
      this.searchedAuthors.push(value);
    }
    event.chipInput.clear();
  }
}
