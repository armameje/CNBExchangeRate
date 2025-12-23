import { Component } from '@angular/core';
import { CurrenciesTable } from '../currencies-table/currencies-table';

@Component({
  selector: 'app-main',
  imports: [CurrenciesTable],
  templateUrl: './main.html',
  styleUrl: './main.css',
})
export class Main {

}
