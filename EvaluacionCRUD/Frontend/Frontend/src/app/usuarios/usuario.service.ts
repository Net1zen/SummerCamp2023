import { Injectable } from '@angular/core'
import { HttpClient } from '@angular/common/http';
import { IUsuario } from './usuario';
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})

export class UsuarioService {
  private usuariosUrl = 'https://localhost:7105/api/Personas';

  constructor(private http: HttpClient) { }

  getUsuarios(): Observable<IUsuario[]> {
    return this.http.get<IUsuario[]>(this.usuariosUrl);
  }
}