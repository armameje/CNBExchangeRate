import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CurrenciesTable } from './currencies-table';

describe('CurrenciesTable', () => {
  let component: CurrenciesTable;
  let fixture: ComponentFixture<CurrenciesTable>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CurrenciesTable]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CurrenciesTable);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
