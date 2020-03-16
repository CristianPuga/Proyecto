import { Component, OnInit, ViewChild, TemplateRef, ChangeDetectorRef } from '@angular/core';
import { PersonasService } from './services/personas.service';
import { AlertController, ModalController } from '@ionic/angular';
import { Router } from '@angular/router';
import { PersonasEntity } from '../models/personas.entity';
import { ModalPage } from '../modal/modal.page';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { DatatableComponent } from '@swimlane/ngx-datatable';
import { UserEntity } from '../models/user.entity';

@Component({
  selector: 'app-personas',
  templateUrl: './personas.page.html',
  styleUrls: ['./personas.page.scss']
})

export class PersonasPage implements OnInit {


  constructor(public alertController: AlertController,
    private router:Router, private personasService: PersonasService,
    private modalController: ModalController,  private http:HttpClient,
    private cdRef: ChangeDetectorRef) { 
    }

    
    personasArray = [];
    personas:PersonasEntity;
    usersArray = []
    users:UserEntity;

    ngOnInit() {
      this.personas = new PersonasEntity();
      this.reload();
    }

    async mostarModal(persona) {
     const modal = await this.modalController.create({
      component: ModalPage,
      componentProps: {
        'persona': persona,
      }
    
    });
    return await modal.present();
  }

  async mostrar(persona){
    const alert = await this.alertController.create({
      header: persona.nombre,
      message: `¿Que deseas hacer con ${persona.nombre} ${persona.apellido}?`,
      buttons: [
        {text: 'Cancel'},
        {
          text: 'Delete',
          handler: () => {
            console.log('Confirm Delete');
            this.personasService.deletePersona(persona);
            this.reload()
          }
        },
        {
          text: 'Update',
          handler: ()=>{
            this.mostarModal(persona);
          }
        }
      ]
    });
    await alert.present();
  }


  reload(){
    this.personasService.getUsuarios().subscribe(
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

      this.personasService.getPersonas().subscribe(
        (val) => {
            console.log("POST call successful value returned in body");
            console.log(val);
            this.personasArray = val;
        },
        response => {
            console.log("POST call in error", response);
        },
        () => {
            console.log("The POST observable is now completed.");
        });
  }


  savePersona(){
    console.log(this.personas);

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
      })
    };

    try {

      this.http.post('http://localhost:5000/personas', this.personas, httpOptions)
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
                      return this.reload();
                    }
                  }
                ]
              });
          
              await alert.present();
              
          });

      console.log("post done");
      
    } catch (error) {
      
    }
    
    
  }

  modificar(usuario){
    console.log("Usuario es " +usuario.id);
    usuario.activo= !usuario.activo;
    // guardar el objeto para actualizar
    console.log(usuario.activo);
    
    this.personasService.updateActivo(usuario).subscribe(
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
          //window.location.reload();
      }); 
    this.personasService.getUsuarios();

    console.log("Usuario actualizado");
    console.log(this.usersArray);
  }

}
