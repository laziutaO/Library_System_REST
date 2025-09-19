import { Component, effect, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Home } from "./home/home";
import { RouterLink, Router } from '@angular/router';
import { FilterService } from './services/filter-service';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Home, RouterLink],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('library-app');

  constructor(private router: Router, public filterService: FilterService){
    effect(()=>{
      if(this.filterService.filterText()){
        router.navigate(['/browse']);
      }
});
  }
}
