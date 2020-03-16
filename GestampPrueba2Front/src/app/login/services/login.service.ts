import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

usersDB=[];

  constructor(private http:HttpClient) { }


  consultarUsuarios(){
    var usuario = this.getUsers();
    console.log(usuario)
    usuario.subscribe(result =>{
      if(result.code!=200){
        console.log(result);
        this.usersDB = result;
        console.log(this.usersDB);
                
      }else{
        console.log("Error");
      }
    },
    error=>{
      console.log(<any>error);
      
    })
  }

  getUsers():Observable<any>{
   return this.http.get('http://localhost:5000/usuarios');
  }
}
