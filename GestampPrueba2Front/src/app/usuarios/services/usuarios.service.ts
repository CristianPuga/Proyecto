import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UsuariosService {

  //private isUserLoggedIn;

  constructor(private http:HttpClient) { 
    //this.isUserLoggedIn = false;
  }

/*
  getUserLoggedIn(){
    if (localStorage.getItem('token')){
      this.isUserLoggedIn = true;
    }else{
      console.log("El usuario no esta logueado");
      
    }
  }*/


  getUsuarios(): Observable<any>{
    console.log("Obteniendo usuarios....");
    return this.http.get('http://localhost:5000/usuarios');
  }

  updateActivo(user){
    console.log("Activando...");
    console.log(user);
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
        
      })
    };
    return this.http.put('http://localhost:5000/usuarios/' + user.id, user, httpOptions);
  }
}
