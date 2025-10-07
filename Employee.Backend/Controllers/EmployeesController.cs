using Employee.Backend.Dtos;
using Employee.Backend.UnitsOfWork.Interfaces;
using Employee.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : GenericController<EmployeeModel>
    {
        private readonly IEmployeesUnitOfWork _unitOfWork;

        public EmployeesController(IGenericUnitOfWork<EmployeeModel> unit, IEmployeesUnitOfWork unitOfWork) : base(unit) 
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{chars}")]
        public override async Task<IActionResult> GetAsync(string chars)
        {
            var action = await _unitOfWork.GetAsync(chars);

            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest(action.Messages);
        }

        [HttpGet("paginated")]
        public override async Task<IActionResult> GetAsync(PaginationDto pagination)
        {
            var action = await _unitOfWork.GetAsync(pagination);
            
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }
    }
}
