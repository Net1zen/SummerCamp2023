import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { ConversorComponent } from './conversor/conversor.component';
import { WelcomeComponent } from './home/welcome.component';
import { MonedaListComponent } from './monedas/moneda-list.component';
import { ProductListComponent } from './products/product-list.component';
import { HttpClientModule, HttpHeaders } from '@angular/common/http';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    AppComponent,
    WelcomeComponent,  // Inyeccion de Dependencias del Program.cs
    ProductListComponent,
    MonedaListComponent,
    ConversorComponent,
  ],
  imports: [
    BrowserModule, FormsModule, HttpClientModule, RouterModule.forRoot([
      { path: 'monedas', component: MonedaListComponent },
      {path: 'conversor', component: ConversorComponent},
      {
        path: ''
        , redirectTo: 'conversor', pathMatch: 'full'
      },
      {
        path: '**'
        , redirectTo: 'conversor', pathMatch: 'full'
      }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
