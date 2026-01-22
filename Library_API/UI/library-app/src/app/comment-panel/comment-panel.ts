import { Component, Input, inject } from '@angular/core';
import { ReviewData } from '../interfaces/review-data';

@Component({
  selector: 'app-comment-panel',
  imports: [],
  templateUrl: './comment-panel.html',
  styleUrl: './comment-panel.css',
})
export class CommentPanel {
  @Input() commentPanel!: ReviewData;
}
