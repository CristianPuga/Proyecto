import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AlertController } from '@ionic/angular';

@Injectable({
  providedIn: 'root'
})
export class UsuariosService {

  //private isUserLoggedIn;

  constructor(private http:HttpClient, private alertController: AlertController) { 
    //this.isUserLoggedIn = false;
  }

/*
  getUserLoggedIn(){
    if (localStorage.getItem('token')){
      this.isUserLoggedIn = true;
    }else{
      console.log("El usuario no esta logueado");
      
    }
  }*/


  getUsuarios(): Observable<any>{
    console.log("Obteniendo usuarios....");
    return this.http.get('http://localhost:5000/usuarios');
  }

  updateActivo(user){
    console.log("Activando...");
    console.log(user);
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
        
      })
    };
    return this.http.put('http://localhost:5000/usuarios/' + user.id, user, httpOptions);
  }

  deleteUsuario(usuario){
    this.http.delete('http://localhost:5000/usuarios/' + usuario.id).subscribe(
      (val) => {
        console.log("DELETE call successful value returned in body");
      },
      response => {
        console.log("DELETE call in error", response);
      },
      async () => {
        console.log("The DELETE observable is now completed.");
        const alert = await this.alertController.create({
        header: 'Exito',
        message: 'La publicación ha sido borrada con exito',
        buttons: [
        {
          text: 'Okay',
          handler: () => {
          console.log('Confirm Okay');
          window.location.reload(true);
          }
        }
        ]
        });
      await alert.present();
      }
    );
  }

}
