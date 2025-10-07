using Employee.Shared.Entities;
using Employees.Frontend.Repositories;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Net;

namespace Employee.Frontend.Components.Pages.Employees
{
    public partial class EmployeesEdit
    {
        private EmployeeModel? Employee;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] private ISnackbar Snackbar { get; set; } = null!;
        [Parameter] public int Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var responseHttp = await Repository.GetAsync<EmployeeModel>($"api/Employees/Get/{Id}");

            if (responseHttp.Error)
            {
                if (responseHttp.HttpResponseMessage.StatusCode == HttpStatusCode.NotFound)
                {
                    NavigationManager.NavigateTo("employees");
                }
                else
                {
                    var messageError = await responseHttp.GetErrorMessageAsync();
                    Snackbar.Add(messageError!, Severity.Error);
                }
            }
            else
            {
                Employee = responseHttp.Response!;
            }
        }
        private async Task EditAsync()
        {
            var responseHttp = await Repository.PutAsync("api/Employees/Update", Employee);
            if (responseHttp.Error) { var messageError = await responseHttp.GetErrorMessageAsync(); Snackbar.Add(messageError!, Severity.Error); return; }
            Return(); Snackbar.Add("Registro actualizado.", Severity.Success);
        }

        private void Return()
        {
            NavigationManager.NavigateTo("categories");
        }
    }
}