using Emploee.DataAccess.Extensions;
using Emploee.DataAccess.Models;
using Emploee.DataAccess.Repository.Abstractions;
using Newtonsoft.Json;

namespace Emploee.DataAccess.Repository.Implementations;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly string _filePath;

    public EmployeeRepository(string filePath)
    {
        _filePath = filePath;
    }

    public async Task<List<Employee>?> GetAllEmployees()
    {
        if (!File.Exists(_filePath))
            return new List<Employee>();

        string json = await File.ReadAllTextAsync(_filePath);
        return JsonConvert.DeserializeObject<List<Employee>>(json);
    }

    public async Task<Employee?> GetEmployeeByIdAsync(int id)
    {
        var employees = await GetAllEmployees();
        return employees?.SingleOrDefault(e => e.Id == id);
    }

    public async Task AddEmployeeAsync(Employee employee)
    {
        var employees = await GetAllEmployees();
        int nextId = employees?.Count > 0 ? employees.Max(e => e.Id) + 1 : 1;
        employee.Id = nextId;
        employees?.Add(employee);

        SaveEmployees(employees);
    }

    public async Task UpdateEmployeeAsync(Employee employee)
    {
        var employees = await GetAllEmployees();
        var employeeToUpdate = employees?.SingleOrDefault(e => e.Id == employee.Id);

        employeeToUpdate.Update(employee);
        SaveEmployees(employees);
    }

    public async Task DeleteEmployee(int id)
    {
        var employees = await GetAllEmployees();
        employees?.RemoveAll(e => e.Id == id);

        SaveEmployees(employees);
    }

    private async Task SaveEmployees(List<Employee> employees)
    {
        string json = JsonConvert.SerializeObject(employees, Formatting.Indented);
        await File.WriteAllTextAsync(_filePath, json);
    }
}
