import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AlertController } from '@ionic/angular';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class UsuariosService {


  usuario = {};

  constructor(private http:HttpClient, private alertController: AlertController, private router:Router) {}

  getUsuarios(): Observable<any>{
    console.log("Obteniendo usuarios....");
    return this.http.get('http://localhost:5000/usuarios');
  }

  getInfoUsers(id): Observable<any>{
    console.log("Obteniendo detaller usuario");
    return this.http.get('http://localhost:5000/usuarios/' + id);
    
  }

  updateActivo(user){
    console.log("Activando...");
    console.log(user);
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
        
      })
    };
    return this.http.put('http://localhost:5000/usuarios/activo/' + user.id, user, httpOptions);
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

  updateUsuario(usuario){
    this.usuario = usuario;
    console.log(usuario.id)
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
    }

    this.http.put('http://localhost:5000/usuarios/' + usuario.id, this.usuario, httpOptions).subscribe(
      (val) => {
          console.log("PUT call successful value returned in body");
          console.log(val);
      },
      response => {
          console.log("PUT call in error", response);
          console.log(this.usuario)
      },
      () => {
          console.log("The PUT observable is now completed.");
          this.router.navigate(['/usuarios'])
          window.location.reload();
      });
  }

}
