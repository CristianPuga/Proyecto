import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from './services/login.service';
import { UserEntity } from '../models/user.entity';

@Component({
  selector: 'app-login',
  templateUrl: './login.page.html',
  styleUrls: ['./login.page.scss'],
})
export class LoginPage implements OnInit {

  users:UserEntity[] = [];

  constructor(private router:Router, private loginService:LoginService) { }

  ngOnInit() {
    this.getDatos();
  }
  
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
  }

  login(form){
    var router2 = this.router;
    console.log(form.value);
    this.users.map(function(item){
      console.log(item.nombreUsuario);
      if(item.nombreUsuario==form.value.nombre_usuario&&item.contrasena==form.value.contrasena){
        console.log("Usuario logueado correctamente");
        router2.navigate(['/personas']);
      }else{
        console.log("Usuario o contraseña incorrectos, intentelo de nuevo");
      }
    });
  }

}
