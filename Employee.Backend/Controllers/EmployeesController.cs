using Employee.Backend.UnitsOfWork.Interfaces;
using Employee.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : GenericController<EmployeeModel>
    {
        public EmployeesController(IGenericUnitOfWork<EmployeeModel> unit) : base(unit) { }
    }
}
