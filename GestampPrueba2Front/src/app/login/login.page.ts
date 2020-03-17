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
  }


  login(form){
    console.log(form.value);
    this.http.post(this.uri + '/token', {nombreUsuario: form.value.nombreUsuario,contrasena:form.value.contrasena})
    .subscribe((resp: any) => {
      this.router.navigate(['usuarios']);
      localStorage.setItem('token', resp.token);
      
    })
  };  
}
