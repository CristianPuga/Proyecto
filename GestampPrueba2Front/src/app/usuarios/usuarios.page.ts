import { Component, OnInit } from '@angular/core';
import { UserEntity } from '../models/user.entity';
import { UsuariosService } from './services/usuarios.service';
import { Router } from '@angular/router';
import { AlertController, ModalController } from '@ionic/angular';
import { ModalPage } from '../modal/modal.page';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.page.html',
  styleUrls: ['./usuarios.page.scss'],
})
export class UsuariosPage implements OnInit {

  //isLoggedIn$: Observable<boolean>;

  constructor(
    private router:Router,
    private usuariosService:UsuariosService,
    private http: HttpClient) {}

  usersArray = []
  usuario:UserEntity;

  ngOnInit() {
    //this.isLoggedIn$ = this.authService.isLoggedIn;
    this.reload();
  }

  reload(){
       this.usuariosService.getUsuarios().subscribe(
      (val) => {
          console.log("POST call successful value returned in body");
          console.log(val);
          this.usersArray = val;
      },
      response => {
          console.log("POST call in error", response);
      },
      () => {
          console.log("The POST observable is now completed.");
      });
  }

  delete(usuario){
    this.usuariosService.deleteUsuario(usuario);
  }

  modificar(usuario){
    console.log("Usuario es " +usuario.id);
    usuario.activo=!usuario.activo;
    console.log(usuario.activo);
    
    this.usuariosService.updateActivo(usuario).subscribe(
      (val) => {
          console.log("POST call successful value returned in body");
          console.log("usuario:" +val); 
          this.reload();
      },
      response => {
          console.log("POST call in error", response);
      },
      () => {
          console.log("The POST observable is now completed.");
      }); 
    this.usuariosService.getUsuarios();

    console.log("Usuario actualizado");
    console.log(this.usersArray);
  }

  logOut() {
    //this.authService.logout();
    localStorage.removeItem('token');
    this.router.navigate(['login']);
  }

}
