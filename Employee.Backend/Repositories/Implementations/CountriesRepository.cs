using Employee.Backend.Data;
using Employee.Backend.Helpers;
using Employee.Backend.Repositories.Interfaces;
using Employee.Shared.Dtos;
using Employee.Shared.Entities;
using Employee.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace Employee.Backend.Repositories.Implementations
{
    public class CountriesRepository : GenericRepository<Country>, ICountriesRepository
    {
        private readonly DataContext _dataContext;

        public CountriesRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public override async Task<ActionResponse<IEnumerable<Country>>> GetAsync()
        {
            var countries = await _dataContext.countries
                .OrderBy(x => x.Name)
                .ToListAsync();

            return new ActionResponse<IEnumerable<Country>>
            {
                WasSuccess = true,
                Result = countries
            };
        }

        public override async Task<ActionResponse<Country>> GetAsync(int id)
        {
            var country = await _dataContext.countries
                .Include(x => x.States!)
                .ThenInclude(x => x.Cities)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (country == null)
            {
                return new ActionResponse<Country>
                {
                    Messages = "País no existe"
                };
            }

            return new ActionResponse<Country>
            {
                WasSuccess = true,
                Result = country
            };
        }

        public override async Task<ActionResponse<IEnumerable<Country>>> GetAsync(PaginationDto pagination)
        {
            var queryble = _dataContext.countries
                .Include(x => x.States)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryble = queryble.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }

            return new ActionResponse<IEnumerable<Country>>
            {
                WasSuccess = true,
                Result = await queryble
                    .OrderBy(x => x.Name)
                    .Paginate(pagination)
                    .ToListAsync()
            };
        }

        public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDto paginationDTO)
        {
            var queryable = _dataContext.countries.AsQueryable();

            if (!string.IsNullOrWhiteSpace(paginationDTO.Filter))
            {
                queryable = queryable.Where(x => x.Name.ToLower().Contains(paginationDTO.Filter.ToLower()));
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
