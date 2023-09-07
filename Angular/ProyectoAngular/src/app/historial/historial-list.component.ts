import { Component, OnDestroy, OnInit } from "@angular/core";
import { Subscription } from "rxjs";
import { IHistorial } from "./historial";
import { HistorialService } from "./historial.service";

@Component({
  selector: 'pm-historial',
  templateUrl: './historial-list.component.html'
})
export class HistorialListComponent {
  pageTitle: string = 'Hstorial';
  errorMessage: string = '';
  sub!: Subscription;

  private _listFilter: string = '';
  get listFilter(): string {
    return this._listFilter;
  }
  set listFilter(value: string) {
    this._listFilter = value;
    console.log('In setter:', value);
    // this.filteredHistoriales = this.performFilter(value);
  }

  filteredHistoriales: IHistorial[] = [];
  historiales: IHistorial[] = [];

  constructor(private historialService: HistorialService) { }

  // performFilter(filterBy: string): IHistorial[] {
  //   filterBy = filterBy.toLocaleLowerCase();
  //   return this.historiales.filter((historial: IHistorial) =>
  //     historial.name.toLocaleLowerCase().includes(filterBy));
  // }

  ngOnInit(): void {
    this.sub = this.historialService.getHistorial().subscribe({
      next: historiales => {
        this.historiales = historiales;
      },
      error: err => this.errorMessage = err
    });
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
}
