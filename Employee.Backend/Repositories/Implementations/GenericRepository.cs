using Employee.Backend.Data;
using Employee.Backend.Dtos;
using Employee.Backend.Helpers;
using Employee.Backend.Repositories.Interfaces;
using Employee.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace Employee.Backend.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        #region Internals
        private readonly DataContext _dataContext;
        private readonly DbSet<T> _entity;
        #endregion

        #region Constructor
        public GenericRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
            _entity = dataContext.Set<T>();
        }
        #endregion

        #region Methods

        public virtual async Task<ActionResponse<IEnumerable<T>>> GetAsync() => new ActionResponse<IEnumerable<T>>
        {
            WasSuccess = true,
            Result = await _entity.ToListAsync(),
        };

        public virtual async Task<ActionResponse<T>> GetAsync(int id)
        {
            var row = await _entity.FindAsync(id);

            if (row != null)
            {
                return new ActionResponse<T>
                {
                    WasSuccess = true,
                    Result = row
                };
            }

            return new ActionResponse<T>
            {
                Messages = "Registro no encontrado",
            };
        }

        public virtual async Task<ActionResponse<IEnumerable<T>>> GetAsync(string chars)
        {
            var rows = await _entity.ToListAsync();

            var result = rows.Where(x => x.Equals(chars)).ToList();

            if (result != null)
            {
                return new ActionResponse<IEnumerable<T>>
                {
                    WasSuccess = true,
                    Result = result
                };
            }

            return new ActionResponse<IEnumerable<T>>
            {
                Messages = "Registro no encontrado",
            };
        }

        public virtual async Task<ActionResponse<T>> AddAsync(T model)
        {
            _dataContext.Add(model);

            try
            {
                await _dataContext.SaveChangesAsync();
                return new ActionResponse<T>
                {
                    WasSuccess = true,
                    Result = model
                };
            }
            catch (DbUpdateException)
            {
                return DbUpdateExceptionActionResponse();
            }
            catch (Exception ex)
            {
                return ExceptionActionResponse(ex);
            }
        }

        public virtual async Task<ActionResponse<T>> UpdateAsync(T model)
        {
            _dataContext.Update(model);

            try
            {
                await _dataContext.SaveChangesAsync();
                return new ActionResponse<T>
                {
                    WasSuccess = true,
                    Result = model
                };
            }
            catch (DbUpdateException)
            {
                return DbUpdateExceptionActionResponse();
            }
            catch (Exception ex)
            {
                return ExceptionActionResponse(ex);
            }
        }

        public virtual async Task<ActionResponse<T>> DeleteAsync(int id)
        {
            var row = await _entity.FindAsync(id);

            if (row == null)
            {
                return new ActionResponse<T>
                {
                    Messages = "Registro no existe."
                };
            }

            _entity.Remove(row);

            try
            {
                await _dataContext.SaveChangesAsync();

                return new ActionResponse<T>
                {
                    WasSuccess = true
                };
            }
            catch (Exception)
            {
                return new ActionResponse<T>
                {
                    Messages = "No se puede eliminar el registro."
                };
            }
        }

        public virtual async Task<ActionResponse<IEnumerable<T>>> GetAsync(PaginationDto pagination)
        {
            var queryable = _entity.AsQueryable();

            return new ActionResponse<IEnumerable<T>>
            {
                WasSuccess = true,
                Result = await queryable.Paginate(pagination).ToListAsync()
            };
        }

        public virtual async Task<ActionResponse<int>> GetTotalRecords(PaginationDto pagination)
        {
            var queryable = _entity.AsQueryable();
            double count = await queryable.CountAsync();

            return new ActionResponse<int>
            {
                WasSuccess = true,
                Result = (int)count
            };
        }
        #endregion

        #region Methods Private


        private ActionResponse<T> DbUpdateExceptionActionResponse() => new ActionResponse<T> { Messages = "Ya existe el registro." };

        private ActionResponse<T> ExceptionActionResponse(Exception ex) => new ActionResponse<T> { Messages = ex.Message };
        #endregion
    }
}
