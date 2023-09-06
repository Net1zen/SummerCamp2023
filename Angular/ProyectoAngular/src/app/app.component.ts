import { Component } from '@angular/core';

@Component({
  selector: 'pm-root',
  // templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],

  template: `
    <!--
    <h1>{{saludoHijo}}</h1>
    <pm-welcome [mensaje] = 'saludo' (saludar)='onSaludar($event)'></pm-welcome>
    -->
    <nav class="navbar navbar-expand navbar-light bg-light">
      <a class="navbar-brand">3enRayaCode</a>
      <ul class="nav nav-pills">
        <li><a routerlink="/welcome" class="nav-link" ng-reflect-router-link="/conversor" href="/conversor">Home</a></li>
        <li><a routerlink="/products" class="nav-link" ng-reflect-router-link="/monedas" href="/monedas">Product List</a></li>
      </ul>
    </nav>
    <!-- <ul class='nav navbar-nav'>
      <li><a [routerLink]="['/conversor']">Conversor</a></li>
      <li><a [routerLink]="['/monedas']">Monedas List</a></li>
    </ul> -->
<router-outlet></router-outlet>
    <!-- <pm-conversor></pm-conversor> -->
    <!-- <pm-monedas></pm-monedas> -->
  `
})
export class AppComponent {
  pageTitle = 'ProyectoAngular';
  codigoMoneda = "EUR";
  saludo = "hola mundo";
  saludoHijo = "No hay saludo";

  onSaludar(saludoDesdeHijo: string) {
    this.saludoHijo = saludoDesdeHijo;
  }
}
