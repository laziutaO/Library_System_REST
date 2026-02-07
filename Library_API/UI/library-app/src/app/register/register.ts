import { Component, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { AuthService } from '../services/auth-service';
import { Router } from '@angular/router';
import { UserAuthData } from '../interfaces/user-auth-data';

@Component({
  selector: 'app-register',
  imports: [ReactiveFormsModule],
  templateUrl: './register.html',
  styleUrl: './register.css'
})
export class Register {
  fb = inject(FormBuilder)
  http = inject(HttpClient)
  authService = inject(AuthService)
  router = inject(Router)
  apiUrl = 'https://localhost:7103/api/Authorize/Register';

  form = this.fb.nonNullable.group({
    userName: ['', Validators.required],
    email: ['', Validators.required],
    firstName: ['', Validators.nullValidator],
    lastName: ['', Validators.nullValidator],
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
