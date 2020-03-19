import { Component, OnInit, Injectable } from '@angular/core';
import { RegisterService } from './services/register.service';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.page.html',
  styleUrls: ['./register.page.scss'],
})
export class RegisterPage implements OnInit {

  form: FormGroup;

  constructor(private registerService:RegisterService, private fb: FormBuilder) {
    this.form = this.fb.group({
      nombreUsuario: ['', [Validators.required]],
      contrasena: ['', [Validators.required, Validators.minLength(8)]],
      email: ['', [Validators.required, Validators.email]],
      img: ['']
    });
   }

  ngOnInit() {
  }

  register(form){
    console.log(form.value);
    console.log(this.form.value)
    if (this.form.valid){
    this.registerService.guardarUsuario(form); 
    }else{
      window.alert("Formulario no valido");
    }
  }
}
