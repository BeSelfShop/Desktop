using Desktop.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desktop.Api.Endpoints
{
    public interface IPrisonerEndpoint
    {
        Task AddPrisoner(Prisoner prisoner);
        Task<List<Prisoner>> AllPrisoner();
        Task DeletePrisoner(int idPrisoner);
        Task<Prisoner> SelectedPrisoner(int idPrisoner);
        Task UpdatePrisoner(int idPrisoner, Prisoner prisoner);
    }
}