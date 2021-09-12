import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AgenciaComponent } from './agencias/agencia.component';
import { CorretorComponent } from './corretores/corretor.component';
import { DonoComponent } from './donos/dono.component';
import { ImovelComponent } from './imoveis/imovel.component';


const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'agencias', component: AgenciaComponent },
  { path: 'corretores', component: CorretorComponent },
  { path: 'donos', component: DonoComponent },
  { path: 'imoveis', component: ImovelComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule{}
