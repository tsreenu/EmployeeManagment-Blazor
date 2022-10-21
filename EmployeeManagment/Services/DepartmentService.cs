using EmployeeManagment.Models;

namespace EmployeeManagment.Services
{
    public class DepartmentService:IDepartmentService
    {
        private readonly HttpClient httpClient;
        public DepartmentService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await httpClient.GetFromJsonAsync<Department[]>("api/Department");
        }
        public async Task<Department> GetEmployee(int id)
        {
            return await httpClient.GetFromJsonAsync<Department>($"api/Department/{id}");
        }
    }
}
