using Emploee.DataAccess.Models;

namespace Emploee.DataAccess.Extensions;

public static class EmployeeExtension
{
    public static void Update(this Employee employeeToUpdate, Employee employee)
    {
        employeeToUpdate.FirstName = employee.FirstName;
        employeeToUpdate.LastName = employee.LastName;
        employeeToUpdate.Email = employee.Email;
    }
}

