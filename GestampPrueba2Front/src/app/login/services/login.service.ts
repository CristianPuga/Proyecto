import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  uri = 'http://localhost:5000/api';
  token;

  constructor(private http:HttpClient, private router: Router) {}

  login(form){
    console.log(form.value);
    this.http.post(this.uri + '/token', {nombreUsuario: form.value.nombreUsuario,contrasena:form.value.contrasena})
    .subscribe((resp: any) => {      
      this.router.navigate(['usuarios']);
      localStorage.setItem('token', resp.token);  
    })
  }; 

  isLogged(){
    if(!localStorage.getItem("token")){
      return false;
    }else{
      return true;
    }
  }
}
