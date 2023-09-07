import { Component, OnDestroy, OnInit } from "@angular/core";
import { Subscription } from "rxjs";
import { IMoneda } from "../monedas/moneda";
import { MonedaService } from "../monedas/moneda.service";
import { ConversorService } from "./conversor.service";
import { IPeticionConversion } from "./peticion-conversion";

@Component({
    selector: "pm-conversor",
    templateUrl: "./conversor.component.html"
})

export class ConversorComponent {
    pageTitle: string = 'Conversor de Monedas';
    monedaOrigenSelect: string = "";
    monedaDestinoSelect: string = "";
    importe: any;
    resultado: number = 1;
    conversionDone: boolean = false;
    monedas: IMoneda[] = [];
    errorMessage: string = '';
    sub!: Subscription;

    constructor(private monedaService: MonedaService, private conversorService: ConversorService) { }

    hacerConversion(): void {
        let regex = /^\d+(\.\d+)?$/;

        if (!regex.test(this.importe)) {
            alert("Introduce un valor valido p.ej: 32.56");
            return;
        }

        let peticionConversion = <IPeticionConversion>{
            importe: this.importe,
            monedaOrigenId: this.monedas.find(m => m.code === this.monedaOrigenSelect)?.id,
            monedaDestinoId: this.monedas.find(m => m.code === this.monedaDestinoSelect)?.id,
            idUsuario: "3d003759-af60-48b0-b996-a2df0e5f19d2"
        };

        this.sub = this.conversorService.postConversion(peticionConversion).subscribe({
            next: result => {
              this.resultado = result.resultadoConversion;
              this.conversionDone = true;
            },
            error: err => this.errorMessage = err,
        });
    }

    resetearConversion(): void {
        this.conversionDone = false
    }

    ngOnInit(): void {
        this.sub = this.monedaService.getMonedas().subscribe({
          next: monedas => {
            this.monedas = monedas;
          },
          error: err => this.errorMessage = err
        });
    }
    
    ngOnDestroy(): void {
        this.sub.unsubscribe();
    }
}