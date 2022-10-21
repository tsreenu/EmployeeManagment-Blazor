using EmployeeManagment.Models;
using EmployeeManagment.Services;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagment.Pages
{
    public class EmployeeListBase:ComponentBase
    {
        [Inject]
        public IEmployyeeService employyeeService { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public bool ShowFooter { get; set; } = true;
        public int SelectedEmployeeCount { get; set; } = 0;
        protected override async Task OnInitializedAsync()
        {
           Employees = (await employyeeService.GetEmployees()).ToList();
           
        }
        public void EmployeeSelectionChanged(bool isSelected)
        {
            if (isSelected)
            {
                SelectedEmployeeCount++;
            }
            else
            {
                SelectedEmployeeCount--;
            }
        }


    }
}
