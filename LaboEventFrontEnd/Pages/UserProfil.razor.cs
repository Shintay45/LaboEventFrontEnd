using Blazored.Toast.Services;
using LaboEventFrontEnd.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;

namespace LaboEventFrontEnd.Pages
{
    public partial class UserProfil
    {
        [Inject]
        public HttpClient Client { get; set; }
        [Inject]
        public IJSRuntime js { get; set; }
        [Inject]
        public NavigationManager Nav { get; set; }
        [Inject]
        public IToastService ToastService { get; set; }
        public User CurrentUser { get; set; }
        public UpdateUserForm MyForm { get; set; }
        
        
        protected override async Task OnInitializedAsync()
        {
            try
            {
                string token = await js.InvokeAsync<string>("localStorage.getItem", "token");
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                string userId = GetUserIFromJwtToken(token);                
                using (HttpResponseMessage message = await Client.GetAsync("persons/" + userId))
                {
                    if (message.IsSuccessStatusCode)
                    {                       
                        string json = await message.Content.ReadAsStringAsync();
                        CurrentUser = JsonConvert.DeserializeObject<User>(json);
                        MyForm = new UpdateUserForm {
                            Email = CurrentUser.Email,
                            LastName = CurrentUser.LastName,
                            FirstName = CurrentUser.FirstName
                        };
                        StateHasChanged();
                    }
                }
                
            }
            catch (Exception ex)
            {
                ToastService.ShowError(ex.Message);
            }
            
        }

        private string GetUserIFromJwtToken(string token)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtToken = handler.ReadJwtToken(token);

            // Remplacez "user_id" par le nom correct du claim dans votre token
            var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "personId" || c.Type == "sub");
            return userIdClaim?.Value;
        }
        private void OnSubmitForm()
        {

        }
    }
}
