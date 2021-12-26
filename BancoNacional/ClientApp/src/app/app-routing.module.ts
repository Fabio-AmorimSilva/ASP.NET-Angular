import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AgenciasComponent } from './agencias/agencias.component';
import { ClientesComponent } from './clientes/clientes.component';
import { GerentesComponent } from './gerentes/gerentes.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'agencias', component: AgenciasComponent },
  { path: 'clientes', component: ClientesComponent },
  { path: 'gerentes', component: GerentesComponent }


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]

})

export class AppRoutingModule { };
