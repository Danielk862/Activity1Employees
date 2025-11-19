using Employee.Shared.Dtos;
using Employee.Shared.Entities;
using Employee.Shared.Responses;

namespace Employee.Backend.Repositories.Interfaces
{
    public interface ICountriesRepository
    {
        Task<IEnumerable<Country>> GetComboAsync();
        Task<ActionResponse<Country>> GetAsync(int id);
        Task<ActionResponse<IEnumerable<Country>>> GetAsync();
        Task<ActionResponse<IEnumerable<Country>>> GetAsync(PaginationDto pagination);
        Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDto paginationDTO);
    }
}
