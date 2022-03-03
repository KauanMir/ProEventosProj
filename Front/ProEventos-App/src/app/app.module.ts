import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { CollapseModule } from 'ngx-bootstrap/collapse';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ModalModule } from 'ngx-bootstrap/modal';

import { ToastrModule } from 'ngx-toastr';

import { NgxSpinnerModule } from 'ngx-spinner';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TituloComponent } from './shared/titulo/titulo.component';
import { ContatosComponent } from './contatos/contatos.component';
import { DashboardComponent } from './Components/dashboard/dashboard.component';
import { EventosComponent } from './Components/eventos/eventos.component';
import { PalestrantesComponent } from './Components/palestrantes/palestrantes.component';
import { PerfilComponent } from './Components/perfil/perfil.component';
import { NavComponent } from './shared/nav/nav.component';

import { EventoService } from './Service/evento.service';

import { DateTimeFormatPipe } from './helpers/DateTimeFormat.pipe';


@NgModule({
  declarations: [
    AppComponent,
    EventosComponent,
    PalestrantesComponent,
    ContatosComponent,
    PerfilComponent,
    DashboardComponent,
    NavComponent,
    DateTimeFormatPipe,
    TituloComponent
   ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    CollapseModule.forRoot(),
    TooltipModule.forRoot(),
    BsDropdownModule.forRoot(),
    ModalModule.forRoot(),
    ToastrModule.forRoot({
        timeOut: 4000,
        positionClass: 'toast-bottom-right',
        preventDuplicates: true,
        progressBar: true,
    }),
    NgxSpinnerModule
  ],
  providers: [EventoService],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
