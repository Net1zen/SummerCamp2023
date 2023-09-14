import { IUsuarioAlta } from './usuarioAlta';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class RegistroService {
    altaUrl: string;
  private http: HttpClient;

  constructor(httpClient: HttpClient) {
    this.altaUrl = 'https://localhost:7105/api/Personas';
    this.http = httpClient;
  }

  //Realiza el POST de registro
  postRegistro(alta: IUsuarioAlta): Observable<any> {
    console.log(alta);
    return this.http.post(this.altaUrl, alta);
    
  }
}