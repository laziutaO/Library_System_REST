import { Component, Input, OnChanges, OnInit, computed } from '@angular/core';
import { LibraryData } from '../interfaces/library-data';
import { RouterLink } from '@angular/router';
import { ScheduleData } from '../interfaces/schedule-data';

@Component({
  selector: 'app-library-panel',
  imports: [RouterLink],
  templateUrl: './library-panel.html',
  styleUrl: './library-panel.css'
})
export class LibraryPanel implements OnChanges {
  @Input() libraryPanel!: LibraryData;
  daysOfWeek = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];
  todaysDay = new Date().getDay();
  
  todaySchedule?: ScheduleData;

  ngOnChanges(): void {
      console.log(this.daysOfWeek[this.todaysDay])
      if (this.libraryPanel?.schedule) {
      this.todaySchedule = this.libraryPanel.schedule.find(
        sc => sc.dayOfWeek === this.daysOfWeek[this.todaysDay]
      );
  }
  }
}
