import { Injectable, Input } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { UserEntity } from 'src/app/models/user.entity';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  usuario: UserEntity;

  constructor(private http:HttpClient, private router:Router) { }

  ngOnInit() {
    this.usuario = new UserEntity();
  }

  guardarUsuario(form){
    console.log(form.value);
    var router=this.router;
    let usuario = JSON.stringify(form.value);
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
      })
    };
    return this.http.post('http://localhost:5000/usuarios', usuario, httpOptions).subscribe(
      (val)=>{
        console.log(usuario);
         console.log(val);
         console.log("POST call successful value returned in body");
       },
         response => {
         console.log("POST call in error", response);
       },
       () => {
         console.log("The POST observable is now completed.");
         router.navigate(["/login"]);
       });
  }
}
