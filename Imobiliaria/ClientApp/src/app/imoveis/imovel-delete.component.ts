import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl } from '@angular/forms';

import { Imovel } from './imovel';

@Component({
  selector: 'app-imovel-delete',
  templateUrl: 'imovel-delete.component.html',
  styleUrls: ['/imovel-delete.component.css']

})

export class ImovelDeleteComponent implements OnInit {

  //título da view
  title: string;

  //form
  form: FormGroup;

  //O objeto
  imovel: Imovel;

  //id
  id?: number;

  constructor(
    private activatedRoute: ActivatedRoute,
    private route: Router,
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) {}


  ngOnInit() {
    this.form = new FormGroup({
      id: new FormControl(''),
      idDono: new FormControl(''),
      idAgencia: new FormControl(''),
      endereco: new FormControl(''),
      preco: new FormControl('')

    })

    this.loadData();

  }

  loadData() {

    this.id = +this.activatedRoute.snapshot.paramMap.get('id');
    var url = this.baseUrl + 'api/Imoveis/' + this.id;
    this.http.get<Imovel>(url)
      .subscribe(result => {
        this.imovel = result;
        this.title = "Delete - " + this.imovel.endereco;

        this.form.patchValue(this.imovel);

      });

  }

  onSubmit() {

    var imovel = this.imovel;
    var url = this.baseUrl + 'api/Imoveis/' + this.id;
    this.http.delete<Imovel>(url)
      .subscribe(result => {

        console.log("O imovel " + this.id + " foi deletado com sucesso.");

        this.route.navigate(['/imoveis']);

      })

  }


}
