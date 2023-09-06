import { Component, EventEmitter, Input, Output } from "@angular/core";

@Component({
    selector: 'pm-welcome',
    templateUrl: './welcome.component.html'
})

export class WelcomeComponent {
    public pageTitle = "Welcome";
    @Input() mensaje: string = '';
    @Output() saludar: EventEmitter<string> = new EventEmitter<string>();

    onClick(): void{
        this.saludar.emit("Saludo desde componente de bienvenda");
    }
}


