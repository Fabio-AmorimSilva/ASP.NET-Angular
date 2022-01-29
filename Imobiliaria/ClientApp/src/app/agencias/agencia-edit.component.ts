import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl } from '@angular/forms';

import { Agencia } from './agencia';

@Component({
  selector: 'app-agencia-edit',
  templateUrl: 'agencia-edit.component.html',
  styleUrls: ['./agencia-edit.component.css']

})

export class AgenciaEditComponent implements OnInit {

  //título da view
  title: string;

  // Form Group
  form: FormGroup;

  //O objeto
  agencia: Agencia;

  //id
  id?: number;

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) { }

  ngOnInit() {

    this.createForm();

    this.loadData();

  }

  loadData() {

    //Retorna os dados por ID
    this.id = +this.activatedRoute.snapshot.paramMap.get('id');

    // Busca a agência no servidor
    var url = this.baseUrl + 'api/Agencias/' + this.id;
    this.http.get<Agencia>(url)
      .subscribe(result => {
        this.agencia = result;
        this.title = "Edit - " + this.agencia.nome;

        //Atualiza o formulário com o valor da agencia
        this.form.patchValue(this.agencia);

      }, error => console.error(error));
  }

  onSubmit() {
    var agencia = (this.id) ? this.agencia : <Agencia>{};

    agencia.nome = this.form.get("nome").value;
    agencia.cidade = this.form.get("cidade").value;
    agencia.idCorretor = this.form.get("idCorretor").value;
    agencia.idImovel = this.form.get("idImovel").value;

    if (this.id) {

      //Modo edição
      this.editMode(agencia);
     
    } else {

      //Modo adição
      this.addMode(agencia);
    }
  }

  createForm() {
    this.form = new FormGroup({
      id: new FormControl(''),
      nome: new FormControl(''),
      cidade: new FormControl(''),
      idCorretor: new FormControl(''),
      idImovel: new FormControl('')

    });

  }

  addMode(agencia) {

    var url = this.baseUrl + "api/Agencias";
    this.http.post<Agencia>(url, agencia)
      .subscribe(result => {

        console.log("Agência " + result.id + " foi criada");

        //Volta para lista de agências
        this.router.navigate(['/agencias']);

      }, error => console.error(error));
  }

  editMode(agencia) {
    var url = this.baseUrl + "api/Agencias/" + this.agencia.id;
    this.http.put<Agencia>(url, agencia)
      .subscribe(result => {

        console.log("Agência " + this.agencia.id + " foi atualizada.");

        //Volta para lista de agências
        this.router.navigate(['/agencias']);
      }, error => console.error(error));
  }

}

