import { Component, inject, OnInit, signal } from '@angular/core';
import { HlmCard, HlmCardHeader, HlmCardTitle, HlmCardContent } from '@spartan-ng/helm/card';
import {
  HlmTableContainer,
  HlmTable,
  HlmTHead,
  HlmTh,
  HlmTBody,
  HlmTd,
  HlmTr,
} from '@spartan-ng/helm/table';
import { ExchangeRateApi } from '../../services/exchange-rate-api';
import { catchError, single } from 'rxjs';
import { DatePipe } from '@angular/common';
import { NgHttpLoaderComponent } from 'ng-http-loader';

@Component({
  selector: 'app-currencies-table',
  imports: [
    HlmCard,
    HlmCardHeader,
    HlmCardContent,
    HlmTableContainer,
    HlmTable,
    HlmTHead,
    HlmTh,
    HlmTBody,
    HlmTd,
    DatePipe,
    HlmTr,
    NgHttpLoaderComponent,
  ],
  templateUrl: './currencies-table.html',
  styleUrl: './currencies-table.css',
})
export class CurrenciesTable implements OnInit {
  currentDate = signal('');
  exchangeRates = signal<Array<Rate>>([]);
  apiService = inject(ExchangeRateApi);
  isLoading = signal(true);
  errorMessage = signal('');

  ngOnInit(): void {
    this.apiService
      .getForexToday()
      .pipe(
        catchError((err) => {
          console.error(err);
          if (err.status === 500) this.errorMessage.set('Server Error');
          if (err.status === 0) this.errorMessage.set('Connection Error');
          throw err;
        })
      )
      .subscribe((x) => {
        this.exchangeRates.set(x.rates);
        this.currentDate.set(this.exchangeRates()[0].validFor);
        this.isLoading.set(false);
      });
  }
}
