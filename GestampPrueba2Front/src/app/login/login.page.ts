import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from './services/login.service';
import { UserEntity } from '../models/user.entity';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.page.html',
  styleUrls: ['./login.page.scss'],
})
export class LoginPage implements OnInit {

  users:UserEntity[] = [];
  uri = 'http://localhost:5000/api';
  token;

  constructor(private router:Router,private http:HttpClient, private loginService:LoginService) { }

  ngOnInit() {
    //this.getDatos();
  }


  login(form){
    console.log(form.value);
    
    this.http.post(this.uri + '/token', {nombreUsuario: form.value.nombreUsuario,contrasena:form.value.contrasena})
    .subscribe((resp: any) => {
      this.router.navigate(['usuarios']);
      localStorage.setItem('token', resp.token);
      
    })
  };  




  /*
  getDatos(){
    this.loginService.getUsers().subscribe(
      (val) =>{
        console.log(val);
      console.log("POST call successful value returned in body");
        this.users = val;
        console.log(this.users)
    },
    response => {
        console.log("POST call in error", response);
    },
    () => {
        console.log("The POST observable is now completed.");
  });
  }*/
/*
  login(form){
    var router2 = this.router;
    console.log(form.value);
    this.users.map(function(item){
      if(item.nombreUsuario==form.value.nombreUsuario&&item.contrasena==form.value.contrasena){
        console.log("Usuario logueado correctamente");
        router2.navigate(['/personas']);
      }else{
        console.log("Usuario o contraseña incorrectos, intentelo de nuevo");
      }
    });
  }*/

}
