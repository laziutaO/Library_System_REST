import { Component, Input, OnInit } from '@angular/core';
import { LibraryData } from '../interfaces/library-data';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-library-panel',
  imports: [RouterLink],
  templateUrl: './library-panel.html',
  styleUrl: './library-panel.css'
})
export class LibraryPanel implements OnInit {
  @Input() libraryPanel!: LibraryData;

  ngOnInit(): void {
      
  }
}
