import { Component } from '@angular/core';
import { RouterLink, Router } from '@angular/router';
import {RouterOutlet} from '@angular/router';

@Component({
  selector: 'app-admin-layout-component',
  imports: [RouterLink, RouterOutlet],
  templateUrl: './admin-layout-component.html',
  styleUrl: './admin-layout-component.css',
})
export class AdminLayoutComponent {

}
