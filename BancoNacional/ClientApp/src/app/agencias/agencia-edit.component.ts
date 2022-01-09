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

  //título
  titulo: string;

  //Form
  form: FormGroup;

  //Agencia
  agencia: Agencia;

  //id
  id?: number;

  constructor(
    private http: HttpClient,
    private route: Router,
    private activatedRoute: ActivatedRoute,
    @Inject('BASE_URL') private baseUrl: string

  ) { }

  ngOnInit() {

    this.form = new FormGroup({
      codigoAgencia: new FormControl(''),
      nome: new FormControl(''),
      localizacao: new FormControl(''),
      numeroClientes: new FormControl(''),
      gerente: new FormControl('')

    })

    this.loadData();

  }

  loadData() {

    //Retorna o id do cadastro selecionado
    this.id = +this.activatedRoute.snapshot.paramMap.get('codigoAgencia');

    //Busca da agência no banco de dados do servidor
    var url = this.baseUrl + 'api/Agencias/' + this.id;
    this.http.get<Agencia>(url)
      .subscribe(result => {
        this.agencia = result,
        this.titulo = 'Edit  - ' + this.agencia.nome;

        //Preenchimento do formulário com os valores da agência 
        this.form.patchValue(this.agencia);

      }, error => console.error(error));

  }

  onSubmit() {

    var agencia = (this.id) ? this.agencia : <Agencia>{};

    agencia.nome = this.form.get('nome').value;
    agencia.localizacao = this.form.get('localizacao').value;
    agencia.numeroClientes = this.form.get('numeroClientes').value;
    agencia.gerente = this.form.get('gerente').value;


    if (this.id) {

      //Método PUT

      var url = this.baseUrl + 'api/Agencias/' + this.agencia.id;
      this.http.put<Agencia>(url, agencia)
        .subscribe(result => {

          //Mensagem de sucesso
          console.log('A agência ' + this.agencia.nome + ' foi atualizada com sucesso.');

          //Retorna para a lista de agências após a conclusão
          this.route.navigate(['/agencias']);

        }, error => console.error(error));


    }
    else
    {

      //Método POST

      var url = this.baseUrl + 'api/Agencias';
      this.http.post<Agencia>(url, agencia)
        .subscribe(result => {

          //Mensagem de sucesso
          console.log('A agência ' + this.agencia.nome + ' foi adicionada com sucesso.');

          //Retorna para lista de agências
          this.route.navigate(['/agencias']);

        }, error => console.error(error));

    }


  }


}
