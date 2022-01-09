import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { cliente } from './cliente';

@Component({
  selector: 'app-clientes',
  templateUrl: 'clientes.component.html',
  styleUrls: ['./clientes.component.css']

})

export class ClientesComponent implements OnInit {

  //Variável com os clientes
  public clientes: cliente[];

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) { }

  ngOnInit() {
    this.loadClientes();

  }

  loadClientes() {
    var url = this.baseUrl + 'api/Clientes';
    this.http.get<cliente[]>(url)
      .subscribe(result => {
        this.clientes = result;

      }, error => console.error(error));
  }

}
