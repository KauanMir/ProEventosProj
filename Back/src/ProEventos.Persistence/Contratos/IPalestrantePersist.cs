using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Contratos.Persistence
{
    public interface IPalestrantePersist
    {
         //Palestrantes
         Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEvento);
         Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos);
         Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos);
    }
}