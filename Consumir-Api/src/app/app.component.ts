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
  nomeAdicionar:string = ''
  modificar:string =''
  id_modificar:string =''

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


  AdicionarPessoa(){

    if(!this.AdicionarPessoa)
      return;

    const pessoaCriar:Pessoa = {
      id:'62858dc3-d984-4c06-8a9a-49234a7607e9',
      nome: this.nomeAdicionar
    }
    
    this.http.post<void>(`${this.url}/HumanoAdd`, pessoaCriar)
    .subscribe(valor => {
      
      this.obterPessoas()

      this.nomeAdicionar =''


    })
  }

  retornaPessoa(pessoa$:Pessoa){

    this.modificar = pessoa$.nome
    this.id_modificar= pessoa$.id
   

  }

  

  modifica_pessoa(){

    const pessoa_body:Pessoa = {

      id: this.id_modificar,
      nome: this.modificar

  
      
     };

  this.http.put<Pessoa>(`${this.url}/humano/${this.id_modificar}`, pessoa_body)
  .subscribe(_ => this.obterPessoas())


  }
  


}
