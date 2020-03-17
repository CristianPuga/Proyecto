import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UsuariosService {

  constructor(private http:HttpClient) { }



  getUsuarios(): Observable<any>{
    console.log("Estoy en getUsuarios");
    let token = localStorage.getItem("token");
    return this.http.get('http://localhost:5000/usuarios', { headers: new HttpHeaders({ 'Authorization': 'Bearer ' + token }) });
  }

  updateActivo(user){
    console.log("Activando...");
    console.log(user);
    let token = localStorage.getItem("token");    
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
        'Authorization': 'Bearer' + token
      })
    };
    return this.http.put('http://localhost:5000/usuarios/' + user.id, user, httpOptions);
  }
}
