import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { AgenciaComponent } from './agencias/agencia.component';
import { AgenciaEditComponent } from './agencias/agencia-edit.component';
import { AgenciaDeleteComponent } from './agencias/agencia-delete.component';
import { CorretorComponent } from './corretores/corretor.component';
import { CorretorEditComponent } from './corretores/corretor-edit.component';
import { CorretorDeleteComponent } from './corretores/corretor-delete.component';
import { DonoComponent } from './donos/dono.component';
import { DonoEditComponent } from './donos/dono-edit.component';
import { ImovelComponent } from './imoveis/imovel.component';
import { ImovelEditComponent } from './imoveis/imovel-edit.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AngularMaterialModule } from './angular-material.module';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    AgenciaComponent,
    AgenciaEditComponent,
    AgenciaDeleteComponent,
    CorretorComponent,
    CorretorEditComponent,
    CorretorDeleteComponent,
    DonoComponent,
    DonoEditComponent,
    ImovelComponent,
    ImovelEditComponent
    

  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    AngularMaterialModule,
    BrowserAnimationsModule,
    ReactiveFormsModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
