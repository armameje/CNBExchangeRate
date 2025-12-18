import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class ExchangeRateApi {
  apiUrl = environment.api;
  http = inject(HttpClient)

  constructor() {}    

  getForexToday() {
    return this.http.get<Rates>(`${this.apiUrl}cnb/today`);
  }
}
