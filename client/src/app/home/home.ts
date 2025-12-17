import { Component } from '@angular/core';
import { Header } from '../components/header/header';
import { Main } from '../components/main/main';

@Component({
  selector: 'app-home',
  imports: [Header, Main],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class HomeComponent {

}
