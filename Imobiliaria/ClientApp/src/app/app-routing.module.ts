import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AgenciaComponent } from './agencias/agencia.component';
import { AgenciaEditComponent } from './agencias/agencia-edit.component';
import { CorretorComponent } from './corretores/corretor.component';
import { CorretorEditComponent } from './corretores/corretor-edit.component';
import { DonoComponent } from './donos/dono.component';
import { DonoEditComponent } from './donos/dono-edit.component';
import { ImovelComponent } from './imoveis/imovel.component';
import { ImovelEditComponent } from './imoveis/imovel-edit.component';


const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'agencias', component: AgenciaComponent },
  { path: 'agencia/:id', component: AgenciaEditComponent },
  { path: 'agencia', component: AgenciaEditComponent },
  { path: 'corretores', component: CorretorComponent },
  { path: 'corretor/:id', component: CorretorEditComponent },
  { path: 'corretor', component: CorretorEditComponent },
  { path: 'donos', component: DonoComponent },
  { path: 'dono/:id', component: DonoEditComponent },
  { path: 'dono', component: DonoEditComponent },
  { path: 'imoveis', component: ImovelComponent },
  { path: 'imovel/:id', component: ImovelEditComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule{}
