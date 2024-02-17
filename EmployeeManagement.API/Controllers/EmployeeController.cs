using EmployeeManagement.Application.DTOs.Employee;
using EmployeeManagement.Application.Features.Employees.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route(nameof(GetAllEmployee))]
        public async Task<ActionResult<List<EmployeeDto>>> GetAllEmployee()
        {
            var employee = await _mediator.Send(new GetEmployeeListRequest());
            
            return Ok(employee);
        }
    }
}
