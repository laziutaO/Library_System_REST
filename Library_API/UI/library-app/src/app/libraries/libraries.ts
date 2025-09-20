import { Component, inject, OnInit } from '@angular/core';
import { LibraryData } from '../interfaces/library-data';
import { LibraryPanel } from '../library-panel/library-panel';
import { LibrariesService } from '../services/libraries-service';

@Component({
  selector: 'app-libraries',
  imports: [LibraryPanel],
  templateUrl: './libraries.html',
  styleUrl: './libraries.css'
})
export class Libraries implements OnInit {
  libraryList: LibraryData[] = [];
  libraryService: LibrariesService = inject(LibrariesService);

  ngOnInit(): void {
    this.libraryService.getAllLibraries().subscribe((data)=>{
      this.libraryList = data;
    })
  }
}
