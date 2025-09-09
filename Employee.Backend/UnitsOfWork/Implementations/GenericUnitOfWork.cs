using Employee.Backend.Repositories.Interfaces;
using Employee.Backend.UnitsOfWork.Interfaces;
using Employee.Shared.Responses;
using System.Linq.Expressions;

namespace Employee.Backend.UnitsOfWork.Implementations
{
    public class GenericUnitOfWork<T> : IGenericUnitOfWork<T> where T : class
    {
        #region Internals
        private readonly IGenericRepository<T> _genericRepository;
        #endregion

        #region Constructor
        public GenericUnitOfWork(IGenericRepository<T> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        #endregion

        #region methods

        public virtual async Task<ActionResponse<IEnumerable<T>>> GetAsync() => await _genericRepository.GetAsync();

        public virtual async Task<ActionResponse<T>> GetAsync(int id) => await _genericRepository.GetAsync(id);

        public virtual async Task<ActionResponse<IEnumerable<T>>> GetAsync(string fullnames) => await _genericRepository.GetAsync(fullnames);

        public virtual async Task<ActionResponse<T>> AddAsync(T model) => await _genericRepository.AddAsync(model);

        public virtual async Task<ActionResponse<T>> UpdateAsync(T model) => await _genericRepository.UpdateAsync(model);

        public virtual async Task<ActionResponse<T>> DeleteAsync(int id) => await _genericRepository.DeleteAsync(id);
        #endregion
    }
}
