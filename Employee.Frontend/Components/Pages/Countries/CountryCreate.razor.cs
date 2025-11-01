using Employee.Shared.Entities;
using Employees.Frontend.Repositories;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Employee.Frontend.Components.Pages.Countries
{
    public partial class CountryCreate
    {
        private Country? country = new();

        [Inject] IRepository Repository { get; set; } = null!;
        [Inject] NavigationManager NavigationManager { get; set; } = null!;
        [Inject] ISnackbar Snackbar { get; set; } = null!;

        private async Task CreateAsync()
        {
            var responseHttp = await Repository.PostAsync("/api/Countries", country);

            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                Snackbar.Add(message!, Severity.Error);
                return;
            }

            Return();
            Snackbar.Add("Registro creado", Severity.Success);
        }

        private void Return()
        {
            NavigationManager.NavigateTo("/countries");
        }
    }
}