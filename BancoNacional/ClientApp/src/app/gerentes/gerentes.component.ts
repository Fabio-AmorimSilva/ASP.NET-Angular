import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { gerente } from './gerente';

@Component({
  selector: 'app-gerentes',
  templateUrl: 'gerentes.component.html',
  styleUrls: ['./gerentes.component.css']

})

export class GerentesComponent implements OnInit {

  //Variáveis com os gerentes
  public gerentes: gerente[];

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) { }

  ngOnInit() {
    this.loadGerentes();
  }

  loadGerentes() {
    var url = this.baseUrl + 'api/Gerentes';
    this.http.get<gerente[]>(url)
      .subscribe(result => {
        this.gerentes = result;

      }, error => console.error(error));
  }
}

