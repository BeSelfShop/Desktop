using Desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Api.Endpoints
{
    public interface IIsolationEndpoint
    {
        Task AddIsolation(Isolation isolation);
        Task<List<Isolation>> AllIsolation();
        Task DeleteIsolation(int idIsolation);
        Task<Isolation> SelectedIsolation(int idPrisoner);
        Task UpdatePass(int idIsolation, Isolation isolation);
    }
}
