using Emploee.DataAccess.Models;

namespace Emploee.DataAccess.Repository.Abstractions;

public interface IEmployeeRepository
{
    Task<List<Employee>?> GetAllEmployees();
    Task<Employee?> GetEmployeeByIdAsync(int id);
    Task AddEmployeeAsync(Employee employee);
    Task UpdateEmployeeAsync(Employee employee);
    Task DeleteEmployee(int id);
}
