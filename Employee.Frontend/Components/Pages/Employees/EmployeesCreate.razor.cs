using Employee.Shared.Entities;
using Employees.Frontend.Repositories;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Employee.Frontend.Components.Pages.Employees
{
    public partial class EmployeesCreate
    {
        private EmployeeModel Employee = new();
        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] private ISnackbar Snackbar { get; set; } = null!;

        private async Task CreateAsync()
        {
            if (Employee.HireDate.Equals(DateTime.Parse("01/01/0001")))
            {
                Employee.HireDate = DateTime.Now;
            }
            var responseHttp = await Repository.PostAsync("api/Employees", Employee);

            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                Snackbar.Add(message!, Severity.Error);
                return;
            }

            Return(); Snackbar.Add("Registro creado", Severity.Success);
        }

        private void Return()
        {
            NavigationManager.NavigateTo("/employees");
        }
    }
}