import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Evento } from '../Models/Evento';
import { EventoService } from '../Service/evento.service';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  isCollapsed = true;
  public eventos : Evento[] = [];
  public eventosFiltrados : Evento[] = [];


  constructor(private eventoService: EventoService) { }

  public widthImg : number = 150;
  public marginImg : number = 2;
  public showImage: boolean = true;
  private _filtroLista: string = '';



  public get filtroLista(): string {
    return this._filtroLista;
  }

  public set filtroLista(value: string){
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  public filtrarEventos(filtrarPor : string): Evento[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
        (evento : any) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
        evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    )
  }

  public ngOnInit(): void {
    this.GetEventos();
  }

  public alterarImagem(): void {
      this.showImage = !this.showImage;
  }

  public GetEventos(): void{
    this.eventoService.getEventos().subscribe(
      (_eventos:Evento[]) => {
        this.eventos = _eventos,
        this.eventosFiltrados = this.eventos;
      },
      error => console.log(error)
    );
  }
}
