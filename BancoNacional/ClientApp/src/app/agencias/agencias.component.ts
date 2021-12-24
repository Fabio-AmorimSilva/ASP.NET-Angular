import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Agencia } from './agencia';

@Component({
  selector: 'app-agencias',
  templateUrl: 'agencias.component.html',
  styleUrls: ['./agencias.component.css']

})

export class AgenciasComponent implements OnInit {

  //Variável com as agências
  public agencias: Agencia[];

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) { }

  ngOnInit() {
    this.loadAgencias();
  }

  loadAgencias() {
    var url = this.baseUrl + 'api/Agencias';
    this.http.get<Agencia[]>(url)
      .subscribe(result => {
        this.agencias = result;

      }, error => console.error(error))
  }

}
