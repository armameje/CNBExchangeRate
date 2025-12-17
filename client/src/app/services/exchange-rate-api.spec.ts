import { TestBed } from '@angular/core/testing';

import { ExchangeRateApi } from './exchange-rate-api';

describe('ExchangeRateApi', () => {
  let service: ExchangeRateApi;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ExchangeRateApi);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
