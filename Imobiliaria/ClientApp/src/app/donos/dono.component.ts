import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Dono } from './dono';

@Component({
  selector: 'app-dono',
  templateUrl: 'dono.component.html',
  styleUrls: ['./dono.component.css']

})

export class DonoComponent implements OnInit {
  public colunas: string[] = [ 'nome', 'idade', 'imovel'];
  public donos: Dono[];

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) { }

  ngOnInit() {
    var url = this.baseUrl + 'api/Donos';
    this.http.get<Dono[]>(url)
      .subscribe(result => {
        this.donos = result;
      }, error => console.error(error));
  }


}
