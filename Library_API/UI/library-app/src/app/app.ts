import { Component, effect, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Home } from "./home/home";
import { RouterLink, Router } from '@angular/router';


@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Home, RouterLink],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('library-app');
  filterText= signal('');

  constructor(private router: Router){
    effect(()=> {
      const searchText: string = this.filterText();
      if(searchText.trim()){
        router.navigate(['/browse'], {queryParams: {q :searchText}})
      }
    })
  }
}
