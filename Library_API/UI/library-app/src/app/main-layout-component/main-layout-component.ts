import { Component, effect, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { RouterLink, Router } from '@angular/router';
import { FilterService } from '../services/filter-service';

@Component({
  selector: 'app-main-layout-component',
  imports: [RouterOutlet, RouterLink],
  templateUrl: './main-layout-component.html',
  styleUrl: './main-layout-component.css'
})
export class MainLayoutComponent {
  protected readonly title = signal('library-app');

  constructor(private router: Router, public filterService: FilterService){
    effect(()=>{
      if(this.filterService.filterText()){
        router.navigate(['/browse']);
      }
});
  }
}
