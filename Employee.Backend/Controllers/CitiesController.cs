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
    public class CitiesController : GenericController<City>
    {
        private readonly ICitiesUnitOfWork _citiesUnitOfWork;

        public CitiesController(IGenericUnitOfWork<City> unitOfWork, ICitiesUnitOfWork citiesUnitOfWork) : base(unitOfWork)
        {
            _citiesUnitOfWork = citiesUnitOfWork;
        }

        [AllowAnonymous]
        [HttpGet("combo/{stateId:int}")] 
        public async Task<IActionResult> GetComboAsync(int stateId) 
        { 
            return Ok(await _citiesUnitOfWork.GetComboAsync(stateId)); 
        }

        [HttpGet("paginated")]
        public override async Task<IActionResult> GetAsync(PaginationDto pagination)
        {
            var response = await _citiesUnitOfWork.GetAsync(pagination);

            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest();
        }

        [HttpGet("totalRecords")]
        public override async Task<IActionResult> GetTotalRecordsAsync(PaginationDto pagination)
        {
            var response = await _citiesUnitOfWork.GetTotalRecordsAsync(pagination);

            if (response.WasSuccess)
            {
                return Ok(response.Result);
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
