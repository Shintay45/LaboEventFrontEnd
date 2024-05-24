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

        public RegisterUserForm MyForm { get; set; }
        

        protected override void OnInitialized()
        {
            MyForm = new RegisterUserForm();
        }
        public async Task OnSubmitForm()
        {
            try
            {
                var response = await Client.PostAsJsonAsync("Auth/register", MyForm);
                if (response.IsSuccessStatusCode)
                {
                    Nav.NavigateTo("/");
                }
                else
                {
                    await Console.Out.WriteLineAsync(response.Content.ToString());
                    await Console.Out.WriteLineAsync(response.StatusCode.ToString());
                }
            }
            catch (HttpRequestException ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }

    }
}
