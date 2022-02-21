using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Contratos.Persistence;
using ProEventos.Domain;
using ProEventos.Pesistence;
using ProEventos.Pesistence.Contextos;

namespace ProEventos.Persistence
{
    public class GeralPersist : IGeralPersist
    {
       
        private readonly ProEventosContext _context;

        public GeralPersist(ProEventosContext context)
        {
            _context = context;
        }
         //Principal
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}


