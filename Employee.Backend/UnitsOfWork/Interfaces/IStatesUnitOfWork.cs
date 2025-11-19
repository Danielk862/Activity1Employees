using Employee.Shared.Dtos;
using Employee.Shared.Entities;
using Employee.Shared.Responses;

namespace Employee.Backend.UnitsOfWork.Interfaces
{
    public interface IStatesUnitOfWork
    {
        Task<IEnumerable<State>> GetComboAsync(int countryId);
        Task<ActionResponse<State>> GetAsync(int id);
        Task<ActionResponse<IEnumerable<State>>> GetAsync();
        Task<ActionResponse<IEnumerable<State>>> GetAsync(PaginationDto pagination);
        Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDto pagination);
    }
}
