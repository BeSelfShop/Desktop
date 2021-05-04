using Desktop.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desktop.Api.Endpoints
{
    public interface IPassEndpoint
    {     
        Task AddPass(Pass pass);
        Task<List<Pass>> AllPass();
        Task DeletePass(int idPass);
    }
}