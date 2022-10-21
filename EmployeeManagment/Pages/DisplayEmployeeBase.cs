using EmployeeManagment.Models;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagment.Pages
{
    public class DisplayEmployeeBase:ComponentBase
    {
        [Parameter]
        public Employee Employee { get; set; }
        [Parameter]
        public bool ShowFooter { get; set; }
        [Parameter]
        public EventCallback<bool> onEmployeeSelection { get; set; }

        public async Task CheckBoxChange(ChangeEventArgs args)
        {
         await onEmployeeSelection.InvokeAsync((bool)args.Value);
        }
    }
}
