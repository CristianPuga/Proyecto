import { Component, OnInit, Input } from '@angular/core';
import { ModalController, NavParams } from '@ionic/angular';
import { PersonasService } from '../personas/services/personas.service';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.page.html',
  styleUrls: ['./modal.page.scss'],
})
export class ModalPage implements OnInit {

  @Input() persona: {};
  personaToUpdate = {};

  constructor(private modalController: ModalController,
     private personasService:PersonasService, navParams: NavParams) { 
      console.log(navParams.get('persona'));
      this.persona = navParams.get('persona');
    
     }

  ngOnInit() {
  }

  async acciones() {
    console.log(this.persona);
    this.personasService.updatePersona(this.persona);
  }

  async closeModal() {
    const onClosedData: string = "Wrapped Up!";
    await this.modalController.dismiss(onClosedData);
  }

  /*dismiss() {
    // using the injected ModalController this page
    // can "dismiss" itself and optionally pass back data
    this.modalController.dismiss({
      'dismissed': true
    });
  }*/
}

