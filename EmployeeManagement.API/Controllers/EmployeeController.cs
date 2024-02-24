using EmployeeManagement.API.Filters;
using EmployeeManagement.Application.DTOs.Employee;
using EmployeeManagement.Application.Features.Employees.Requests.Comands;
using EmployeeManagement.Application.Features.Employees.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        private Response response = new Response();

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route(nameof(GetAllEmployee))]
        public async Task<ActionResult<List<EmployeeDto>>> GetAllEmployee()
        {
            var employee = await _mediator.Send(new GetEmployeeListRequest());
            response.Result = employee;
            response.StatusCode = (int)HttpStatusCode.OK;
            return Ok(response);
        }

        [HttpGet("GetEmployeeId/{id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeeId(int id)
        {
            var employee = await _mediator.Send(new GetEmployeeDetailRequest { Id = id });
            response.Result = employee;
            response.StatusCode = (int)HttpStatusCode.OK;
            return Ok(response);
        }

        [HttpPost(nameof(CreateEmployee))]
        public async Task<ActionResult> CreateEmployee([FromBody] CreateEmployeeDto employee)
        {
            var command = new CreateEmployeeComand { EmployeeDto = employee };
            response.Result = await _mediator.Send(command);
            response.StatusCode = (int)HttpStatusCode.Created;
            return Ok(response);
        }

        [HttpPut("UpdateEmployee/{id}")]
        public async Task<ActionResult> UpdateEmployee( [FromBody] UpdateEmployeeDto updateEmployeeDto)
        {
            var command = new UpdateEmployeeComand { EmployeeDto = updateEmployeeDto };
            await _mediator.Send(command);
            response.StatusCode = (int)HttpStatusCode.NoContent;
            return Ok(response);
        }
    }
}
