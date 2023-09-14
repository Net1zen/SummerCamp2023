import { Component } from '@angular/core';
import { IUsuarioAlta } from './usuarioAlta';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RegistroService } from './usuarioRegistro.service';

@Component({
  selector: 'app-alta',
  templateUrl: './usuarioRegistro.component.html',
})

export class RegistroComponent{
  persona: any = {}; 
  resultAlta: string = "";

  //Para Rellenar
  nombre: string = "";
  apellido: string = "";
  fechaNacimiento: string = "";
  telefono: string = "";
  miFormulario: FormGroup;
  sub!: Subscription;

  constructor(private registroService: RegistroService, public fb: FormBuilder) {
    this.miFormulario = this.fb.group({
      nombre: ['', [Validators.required,Validators.maxLength(50)]],
      apellido: ['', [Validators.required,Validators.maxLength(50)]],
      telefono: ['', [Validators.required,Validators.maxLength(25)]],
      fechaNacimiento: ['', [Validators.required,Validators.max(new Date(new Date().getFullYear() - 16).getTime())]],
    });
  }

  rellenarRegistro(miFormulario : FormGroup): void {
    const altaDTO: IUsuarioAlta = {
      nombre: miFormulario.value.nombre,
      fechaNacimiento: miFormulario.value.fechaNacimiento,
      telefono: miFormulario.value.telefono
    };
    this.postAlta(altaDTO);
    console.log(altaDTO);
  }
  
 // Realiza el POST enviando el registro rellenado
 postAlta(altaDTO: IUsuarioAlta): void {
  this.registroService.postRegistro(altaDTO).subscribe({
    next: (alta) => {
      this.resultAlta = alta;
      console.log(alta);
    },
  });
}
}