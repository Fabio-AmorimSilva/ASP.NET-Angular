import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl } from '@angular/forms';

import { Imovel } from './imovel';

@Component({
  selector: 'app-imovel-edit',
  templateUrl: 'imovel-edit.component.html',
  styleUrls: ['./imovel-edit.component.css']

})

export class ImovelEditComponent implements OnInit {

  //título da view
  title: string;

  //Formúlario
  form: FormGroup;

  //O Objeto
  imovel: Imovel;

  //Id do imóvel
  id?: number;

  constructor(
    private activatedRoute: ActivatedRoute,
    private route: Router,
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) { }

  ngOnInit() {
    this.form = new FormGroup({
      idDono: new FormControl(''),
      idAgencia: new FormControl(''),
      endereco: new FormControl(''),
      preco: new FormControl(''),

    });

    this.loadData();

  }

  loadData() {

    //Retorna dados por id
    this.id = +this.activatedRoute.snapshot.paramMap.get('id');

    //Buscando o objeto correspondente a identificação
    var url = this.baseUrl + 'api/Imoveis/' + this.id;
    this.http.get<Imovel>(url)
      .subscribe(result => {
        this.imovel = result,
          this.title = "Edit - " + this.imovel.id;

        //Preenche o formulário com os dados do imóvel
        this.form.patchValue(this.imovel);

      }, error => console.error(error));

  }

  onSubmit() {

    var imovel = (this.id) ? this.imovel : <Imovel>{};

    imovel.idDono = this.form.get('idDono').value;
    imovel.idAgencia = this.form.get('idAgencia').value;
    imovel.endereco = this.form.get('endereco').value;
    imovel.preco = this.form.get('preco').value;

    if (this.id) {

      var url = this.baseUrl + 'api/Imoveis/' + this.imovel.id;
      this.http.put(url, imovel)
        .subscribe(result => {

          console.log("Imóvel " + this.imovel.id + " atualizado com sucesso.");

          //Volta para lista de imóveis
          this.route.navigate(['/imoveis']);

        }, error => console.error(error));

    } else {

      var url = this.baseUrl + 'api/Imoveis';
      this.http.post<Imovel>(url, imovel)
        .subscribe(result => {

          console.log("Imóvel " + result.id + " foi criado.");

          //Volta para a lista de imóveis
          this.route.navigate(['/imoveis']);

        }, error => console.error(error));

    }

  }


}

