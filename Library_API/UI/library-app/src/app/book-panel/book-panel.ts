import { Component, Input, inject } from '@angular/core';
import { BookData } from '../interfaces/book-data';
import { RouterLink } from '@angular/router';


@Component({
  selector: 'app-book-panel',
  imports: [RouterLink],
  templateUrl: './book-panel.html',
  styleUrl: './book-panel.css'
})
export class BookPanel {
  @Input() bookPanel!: BookData;
}
