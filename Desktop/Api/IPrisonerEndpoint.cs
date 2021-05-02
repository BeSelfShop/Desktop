using Desktop.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desktop.Api
{
    public interface IPrisonerEndpoint
    {
        Task AddPrisoner(Prisoner prisoner);
        Task<List<Prisoner>> AllPrisoner();
        Task DeletePrisoner(int idPrisoner);
    }
}