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
    public class StatesController : GenericController<State>
    {
        private readonly IStatesUnitOfWork _statesUnitOfWork;

        public StatesController(IGenericUnitOfWork<State> unitOfWork, IStatesUnitOfWork statesUnitOfWork) : base(unitOfWork)
        {
            _statesUnitOfWork = statesUnitOfWork;
        }

        [AllowAnonymous]
        [HttpGet("combo/{countryId:int}")] 
        public async Task<IActionResult> GetComboAsync(int countryId) 
        { 
            return Ok(await _statesUnitOfWork.GetComboAsync(countryId));
        }

        [HttpGet]
        public override async Task<IActionResult> GetAsync()
        {
            var response = await _statesUnitOfWork.GetAsync();

            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }

            return BadRequest(response.Messages);
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var response = await _statesUnitOfWork.GetAsync(id);

            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }

            return NotFound(response.Messages);
        }

        [HttpGet("paginated")]
        public override async Task<IActionResult> GetAsync([FromQuery] PaginationDto pagination)
        {
            var response = await _statesUnitOfWork.GetAsync(pagination);

            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest();
        }

        [HttpGet("totalRecords")]
        public override async Task<IActionResult> GetTotalRecordsAsync([FromQuery] PaginationDto pagination)
        {
            var response = await _statesUnitOfWork.GetTotalRecordsAsync(pagination);

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
