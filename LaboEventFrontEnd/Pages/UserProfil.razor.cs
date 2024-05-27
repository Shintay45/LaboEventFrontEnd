using LaboEventFrontEnd.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace LaboEventFrontEnd.Pages
{
    public partial class UserProfil
    {
        [Inject]
        public HttpClient Client { get; set; }
        [Inject]
        public IJSRuntime js { get; set; }

        public User CurrentUser { get; set; }

        protected override async Task OnInitializedAsync()
        {
            

            string token = await js.InvokeAsync<string>("localStorage.getItem", "token");

            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            using (HttpResponseMessage message = await Client.GetAsync("/persons"))
            {
                if (message.IsSuccessStatusCode)
                {
                    string json = await message.Content.ReadAsStringAsync();
                    CurrentUser = JsonConvert.DeserializeObject<User>(json);
                    StateHasChanged();
                }
            }
        }
    }
}
