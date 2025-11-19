using Employee.Shared.Dtos;
using Employee.Shared.Entities;
using Employee.Shared.Responses;

namespace Employee.Backend.Repositories.Interfaces
{
    public interface IStatesRepository
    {
        Task<IEnumerable<State>> GetComboAsync(int countryId);
        Task<ActionResponse<State>> GetAsync(int id);
        Task<ActionResponse<IEnumerable<State>>> GetAsync();
        Task<ActionResponse<IEnumerable<State>>> GetAsync(PaginationDto pagination);
        Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDto pagination);
    }
}
