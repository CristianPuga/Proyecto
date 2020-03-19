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

  constructor(private router:Router,private http:HttpClient, private loginService:LoginService) {     var a = localStorage.getItem('token')
}
  ngOnInit() {
    if (localStorage.getItem('token')){
      console.log("Usuario logeado");
      this.router.navigate(['/usuarios'])
      return true;
    }else{
      console.log("Usuario no logueado");     
      return false;
    }
  }

  login(form){
    this.loginService.login(form);
  }

  /*ngDoCheck(){
    if (localStorage.getItem('token')){
      console.log("Usuario logeado");
      //this.router.navigate(['/usuarios'])
      return true;
    }else{
      console.log("Usuario no logueado");     
      return false;
    }
  }*/
}
