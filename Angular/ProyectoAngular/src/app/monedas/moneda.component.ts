import { Component } from "@angular/core";

@Component({
    selector: 'pm-moneda',
    template: '<li>{{nombre}} ({{codigo}})</li>'
})

export class MonedaComponent {
    codigo: string = "EUR"
    nombre: string = "Euro"
}