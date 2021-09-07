import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

import { Agencia } from './agencia';

@Component({
  selector: 'app-agencias',
  templateUrl: './agencia.component.html',
  styleUrls: ['./agencia.component.css']
})


export class AgenciaComponent implements OnInit {

  public agencias : Agencia[];

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) {}

  ngOnInit() {
    this.http.get<Agencia[]>(this.baseUrl + 'api/Agencias')
      .subscribe(result => {
        this.agencias = result;
      }, error => console.error(error));

  }


}
