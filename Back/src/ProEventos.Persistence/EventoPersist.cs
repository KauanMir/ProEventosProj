using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Contratos.Persistence;
using ProEventos.Domain;
using ProEventos.Pesistence;
using ProEventos.Pesistence.Contextos;

namespace ProEventos.Persistence
{
    public class EventoPersist : IEventoPersist
    {
       
        private readonly ProEventosContext _context;

        public EventoPersist(ProEventosContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
    
        //Evento

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                 .Include(e => e.Lotes)
                 .Include(e => e.RedesSociais);

                 if(includePalestrantes){
                     query = query.Include(e => e.PalestrantesEventos).ThenInclude(pe=> pe.Palestrante);
                 }

                 query = query.AsNoTracking().OrderBy(x => x.Id);
                 return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                 .Include(e => e.Lotes)
                 .Include(e => e.RedesSociais);

                 if(includePalestrantes){
                     query = query.Include(e => e.PalestrantesEventos).ThenInclude(pe=> pe.Palestrante);
                 }

                 query = query.AsNoTracking().OrderBy(x => x.Id).Where(e => e.Tema.ToLower().Contains(tema.ToLower()));
                 return await query.ToArrayAsync();
        }
        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                 .Include(e => e.Lotes)
                 .Include(e => e.RedesSociais);

                 if(includePalestrantes){
                     query = query.AsNoTracking().Include(e => e.PalestrantesEventos).ThenInclude(pe=> pe.Palestrante);
                 }

                 query = query.OrderBy(x => x.Id).Where(e => e.Id == eventoId);
                 return await query.FirstOrDefaultAsync();
        }
    }
}


