import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AlertController } from '@ionic/angular';
//import { Persona } from 'src/app/models/persona';
import { PersonasEntity } from '../../models/personas.entity';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class PersonasService {

  constructor(private http:HttpClient, private alertController: AlertController, private router:Router) {
    this.persona = new PersonasEntity();
   }
  persona = {};

  getPersonas(): Observable<any>{
    return this.http.get('http://localhost:5000/personas');
  }

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
                  
              });
  }

  updatePersona(persona){ 
   // console.log(persona.id);
   // console.log(persona);
    //let persona2 = JSON.stringify(form.value)
    //console.log(persona2);
    this.persona = persona;
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
      })
    };

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



