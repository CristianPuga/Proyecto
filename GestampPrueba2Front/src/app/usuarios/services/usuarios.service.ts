import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UsuariosService {

  constructor(private http:HttpClient) { }



  getUsuarios(): Observable<any>{
    return this.http.get('http://localhost:5000/usuarios');
  }

  updateActivo(user){
    console.log("Activando...");
    console.log(user);

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
      })
    };
    return this.http.put('http://localhost:5000/usuarios/' + user.id, user, httpOptions);
  }
}
