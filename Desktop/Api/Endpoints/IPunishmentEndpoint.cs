using Desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Api.Endpoints
{
    public interface IPunishmentEndpoint
    {
        Task AddPunishment(Punishment punishment);
        Task<List<Punishment>> AllPunishment();
        Task DeletePunishment(int idPunishment);
    }
}
