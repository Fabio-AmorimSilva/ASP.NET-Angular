import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl } from '@angular/forms';

import { Dono } from './dono';

@Component({
  selector: 'app-edit-dono',
  templateUrl: 'dono-edit.component.html',
  styleUrls: ['./dono-edit.component.css']

})

export class DonoEditComponent implements OnInit {

  //título da view
  title: string;

  //Formulário
  form: FormGroup;

  //Objeto para ser editado
  dono: Dono;

  constructor(
    private activatedRoute: ActivatedRoute,
    private route: Router,
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) {}

  ngOnInit() {
    this.form = new FormGroup({
      nome: new FormControl(''),
      idade: new FormControl(''),
      imovel: new FormControl(''),

    });

    this.loadData();

  }

  loadData() {

    //Retorna dados por id
    var id = +this.activatedRoute.snapshot.paramMap.get('id');

    //Buscando o objeto correspondente a identificação
    var url = this.baseUrl + 'api/Donos/' + id;
    this.http.get<Dono>(url)
      .subscribe(result => {
        this.dono = result,
        this.title = "Edit - " + this.dono.nome;

        //Atualiza o valor do formulário com o dono
        this.form.patchValue(this.dono);

      }, error => console.error(error));

  }

    onSubmit() {

      var dono = this.dono;

      dono.nome = this.form.get('nome').value;
      dono.idade = this.form.get('idade').value;
      dono.imovel = this.form.get('imovel').value;

      var url = this.baseUrl + 'api/Donos/' + this.dono.id;
      this.http.put<Dono>(url, dono)
        .subscribe(result => {

          console.log("Dono " + this.dono.id + " foi editado com sucesso.");

          //Volta para lista de donos
          this.route.navigate(['/donos']);

        }, error => console.error(error));


  }


}
