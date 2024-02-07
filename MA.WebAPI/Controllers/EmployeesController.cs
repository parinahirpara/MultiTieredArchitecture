using MA.Business;
using MA.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace MA.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                var employees = await _employeeService.GetAllEmployees();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeById(id);
                if (employee == null)
                    return NotFound($"Employee with ID {id} not found.");

                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromForm] Employee employee)
        {
            try
            {
                await _employeeService.AddEmployee(employee);
                return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromForm] Employee employee)
        {
            try
            {
                if (id != employee.Id)
                    return BadRequest("Employee ID mismatch.");

                await _employeeService.UpdateEmployee(employee);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                await _employeeService.DeleteEmployee(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost("DataTable")]
        public async Task<IActionResult> GetEmployeeDatatable([FromForm] MyDataTableRequest request)
        {
            try
            {
                //var draw = Request.Form["draw"].FirstOrDefault();
                //var start = Request.Form["start"].FirstOrDefault();
                //var length = Request.Form["length"].FirstOrDefault();
                //var searchValue = Request.Form["search[value]"].FirstOrDefault();
                var draw = request.Draw;
                var start = request.Start;
                var length = request.Length;
                var searchValue = request.SearchValue;
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;
                IEnumerable<dynamic> result = _employeeService.GetAllEmployees().Result;
                if (!string.IsNullOrEmpty(searchValue))
                {
                    result = result.Where(e => e.firstname.Contains(searchValue) || e.lastname.Contains(searchValue) || e.email.Contains(searchValue));
                }
                recordsTotal = result.Count();
                var data = result.Skip(skip).Take(pageSize).ToList();
                var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };
                return Ok(jsonData);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

}
