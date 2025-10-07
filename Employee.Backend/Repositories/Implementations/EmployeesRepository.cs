using Employee.Backend.Data;
using Employee.Backend.Dtos;
using Employee.Backend.Helpers;
using Employee.Backend.Repositories.Interfaces;
using Employee.Shared.Entities;
using Employee.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace Employee.Backend.Repositories.Implementations
{
    public class EmployeesRepository : GenericRepository<EmployeeModel>, IEmployeesRepository
    {
        private readonly DataContext _context;

        public EmployeesRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<ActionResponse<IEnumerable<EmployeeModel>>> GetAsync(string chars)
        {
            var rows = await _context.employees.Where(x => x.FirstName.Contains(chars) || x.LastName.Contains(chars)).ToListAsync();

            if (rows != null)
            {
                return new ActionResponse<IEnumerable<EmployeeModel>>
                {
                    WasSuccess = true,
                    Result = rows
                };
            }

            return new ActionResponse<IEnumerable<EmployeeModel>>
            {
                Messages = "Registro no encontrado",
            };
        }

        public override async Task<ActionResponse<IEnumerable<EmployeeModel>>> GetAsync(PaginationDto pagination)
        {
            var queryable = _context.employees.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.FirstName.ToLower().Contains(pagination.Filter.ToLower()) || x.LastName.ToLower().Contains(pagination.Filter.ToLower()));
            } 

            return new ActionResponse<IEnumerable<EmployeeModel>>
            {
                WasSuccess = true,
                Result = await queryable.OrderBy(x => x.FirstName).Paginate(pagination).ToListAsync()
            };
        }

        public override async Task<ActionResponse<int>> GetTotalRecords(PaginationDto pagination)
        {
            var queryable = _context.employees.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.FirstName.ToLower().Contains(pagination.Filter.ToLower()) || x.LastName.ToLower().Contains(pagination.Filter.ToLower()));
            }

            double count = await queryable.CountAsync();

            return new ActionResponse<int>
            {
                WasSuccess = true,
                Result = (int)count
            };
        }
    }
}
