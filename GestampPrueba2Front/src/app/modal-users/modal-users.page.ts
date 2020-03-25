import { Component, OnInit, Input } from '@angular/core';
import { UsuariosService } from '../usuarios/services/usuarios.service';
import { ModalController, NavParams } from '@ionic/angular';

@Component({
  selector: 'app-modal-users',
  templateUrl: './modal-users.page.html',
  styleUrls: ['./modal-users.page.scss'],
})
export class ModalUsersPage implements OnInit {

  @Input() usuario: {};

  constructor(private modalController: ModalController,
    private usuariosService:UsuariosService, navParams: NavParams) { 
      this.usuario = navParams.get('usuario');
      console.log(navParams.get('usuario'));
    }

  ngOnInit() {
  }

  async guardarUsuario() {
    console.log(this.usuario);
    this.usuariosService.updateUsuario(this.usuario);
  }

  async closeModal() {
    const onClosedData: string = "Wrapped Up!";
    await this.modalController.dismiss(onClosedData);
  }

}
