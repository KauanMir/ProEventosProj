import { Component, OnInit, TemplateRef } from '@angular/core';

import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

import { Evento } from '../../Models/Evento';
import { EventoService } from '../../Service/evento.service';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  isCollapsed = true;
  modalRef = {} as BsModalRef
  public eventos : Evento[] = [];
  public eventosFiltrados : Evento[] = [];


  constructor
    (
    private eventoService: EventoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService
    ) { }

  public widthImg = 150;
  public marginImg = 2;
  public showImage = true;
  private filtroListado = '';



  public get filtroLista(): string {
    return this.filtroListado;
  }

  public set filtroLista(value: string){
    this.filtroListado = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  public filtrarEventos(filtrarPor : string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
        (evento : any) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
        evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  public ngOnInit(): void {
    this.spinner.show();
    this.GetEventos();
  }

  public alterarImagem(): void {
      this.showImage = !this.showImage;
  }

  public GetEventos(): void{
    this.eventoService.getEventos().subscribe({
      next: (eventos:Evento[]) => {
        this.eventos = eventos,
        this.eventosFiltrados = this.eventos;
      },
      error: (error:any) => {
        this.spinner.hide()
        this.toastr.error('Erro ao carregar os eventos!', 'Error!');

      },
      complete: () => this.spinner.hide()
    });
  }
  openModal(template: TemplateRef<any>):void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef.hide();
    this.toastr.success('O evento foi deletado com sucesso!', 'Deletado!');
  }

  decline(): void {
    this.modalRef.hide();
  }
}
