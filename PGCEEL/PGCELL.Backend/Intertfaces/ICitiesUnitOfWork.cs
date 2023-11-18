using PGCEEL.Shared.DTOs;
using PGCEEL.Shared.Entities;
using PGCEEL.Shared.Responses;

namespace PGCELL.Backend.Intertfaces
{
    public interface ICitiesUnitOfWork
    {
        Task<Response<IEnumerable<City>>> GetAsync(PaginationDTO pagination);

        Task<Response<int>> GetTotalPagesAsync(PaginationDTO pagination);

        Task<IEnumerable<City>> GetComboAsync(int stateId);
    }
}
