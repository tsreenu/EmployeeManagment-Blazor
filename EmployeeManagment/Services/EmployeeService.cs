using EmployeeManagment.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace EmployeeManagment.Services
{
    public class EmployeeService:IEmployyeeService
    {
        private readonly HttpClient httpClient;
        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await httpClient.GetFromJsonAsync<Employee[]>("api/Employees");
        }
        public async Task<Employee> GetEmployee(int id)
        {
            return await httpClient.GetFromJsonAsync<Employee>($"api/Employees/{id}");
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var res = await httpClient.PutAsJsonAsync<Employee>("api/Employees", employee);

            if (res != null)
            {
                
                 employee = await res.Content.ReadFromJsonAsync<Employee>();
            }
            return employee;
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            var res = await httpClient.PostAsJsonAsync<Employee>("api/Employees", employee);

            if (res != null)
            {

                employee = await res.Content.ReadFromJsonAsync<Employee>();
            }
            return employee;
        }
    }
}
