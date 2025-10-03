import { Component, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { AuthService } from '../services/auth-service';
import { Router } from '@angular/router';
import { UserAuthData } from '../interfaces/user-auth-data';

@Component({
  selector: 'app-login',
  imports: [ReactiveFormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class Login {
  fb = inject(FormBuilder)
  http = inject(HttpClient)
  authService = inject(AuthService)
  router = inject(Router)
  apiUrl = 'https://localhost:7103/api/Authorize/SignIn';

  form = this.fb.nonNullable.group({
    email: ['', Validators.required],
    password: ['', Validators.required],
  });
  

  onSubmit(){
    this.http.post<UserAuthData>(this.apiUrl, this.form.getRawValue())
    .subscribe(responce => 
      {
        localStorage.setItem('auth', JSON.stringify(responce));
        localStorage.setItem('token', responce.token);
        this.authService.currentUser.set(responce);
        this.router.navigateByUrl('/');
      });
  }
}
