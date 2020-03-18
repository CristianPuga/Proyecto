import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AlertController } from '@ionic/angular';
//import { Persona } from 'src/app/models/persona';
import { PersonasEntity } from '../../models/personas.entity';
import { Router } from '@angular/router';
import { tokenName } from '@angular/compiler';

@Injectable({
  providedIn: 'root'
})
export class PersonasService {

  constructor(private http:HttpClient, 
    private alertController: AlertController, 
    private router:Router) 
  {
    this.persona = new PersonasEntity();
  }
  persona = {};

  //Obtener a las personas que hay en una base de datos
  getPersonas(): Observable<any>{
    return this.http.get('http://localhost:5000/personas');
  }

  //Borrar a una persona de la base de datos por ID
  deletePersona(persona){
    this.http.delete('http://localhost:5000/personas/' + persona.id).subscribe(
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


  savePersona(persona){
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };
    this.http.post('http://localhost:5000/personas', persona, httpOptions)
      .subscribe(
        (val) => {
          console.log(val);
          console.log("POST call successful value returned in body");
        },
        response => {
          console.log("POST call in error", response);
        },
        async () => {
          console.log("The POST observable is now completed.");
          const alert = await this.alertController.create({
            header: 'Exito',
            message: 'La persona ha sido guardada con exito',
            buttons: [
              {
                text: 'Okay',
                handler: () => {
                  console.log('Confirm Okay');
                  this.router.navigate(["/personas"]);
                  window.location.reload(true);
                }
              }
            ]
          });
        await alert.present();
      });
  }

  //Modificar datos de una persona de la base de datos
  updatePersona(persona){ 
    
    this.persona = persona;
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
    }

    this.http.put('http://localhost:5000/personas/' + persona.id,this.persona, httpOptions).subscribe(
      (val) => {
          console.log("PUT call successful value returned in body");
          console.log(val);
      },
      response => {
          console.log("PUT call in error", response);
          console.log(this.persona)
      },
      () => {
          console.log("The PUT observable is now completed.");
          this.router.navigate(['/personas'])
          window.location.reload();
      });
  }
}



