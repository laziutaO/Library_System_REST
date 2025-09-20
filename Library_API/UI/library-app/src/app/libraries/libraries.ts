import { Component, inject, OnInit, computed, signal } from '@angular/core';
import { LibraryData } from '../interfaces/library-data';
import { LibraryPanel } from '../library-panel/library-panel';
import { LibrariesService } from '../services/libraries-service';
import { FilterService } from '../services/filter-service';

@Component({
  selector: 'app-libraries',
  imports: [LibraryPanel],
  templateUrl: './libraries.html',
  styleUrl: './libraries.css'
})
export class Libraries implements OnInit {
  libraryList = signal<LibraryData[]>([]);
  libraryService: LibrariesService = inject(LibrariesService);
  filterService: FilterService = inject(FilterService);
  searchedLibraries = computed(()=> this.libraryList()
  .filter(lib => lib.name.toLowerCase()
  .includes(this.filterService.debouncedFilterLibrary().toLowerCase())));


  ngOnInit(): void {
    this.libraryService.getAllLibraries().subscribe((data)=>{
      this.libraryList.set(data);
    })
  }
}
