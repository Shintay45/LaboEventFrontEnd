using Blazored.Toast.Services;
using LaboEventFrontEnd.Models;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;


namespace LaboEventFrontEnd.Pages
{
    public partial class RegisterForm
    {
        [Inject]
        public HttpClient Client { get; set; }
        [Inject]
        public NavigationManager Nav { get; set; }
        [Inject]
        public IToastService ToastService { get; set; }

        public RegisterUserForm MyForm { get; set; }
        

        protected override void OnInitialized()
        {
            MyForm = new RegisterUserForm();
        }
        public async Task OnSubmitForm()
        {
            try
            {
                HttpResponseMessage response = await Client.PostAsJsonAsync("Auth/register", MyForm);
                if (response.IsSuccessStatusCode)
                {
                    ToastService.ShowSuccess("Compte créé avec succès.");
                    Nav.NavigateTo("/");
                }
                else
                {
                    ToastService.ShowError("Une erreur est survenue.");
                }
            }
            catch (HttpRequestException ex)
            {
                ToastService.ShowError(ex.Message);
            }
        }
    }
}
