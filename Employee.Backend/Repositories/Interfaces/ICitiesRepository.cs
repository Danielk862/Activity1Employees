using Employee.Shared.Dtos;
using Employee.Shared.Entities;
using Employee.Shared.Responses;

namespace Employee.Backend.Repositories.Interfaces
{
    public interface ICitiesRepository
    {
        Task<IEnumerable<City>> GetComboAsync(int stateId);
        Task<ActionResponse<IEnumerable<City>>> GetAsync(PaginationDto pagination);
        Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDto pagination);
    }
}
