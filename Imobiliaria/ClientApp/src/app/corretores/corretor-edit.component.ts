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

  //Id do corretor
  id?: number;

  constructor(
    private activetedRoute: ActivatedRoute,
    private router: Router,
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) { }

  ngOnInit() {

    this.createForm();
    
    this.loadData();

  }

  loadData() {

    //Retorna os dados por id
    this.id = +this.activetedRoute.snapshot.paramMap.get('id');

    //Busca o corretor no servidor
    var url = this.baseUrl + "api/Corretores/" + this.id;
    this.http.get<Corretor>(url)
      .subscribe(result => {
        this.corretor = result;
        this.title = "Edit - " + this.corretor.nome;

        //Atualiza o formulário com o nome do corretor
        this.form.patchValue(this.corretor);

      }, error => console.error(error));

  }

  onSubmit() {

    var corretor = (this.id) ? this.corretor : <Corretor>{};

    corretor.idAgencia = this.form.get("idAgencia").value;
    corretor.nome = this.form.get("nome").value;
    corretor.idade = this.form.get("idade").value;
    corretor.vendas = this.form.get("vendas").value;

    if (this.id) {

      //Modo Edição
      this.editMode(corretor);

    } else {

      //Modo adição
      this.addMode(corretor);

    }

  }

  createForm() {

    this.form = new FormGroup({
      id: new FormControl(''),
      idAgencia: new FormControl(''),
      nome: new FormControl(''),
      idade: new FormControl(''),
      vendas: new FormControl(''),
    });

  }

  addMode(corretor) {

    var url = this.baseUrl + "api/Corretores";
    this.http.post<Corretor>(url, corretor)
      .subscribe(result => {

        console.log("Corretor " + result.id + " foi criado.");

        //Volta para lista de corretores
        this.router.navigate(['/corretores']);

      }, error => console.error(error));

  }

  editMode(corretor) {
    var url = this.baseUrl + "api/Corretores/" + this.corretor.id;
    this.http.put<Corretor>(url, corretor)
      .subscribe(result => {

        console.log("Corretor " + this.corretor.id + " foi atualizado");

        //Volta para lista de corretores
        this.router.navigate(['/corretores']);


      }, error => console.error(error));

  }

}
