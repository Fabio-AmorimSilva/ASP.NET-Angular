import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Corretor } from './corretor';

@Component({
  selector: 'app-corretor',
  templateUrl: './corretor.component.html',
  styleUrls: ['./corretor.component.css']

})

export class CorretorComponent implements OnInit{
  public colunas: string[] = ['id', 'idAgencia', 'nome', 'idade', 'vendas'];
  public corretores: Corretor[];

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) { }

  ngOnInit() {
    var url = this.baseUrl + 'api/Corretores';
    this.http.get<Corretor[]>(url)
      .subscribe(result => {
        this.corretores = result;
      }, error => console.error(error));
  }



}
