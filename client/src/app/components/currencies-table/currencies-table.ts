import { Component, inject, OnInit, signal } from '@angular/core';
import { HlmCard, HlmCardHeader, HlmCardTitle, HlmCardContent } from '@spartan-ng/helm/card';
import { HlmTableContainer, HlmTable, HlmTHead, HlmTh, HlmTBody, HlmTd, HlmTr } from '@spartan-ng/helm/table';
import { ExchangeRateApi } from '../../services/exchange-rate-api';
import { catchError } from 'rxjs';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-currencies-table',
  imports: [
    HlmCard,
    HlmCardHeader,
    HlmCardTitle,
    HlmCardContent,
    HlmTableContainer,
    HlmTable,
    HlmTHead,
    HlmTh,
    HlmTBody,
    HlmTd,
    DatePipe,
    HlmTr,
],
  templateUrl: './currencies-table.html',
  styleUrl: './currencies-table.css',
})
export class CurrenciesTable implements OnInit {
  currentDate = signal('');
  exchangeRates = signal<Array<Rate>>([]);
  apiService = inject(ExchangeRateApi);

  ngOnInit(): void {
    this.apiService
      .getForexToday()
      .pipe(
        catchError((err) => {
          console.error(err);
          throw err;
        })
      )
      .subscribe((x) => {
        console.log(x);
        this.exchangeRates.set(x.rates);
        this.currentDate.set(this.exchangeRates()[0].validFor);
      });

  }
}
