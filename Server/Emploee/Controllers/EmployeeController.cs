using AutoMapper;
using Emploee.DataAccess.Models;
using Emploee.Services.Abstractions;
using Emploee.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emploee.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly ILogger<EmployeeController> _logger;
    private readonly IEmployeeService _employeeService;
    private readonly IMapper _mapper;

    public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeService, IMapper mapper)
    {
        _logger = logger;
        _employeeService = employeeService;
        _mapper = mapper;
    }

    [HttpGet("getAll")]
    public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
    {
        var employee = await _employeeService.GetAllEmployeesAsync();
        var result = _mapper.Map<List<EmployeeDto>>(employee);

        return result;
    }


    [HttpPut("update")]
    public async Task<IActionResult> UpdateEmploeeAsync(EmployeeDto employee)
    {
        var result = _mapper.Map<Employee>(employee);

        await _employeeService.UpdateEmployee(result);

        return Ok(result);
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddEmploeeAsync(EmployeeDto employee)
    {
        var result = _mapper.Map<Employee>(employee);

        await _employeeService.AddEmployee(result);

        return Ok(result);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteEmploeeAsync(int id)
    {
        await _employeeService.DeleteEmployeeAsync(id);

        return Ok();
    }
}
