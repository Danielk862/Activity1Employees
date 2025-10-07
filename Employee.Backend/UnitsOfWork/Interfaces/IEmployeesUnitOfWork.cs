using Employee.Backend.Dtos;
using Employee.Shared.Entities;
using Employee.Shared.Responses;

namespace Employee.Backend.UnitsOfWork.Interfaces
{
    public interface IEmployeesUnitOfWork
    {
        Task<ActionResponse<IEnumerable<EmployeeModel>>> GetAsync(string chars);
        Task<ActionResponse<IEnumerable<EmployeeModel>>> GetAsync(PaginationDto pagination);
        Task<ActionResponse<int>> GetTotalRecords(PaginationDto pagination);
    }
}
