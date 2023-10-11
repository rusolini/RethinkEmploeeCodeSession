using Emploee.DataAccess.Models;
using Emploee.DataAccess.Repository.Abstractions;
using Emploee.Services.Abstractions;

public class EmployeeService: IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<List<Employee>> GetAllEmployeesAsync()
    {
        return await _employeeRepository.GetAllEmployees();
    }

    public async Task<Employee> GetEmployeeByIdAsync(int id)
    {
        return await _employeeRepository.GetEmployeeByIdAsync(id);
    }

    public async Task AddEmployee(Employee employee)
    {
        await _employeeRepository.AddEmployeeAsync(employee);
    }

    public async Task UpdateEmployee(Employee employee)
    {
        await _employeeRepository.UpdateEmployeeAsync(employee);
    }

    public async Task DeleteEmployeeAsync(int id)
    {
        await _employeeRepository.DeleteEmployee(id);
    }
}