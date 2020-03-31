import { Component, OnInit, Input } from '@angular/core';
import { UserEntity } from '../models/user.entity';
import { UsuariosService } from './services/usuarios.service';
import { Router } from '@angular/router';
import { AlertController, ModalController, NavParams } from '@ionic/angular';
import { ModalPage } from '../modal/modal.page';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ModalUsersPage } from '../modal-users/modal-users.page';
import {DynamicDialogRef, DynamicDialogConfig } from 'primeng/dynamicdialog';

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.page.html',
  styleUrls: ['./usuarios.page.scss'],
})
export class UsuariosPage implements OnInit {

  cols: any[];
  
  usersArray = []
  usersInfo = {}
  usuario:UserEntity;
  selectedUser: UserEntity;

  constructor(
    private router:Router,
    private usuariosService:UsuariosService,
    private http: HttpClient,
    private modalController: ModalController) {
      this.reload();
    }


  ngOnInit() {
    this.usuario = new UserEntity();
    this.reload();
   

    this.cols = [
      { field: 'id', header: 'Id' },
      { field: 'nombreUsuario', header: 'Nombre Usuario' },
      { field: 'contrasena', header: 'Contraseña' },
      { field: 'email', header: 'Email' },
      { field: 'activo', header: 'Inactivo/Activo' },
      { field: 'img', header: 'Img' }
  ];
  }

  display: boolean = false;

    showDialog(user) {
      this.getInfo(user.id);      
      this.display = true;
    }

    showModalUser(usuario){      
      //this.getInfo(usuario.id)
      this.presentModal2(usuario);
    }

    async presentModal2(usuario) {      
      console.log(usuario)
      const modal2 = await this.modalController.create({
       component: ModalUsersPage,
       componentProps: {
         'usuario': usuario,
       }
     
     });
     return await modal2.present();
   }

    guardar(){
      console.log(this.usuario);
      this.usuariosService.updateUsuario(this.usuario);
      
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

  getInfo(id){
    this.usuariosService.getInfoUsers(id).subscribe(
      (val) => {
          console.log("POST call successful value returned in body");
          console.log(val);
          this.usersInfo = val;
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
