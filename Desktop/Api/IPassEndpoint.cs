using Desktop.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desktop.Api
{
    public interface IPassEndpoint
    {
        Task<List<Pass>> AllPass();
    }
}