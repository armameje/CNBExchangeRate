import { Component, signal } from '@angular/core';
import { HlmCard, HlmCardHeader, HlmCardTitle, HlmCardContent } from '@spartan-ng/helm/card'
import { HlmTableContainer, HlmTable, HlmTHead, HlmTh } from '@spartan-ng/helm/table'

@Component({
  selector: 'app-currencies-table',
  imports: [HlmCard, HlmCardHeader, HlmCardTitle, HlmCardContent, HlmTableContainer, HlmTable, HlmTHead, HlmTh],
  templateUrl: './currencies-table.html',
  styleUrl: './currencies-table.css',
})
export class CurrenciesTable {
  currentDate = signal('December 18, 2025')
}
