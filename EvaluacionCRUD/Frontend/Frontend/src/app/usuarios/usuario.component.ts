import { Component, OnInit, OnDestroy } from '@angular/core';
import { UsuarioService } from './usuario.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuario.component.html',
})
export class UsuariosComponent implements OnInit, OnDestroy {
  listaUsuarios: any[] = [];
  errorMessage: string = '';
  subscription!: Subscription;
  
  constructor(private usuarioService: UsuarioService) { }

  ngOnInit() {
    this.subscription = this.usuarioService.getUsuarios().subscribe(
      (data: any) => {
        this.listaUsuarios = data;
      },
      (error) => {
        this.errorMessage = 'Error al obtener datos: ' + error;
      }
    );
  }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
}