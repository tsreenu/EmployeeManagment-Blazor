using EmployeeManagment.Models;
using EmployeeManagment.Services;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagment.Pages
{
    public class EditEmployeeBase:ComponentBase
    {
        [Inject]
        public IEmployyeeService employyeeService { get; set; }
        [Inject]
        public IDepartmentService departmentService { get; set; }
        [Parameter]
        public string Id { get; set; }
        public Employee Employee { get; set; } = new Employee();
        public List<Department> Departments { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Employee = await employyeeService.GetEmployee(Convert.ToInt32(Id));
            Departments = (await departmentService.GetDepartments()).ToList();   
        }

    }
}
