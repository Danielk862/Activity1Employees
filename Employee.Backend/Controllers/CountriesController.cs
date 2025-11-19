using Employee.Backend.UnitsOfWork.Implementations;
using Employee.Backend.UnitsOfWork.Interfaces;
using Employee.Shared.Dtos;
using Employee.Shared.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CountriesController : GenericController<Country>
    {
        private readonly ICountriesUnitOfWork _unitOfWork;

        public CountriesController(IGenericUnitOfWork<Country> unit, ICountriesUnitOfWork unitOfWork) : base(unit)
        {
            _unitOfWork = unitOfWork;
        }

        [AllowAnonymous]
        [HttpGet("combo")] 
        public async Task<IActionResult> GetComboAsync()
        { 
            return Ok(await _unitOfWork.GetComboAsync()); 
        }

        [HttpGet]
        public override async Task<IActionResult> GetAsync()
        {
            var response = await _unitOfWork.GetAsync();

            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var response = await _unitOfWork.GetAsync(id);

            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return NotFound(response.Messages);
        }

        [HttpGet("paginated")]
        public override async Task<IActionResult> GetAsync(PaginationDto pagination)
        {
            var response = await _unitOfWork.GetAsync(pagination);

            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest();
        }

        [HttpGet("totalRecords")]
        public override async Task<IActionResult> GetTotalRecordsAsync([FromQuery] PaginationDto pagination)
        {
            var action = await _unitOfWork.GetTotalRecordsAsync(pagination);

            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

        [NonAction]
        [HttpGet("{chars}")]
        public override async Task<IActionResult> GetAsync(string chars)
        {
            await Task.CompletedTask;
            return StatusCode(StatusCodes.Status405MethodNotAllowed);
        }
    }
}
