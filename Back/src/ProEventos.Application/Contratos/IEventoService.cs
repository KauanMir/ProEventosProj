using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Application.Contratos
{
    public interface IEventoService
    {
         Task<Evento> AddEvento(Evento model);
         Task<Evento> UpdateEvento (int eventoId, Evento model);
         Task<bool> DeleteEvento (int EventoId);
         
         Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
         Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false);
         Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false);
    }
}