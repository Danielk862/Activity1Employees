using Employee.Backend.Repositories.Interfaces;
using Employee.Backend.UnitsOfWork.Interfaces;
using Employee.Shared.Dtos;
using Employee.Shared.Entities;
using Employee.Shared.Responses;

namespace Employee.Backend.UnitsOfWork.Implementations
{
    public class EmployeesUnitOfWork : GenericUnitOfWork<EmployeeModel>, IEmployeesUnitOfWork
    {
        private readonly IEmployeesRepository _employeesRepository;

        public EmployeesUnitOfWork(IGenericRepository<EmployeeModel> repository, IEmployeesRepository employeesRepository) : base(repository)
        {
            _employeesRepository = employeesRepository;
        }

        public override async Task<ActionResponse<IEnumerable<EmployeeModel>>> GetAsync(string chars) =>
            await _employeesRepository.GetAsync(chars);

        public override async Task<ActionResponse<IEnumerable<EmployeeModel>>> GetAsync(PaginationDto pagination) => await _employeesRepository.GetAsync(pagination);
        public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDto pagination) => await _employeesRepository.GetTotalRecordsAsync(pagination);
    }
}
