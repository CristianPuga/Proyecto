import { Component, OnInit } from '@angular/core';
import { RegisterService } from './services/register.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.page.html',
  styleUrls: ['./register.page.scss'],
})
export class RegisterPage implements OnInit {

  constructor(private registerService:RegisterService) { }

  ngOnInit() {
  }

  register(form){
    console.log(form.value);
    this.registerService.guardarUsuario(form);
    
  }
}
