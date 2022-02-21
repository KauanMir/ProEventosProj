using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Contratos.Persistence;
using ProEventos.Domain;
using ProEventos.Pesistence;
using ProEventos.Pesistence.Contextos;

namespace ProEventos.Persistence
{
    public class PalestrantePersist : IPalestrantePersist
    {
       
        private readonly ProEventosContext _context;

        public PalestrantePersist(ProEventosContext context)
        {
            _context = context;
        }
        //Palestrantes
        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                 .Include(p => p.RedesSociais);

                 if(includeEventos){
                     query = query.Include(p => p.PalestrantesEventos).ThenInclude(pe=> pe.Evento);
                 }

                 query = query.AsNoTracking().OrderBy(x => x.Id);
                 return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos)
        {
             IQueryable<Palestrante> query = _context.Palestrantes
                 .Include(p => p.RedesSociais);

                 if(includeEventos){
                     query = query.Include(p => p.PalestrantesEventos).ThenInclude(pe=> pe.Evento);
                 }

                 query = query.AsNoTracking().OrderBy(x => x.Id).Where(p => p.Nome.ToLower().Contains(nome.ToLower()));
                 return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                 .Include(p => p.RedesSociais);

                 if(includeEventos){
                     query = query.Include(p => p.PalestrantesEventos).ThenInclude(pe=> pe.Evento);
                 }

                 query = query.AsNoTracking().OrderBy(x => x.Id).Where(x=> x.Id == palestranteId);
                 return await query.FirstOrDefaultAsync();
        }
    }
}


