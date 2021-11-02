import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl } from '@angular/forms';

import { Corretor } from './corretor';

@Component({
  selector: 'app-corretor-delete',
  templateUrl: 'corretor-delete.component.html',
  styleUrls: ['/corretor-delete.component.css']

})

export class CorretorDeleteComponent implements OnInit {

  //title
  title: string;

  //form
  form: FormGroup;

  //Objeto
  corretor: Corretor;

  //id
  id?: number;

  constructor(
    private activatedRoute: ActivatedRoute,
    private route: Router,
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) { }

  ngOnInit() {

    this.form = new FormGroup({
      id: new FormControl(''),
      idAgencia: new FormControl(''),
      nome: new FormControl(''),
      idade: new FormControl(''),
      vendas: new FormControl('')

    });

    this.loadData();

  }

  loadData() {

    this.id = +this.activatedRoute.snapshot.paramMap.get('id');

    var url = this.baseUrl + 'api/Corretores/' + this.id;
    this.http.get<Corretor>(url)
      .subscribe(result => {
        this.corretor = result;
        this.title = "Deltar - " + this.corretor.nome;

        this.form.patchValue(this.corretor);

      }, error => console.log(error));

  }

  onSubmit() {

    var corretor = this.corretor;

    var url = this.baseUrl + 'api/Corretores/' + this.id;
    this.http.delete<Corretor>(url)
      .subscribe(result => {

        console.log("O corretor " + this.id + " foi deletado com sucesso.");

        this.route.navigate(['/corretores']);

      })


  }

}


