import { Component, OnInit, ViewChild, TemplateRef, ChangeDetectorRef } from '@angular/core';
import { PersonasService } from './services/personas.service';
import { AlertController, ModalController } from '@ionic/angular';
import { Router } from '@angular/router';
import { PersonasEntity } from '../models/personas.entity';
import { ModalPage } from '../modal/modal.page';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { DatatableComponent } from '@swimlane/ngx-datatable';
import { UserEntity } from '../models/user.entity';
import { tokenName } from '@angular/compiler';

@Component({
  selector: 'app-personas',
  templateUrl: './personas.page.html',
  styleUrls: ['./personas.page.scss']
})

export class PersonasPage implements OnInit {

  items:any;
  personasArray = [];
  personas:PersonasEntity;

  constructor(public alertController: AlertController,
    private router:Router, private personasService: PersonasService,
    private modalController: ModalController,  private http:HttpClient,
    private cdRef: ChangeDetectorRef) { 
      this.reload();
    }

    ngOnInit() {
      this.personas = new PersonasEntity();
      this.reload();
    }

    async presentModal(persona) {
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
        {text: 'Delete',
          handler: () => {
            console.log('Confirm Delete');
            this.personasService.deletePersona(persona);
            this.reload()
          }
        },
        {
          text: 'Update',
          handler: ()=>{
           this.presentModal(persona);
          }
        }
      ]
    });
    await alert.present();
  }

  reload(){
    this.personasService.getPersonas().subscribe(
        (val) => {
            console.log("POST call successful value returned in body");
            console.log(val);
            this.personasArray = val;
            this.items = val;            
        },
        response => {
            console.log("POST call in error", response);
        },
        () => {
            console.log("The POST observable is now completed.");
        });
  }

  //Guardar a una persona en la base de datos
  savePersona(){
    console.log(this.personas);
    try {
      this.personasService.savePersona(this.personas);
      console.log("post done");
      this.reload();
    } catch (error) {
    }  
  }

  //Poder buscar por barra de busqueda
  busqueda(event: any){

    let val = event.target.value;    
    if(val && val.trim() != ''){
      this.items = this.items.filter((item) => {
        console.log(this.items);
        return (item.nombre.toLowerCase().indexOf(val.toLowerCase()) > -1)
      })
    }
  }

  //Deslogearse y borrar el token
  logOut() {
    localStorage.removeItem('token');
    this.router.navigate(['login']);
  }
}
