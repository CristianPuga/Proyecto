import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

/*  private loggedIn = new BehaviorSubject<boolean>(false);
  get isLoggedIn() {
    return this.loggedIn.asObservable(); // {2}
  }*/

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

  /*logout() {
    this.loggedIn.next(false);
    this.router.navigate(['/login']);
  }*/
}
