import { Component } from '@angular/core';
import { Header } from '../components/header/header';
import { HlmButton, HlmButtonImports } from "@spartan-ng/helm/button"

@Component({
  selector: 'app-home',
  imports: [Header, HlmButton, HlmButtonImports],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class HomeComponent {

}
