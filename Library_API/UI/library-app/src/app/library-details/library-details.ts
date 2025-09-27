import { Component, OnInit } from '@angular/core';
import { LibraryData } from '../interfaces/library-data';
import { LibrariesService } from '../services/libraries-service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-library-details',
  imports: [],
  templateUrl: './library-details.html',
  styleUrl: './library-details.css'
})
export class LibraryDetails implements OnInit{
  libraryData!: LibraryData;
  libraryId: string = '';
  constructor(private libraryService: LibrariesService, private route: ActivatedRoute) {
    this.libraryId = this.route.snapshot.paramMap.get('id')!;
  }

ngOnInit(): void {
    this.libraryService.getLibraryById(this.libraryId).subscribe(data=>{
      this.libraryData = data;
    })
}
}
