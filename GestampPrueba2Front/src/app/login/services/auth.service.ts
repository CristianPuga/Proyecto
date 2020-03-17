import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  uri = 'http://localhost:5000/api';
  token;
 

  constructor(private http:HttpClient, private router:Router) { }

  login(nombreUsuario: string, contrasena: string){
    this.http.post(this.uri + '/token', {nombreUsuario: nombreUsuario,contrasena:contrasena})
    .subscribe((resp: any) => {
     
      this.router.navigate(['profile']);
      localStorage.setItem('auth_token', resp.token);
      
    })
  };  
}
