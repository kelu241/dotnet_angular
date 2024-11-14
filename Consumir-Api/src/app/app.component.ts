import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Pessoa } from './models/Pessoa';
import { Observable } from 'rxjs';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Consumir-Api';
  http = inject(HttpClient);
  url = 'http://localhost:5222';

  
  // pessoas:Pessoa[] = [];
  pessoas$?: Observable<Pessoa[]>;
  pessoaEncontrada$?: Observable<Pessoa>;
  valorBuscaPessoa$ :string = '';
  ngOnInit():void{
    this.obterPessoas();
  }

  // obterPessoa(){
  //   this.http.get<Pessoa[]>(`${this.url}/humanos`)
  //   .subscribe(humanos => this.pessoas = humanos)
  // }
  obterPessoas (){

    this.pessoas$ = this.http.get<Pessoa[]>(`${this.url}/humanos`)
  }


  pessoaEncontrada(){
    if(!this.valorBuscaPessoa$) return
    this.pessoaEncontrada$ = this.http.get<Pessoa>(`${this.url}/humano/${this.valorBuscaPessoa$}`)

  }



}
