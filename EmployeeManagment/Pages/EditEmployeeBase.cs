using AutoMapper;
using EmployeeManagment.Models;
using EmployeeManagment.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace EmployeeManagment.Pages
{
    public class EditEmployeeBase:ComponentBase
    {
        [Inject]
        public IEmployyeeService employyeeService { get; set; }
        [Inject]
        public IDepartmentService departmentService { get; set; }
        [Inject]
        IMapper Mapper { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }
        [Parameter]
        public string Id { get; set; }
        public Employee Employee { get; set; } = new Employee();
        public EditEmployeeModel EditEmployeeModel { get; set; } = new EditEmployeeModel();
        public List<Department> Departments { get; set; }

        protected override async Task OnInitializedAsync()
        {
            int.TryParse(Id, out int employeeId);
            if(employeeId != 0)
            {
                Employee = await employyeeService.GetEmployee(Convert.ToInt32(Id));
            }
            else
            {
                Employee = new Employee
                {
                    DepartmentId = 1,
                    DateOfBirth = DateTime.Now,
                    PhotoPath = "images/nophoto.jpg",
                    Department = new Department { DepartmentId = 0, DepartmentName = "Test" }
                };
            }

            
            Departments = (await departmentService.GetDepartments()).ToList();
            Mapper.Map(Employee, EditEmployeeModel);           
        }
        public async Task HandleValidSubmit()
        {
            Mapper.Map(EditEmployeeModel, Employee);
            Employee res = null;
            if(Employee.EmployeeId != 0)
            {
                 res = await employyeeService.UpdateEmployee(Employee);
            }
            else
            {
                 res = await employyeeService.CreateEmployee(Employee);
            }
           
            if(res != null)
            {
                navigationManager.NavigateTo("/");
            }
        }

    }
}
