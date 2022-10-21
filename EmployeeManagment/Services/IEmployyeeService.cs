using EmployeeManagment.Models;
using System.Collections;

namespace EmployeeManagment.Services
{
    public interface IEmployyeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);
    }
}
