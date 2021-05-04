using Desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Api.Endpoints
{
    public interface IReasonEndpoint
    {
        Task AddReason(Reason reason);
        Task<List<Reason>> AllReason();
        Task DeleteReason(int idReason);
    }
}
