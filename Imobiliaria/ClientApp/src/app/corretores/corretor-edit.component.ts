import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl } from '@angular/forms';


import { Corretor } from './corretor';

@Component({
  selector: 'app-corretor-edit',
  templateUrl: 'corretor-edit.component.html',
  styleUrls: ['./corretor.component.css']

})


export class CorretorEditComponent implements OnInit {

  //Título da view
  title: string;

  //Form Group
  form: FormGroup;

  //O Objeto
  corretor: Corretor;

  constructor(
    private activetedRoute: ActivatedRoute,
    private router: Router,
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) { }

  ngOnInit() {

    this.form = new FormGroup({
      id: new FormControl(''),
      idAgencia: new FormControl(''),
      nome: new FormControl(''),
      idade: new FormControl(''),
      vendas: new FormControl(''),
    });

    this.loadData();

  }

  loadData() {

    //Retorna os dados por id
    var id = +this.activetedRoute.snapshot.paramMap.get('id');

    //Busca o corretor no servidor
    var url = this.baseUrl + "api/Corretores/" + id;
    this.http.get<Corretor>(url)
      .subscribe(result => {
        this.corretor = result;
        this.title = "Edit - " + this.corretor.nome;

        //Atualiza o formulário com o nome do corretor
        this.form.patchValue(this.corretor);

      }, error => console.error(error));

  }

  onSubmit() {
    var corretor = this.corretor;

    corretor.idAgencia = this.form.get("idAgencia").value;
    corretor.nome = this.form.get("nome").value;
    corretor.idade = this.form.get("idade").value;
    corretor.vendas = this.form.get("vendas").value;

    var url = this.baseUrl + "api/Corretores/" + this.corretor.id;
    this.http.put<Corretor>(url, corretor)
      .subscribe(result => {

        console.log("Corretor " + this.corretor.id + " foi atualizado");

        //Volta para lista de corretores
        this.router.navigate(['/corretores']);

      }, error => console.error(error));

  }


}
