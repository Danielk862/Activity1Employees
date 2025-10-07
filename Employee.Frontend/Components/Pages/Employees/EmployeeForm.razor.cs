using Employee.Shared.Entities;
using Microsoft.AspNetCore.Components;

namespace Employee.Frontend.Components.Pages.Employees
{
    public partial class EmployeeForm
    {
        [EditorRequired, Parameter] public EmployeeModel Employees { get; set; } = null!;
        [EditorRequired, Parameter] public EventCallback OnValidSubmit { get; set; }
        [EditorRequired, Parameter] public EventCallback ReturnAction { get; set; }
        [Parameter] public bool IsEdit { get; set; }
    }
}