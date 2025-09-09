import { Component, Input } from '@angular/core';
import { BookData } from '../interfaces/book-data';
@Component({
  selector: 'app-book-panel',
  imports: [],
  templateUrl: './book-panel.html',
  styleUrl: './book-panel.css'
})
export class BookPanel {
  @Input() bookPanel!: BookData;
}
