import { Component } from '@angular/core';
import { Converter } from '../converter/converter';
import { CurrenciesTable } from '../currencies-table/currencies-table';

@Component({
  selector: 'app-main',
  imports: [Converter, CurrenciesTable],
  templateUrl: './main.html',
  styleUrl: './main.css',
})
export class Main {

}
