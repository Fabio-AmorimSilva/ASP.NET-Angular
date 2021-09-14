import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Imovel } from './imovel';

@Component({
  selector: 'app-imovel',
  templateUrl: 'imovel.component.html',
  styleUrls: ['./imovel.component.css']

})

export class ImovelComponent implements OnInit {
  public colunas: string[] = ['id', 'idDono', 'idAgencia', 'endereco', 'preco'];
  public imoveis: Imovel[];

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) { }

  ngOnInit() {
    var url = this.baseUrl + 'api/Imoveis';
    this.http.get<Imovel[]>(url)
      .subscribe(result => {
        this.imoveis = result;
      }, error => console.error(error));
  }

}
