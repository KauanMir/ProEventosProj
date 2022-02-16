using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase{

        public EventoController()
        {
        }
        public IEnumerable<Evento> _evento = new Evento[] {
               new Evento(){
               EventoId = 1,
               Local = "BSB",
               Tema = ".Net e Angular",
               Lote = "1°Lote",
               QtdPessoas = 250,
               DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
               ImagemURL = "Foto.png"
           },
           new Evento(){
               EventoId = 2,
               Local = "RJ",
               Tema = ".Net e Angular e suas curiosidades",
               Lote = "2°Lote",
               QtdPessoas = 345,
               DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
               ImagemURL = "Foto2.png"
           }
        };

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
           return _evento;
        }
        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id)
        {
           return _evento.Where(evento => evento.EventoId == id);
        }
    }
}
