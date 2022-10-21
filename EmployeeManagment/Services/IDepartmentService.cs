using EmployeeManagment.Models;

namespace EmployeeManagment.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetDepartments();
        Task<Department> GetEmployee(int id);
    }
}
