import { Component, OnInit, signal, computed, effect } from '@angular/core';
import { LibrariesService } from '../../services/libraries-service';
import { BookData } from '../../interfaces/book-data';
import { Router, RouterLink } from '@angular/router';
import { FilterService } from '../../services/filter-service';
import { LibraryData } from '../../interfaces/library-data';

@Component({
  selector: 'app-libraries-manage',
  imports: [RouterLink],
  templateUrl: './libraries-manage.html',
  styleUrl: './libraries-manage.css',
})
export class LibrariesManage {
 librariesList= signal<LibraryData[]>([]);
  public filteredLibrariesList = computed(()=>this.librariesList()
  .filter(library => library.name.toLowerCase()
  .includes(this.filterService.debouncedFilterLibrary().toLowerCase())));

  constructor(private libsService: LibrariesService,
    public filterService: FilterService) {
  }
  ngOnInit(): void {
    this.libsService.getAllLibraries().subscribe((data) => {
      this.librariesList.set([...this.librariesList(), ...data]);
    })
  }

  deleteLibrary(libraryId: string): void {
    this.libsService.deleteLibrary(libraryId).subscribe(() => {
      this.librariesList.set(this.librariesList().filter(library => library.id !== libraryId));
    });
  }
}

    
