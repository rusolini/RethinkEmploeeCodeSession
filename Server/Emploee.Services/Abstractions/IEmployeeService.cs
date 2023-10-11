using Emploee.DataAccess.Models;
using System.Collections.Generic;

namespace Emploee.Services.Abstractions;

public interface IEmployeeService
{
    Task<List<Employee>> GetAllEmployeesAsync();
    Task<Employee> GetEmployeeByIdAsync(int id);
    Task AddEmployee(Employee employee);
    Task UpdateEmployee(Employee employee);
    Task DeleteEmployeeAsync(int id);
}
