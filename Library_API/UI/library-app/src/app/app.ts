import { Component, effect, signal, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { RouterLink, Router } from '@angular/router';
import { FilterService } from './services/filter-service';
import { AuthService } from './services/auth-service';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, RouterLink],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('library-app');
  authService = inject(AuthService)

  constructor(private router: Router, public filterService: FilterService) {
    const stored = localStorage.getItem('auth');
    if (stored) {
      this.authService.currentUser.set(JSON.parse(stored));
    }

      effect(() => {
        if (this.filterService.filterText()) {
          router.navigate(['/browse']);
        }
      });
    }
  }
