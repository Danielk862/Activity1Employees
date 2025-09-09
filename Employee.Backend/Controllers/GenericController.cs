using Employee.Backend.UnitsOfWork.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Backend.Controllers
{
    public class GenericController<T> : Controller where T : class
    {
        private readonly IGenericUnitOfWork<T> _unitOfWork;

        public GenericController(IGenericUnitOfWork<T> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAsync()
        {
            var action = await _unitOfWork.GetAsync();

            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest(action.Messages);
        }

        [HttpGet("{id:int}")] 
        public virtual async Task<IActionResult> GetAsync(int id)
        {
            var action = await _unitOfWork.GetAsync(id);

            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return NotFound();
        }

        [HttpGet("{fullNames}")] 
        public virtual async Task<IActionResult> GetAsync(string fullNames)
        {
            var action = await _unitOfWork.GetAsync(fullNames);

            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest(action.Messages);
        }

        [HttpPost]
        public virtual async Task<IActionResult> AddAsync(T model)
        {
            var action = await _unitOfWork.AddAsync(model);

            if  (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest(action.Messages);
        }

        [HttpPut]
        public virtual async Task<IActionResult> UpdateAsync(T model)
        {
            var action = await _unitOfWork.UpdateAsync(model);

            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest(action.Messages);
        }


        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> DeleteAsync(int id)
        {
            var action = await _unitOfWork.DeleteAsync(id);

            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest(action.Messages);
        }
    }
}
