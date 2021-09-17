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
import { CorretorComponent } from './corretores/corretor.component';
import { CorretorEditComponent } from './corretores/corretor-edit.component';
import { DonoComponent } from './donos/dono.component';
import { ImovelComponent } from './imoveis/imovel.component';
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
    CorretorComponent,
    CorretorEditComponent,
    DonoComponent,
    ImovelComponent,
    
    

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
