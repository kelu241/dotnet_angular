import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Pessoa } from './models/Pessoa';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Consumir-Api';
  http = inject(HttpClient);
  url = 'http://localhost:5134';

  pessoas:Pessoa[] = [];

  ngOnInit():void{
    this.obterPessoa();
  }

  obterPessoa(){
    this.http.get<Pessoa[]>(`${this.url}/humanos`)
    .subscribe(humanos => this.pessoas = humanos)
  }


}
