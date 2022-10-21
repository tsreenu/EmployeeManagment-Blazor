using EmployeeManagment.Models;
using EmployeeManagment.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace EmployeeManagment.Pages
{
    public class EmployeeDetailsBase:ComponentBase
    {
        [Inject]
        public IEmployyeeService employyeeService { get; set; }
        [Parameter] 
        public string Id { get; set; }

        public Employee employee { get; set; }
        public string CoOrdinates { get; set; }
        public string ButtonText { get; set; } = "Hide Footer";
        public string cssClass { get; set; } = null;

        protected override async Task OnInitializedAsync()
        {
            Id = Id ?? "1";
            employee = await employyeeService.GetEmployee(Convert.ToInt32(Id));
        }
        //public void Mouse_Move(MouseEventArgs args)
        //{
        //    CoOrdinates = $"X = {args.ClientX} Y={args.ClientY}";
        //}
        public void ShowHideFooter()
        {
            if(ButtonText == "Hide Footer")
            {
                cssClass = "HideFooter";
                ButtonText = "Show Footer";
            }
            else
            {
                cssClass = null;
                ButtonText = "Hide Footer";
            }
        }
    }
}
