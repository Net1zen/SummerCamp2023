import { Component, OnDestroy, OnInit } from "@angular/core";
import { Subscription } from "rxjs";
import { IMoneda } from "./moneda";
import { MonedaService } from "./moneda.service";

@Component({
  selector: 'pm-monedas',
  templateUrl: './moneda-list.component.html'
})
export class MonedaListComponent {
  pageTitle: string = 'Lista de Monedas';
  showImage: boolean = false;
  errorMessage: string = '';
  sub!: Subscription;

  private _listFilter: string = '';
  get listFilter(): string {
    return this._listFilter;
  }
  set listFilter(value: string) {
    this._listFilter = value;
    console.log('In setter:', value);
    this.filteredMonedas = this.performFilter(value);
  }

  filteredMonedas: IMoneda[] = [];
  monedas: IMoneda[] = [];

  constructor(private monedaService: MonedaService) { }

  performFilter(filterBy: string): IMoneda[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.monedas.filter((moneda: IMoneda) =>
      moneda.name.toLocaleLowerCase().includes(filterBy));
  }
  
  toggleImage(): void {
    this.showImage = !this.showImage;
  }

  ngOnInit(): void {
    this.sub = this.monedaService.getMonedas().subscribe({
      next: monedas => {
        this.monedas = monedas;
        this.filteredMonedas = this.monedas;
      },
      error: err => this.errorMessage = err
    });
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  // monedas: any[] = [
  //   {
  //       "Id": 1,
  //       "Name": "Euro",
  //       "Code": "EUR",
  //       "Symbol": "€",
  //       "Descripcion": "EUR € - Euro",
  //       "FactorConversion": 1.09,
  //       "imageUrl": "http://s.exchangerate.net/small_flags/small_european_union_flag.gif"
  //   },
  //   {
  //       "Id": 2,
  //       "Name": "Dólar estadounidense",
  //       "Code": "USD",
  //       "Symbol": "$",
  //       "Descripcion": "USD $ - Dólar estadounidense",
  //       "FactorConversion": 1,
  //       "imageUrl": "http://s.exchangerate.net/small_flags/small_united_states_flag.gif"
  //   },
  //   {
  //       "Id": 3,
  //       "Name": "Libra esterlina",
  //       "Code": "GBP",
  //       "Symbol": "£",
  //       "Descripcion": "GBP £ - Libra esterlina",
  //       "FactorConversion": 1.27,
  //       "imageUrl": "http://s.exchangerate.net/small_flags/small_united_kingdom_flag.gif"
  //   }
  // ];
  // monedasFiltered: any[] = this.monedas;


  // filter() {
  //   let filterBy = this.listFilter.toLocaleLowerCase();
  //   this.monedasFiltered = this.monedas.filter((moneda: any) => moneda.nombre.toLocaleLowerCase().includes(filterBy));
  // }
    
}
