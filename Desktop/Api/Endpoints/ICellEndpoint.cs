using Desktop.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desktop.Api.Endpoints
{
    public interface ICellEndpoint
    {
        Task AddCell(Cell cell);
        Task<List<Cell>> AllCell();
        Task DeleteCell (int idCell);
        Task<Cell> SelectedCell(int idCell);
    }
}