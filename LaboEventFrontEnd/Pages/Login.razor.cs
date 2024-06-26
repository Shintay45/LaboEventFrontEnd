﻿using LaboEventFrontEnd.Models;
using LaboEventFrontEnd.Security;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text;
using Newtonsoft.Json;
using Blazored.Toast.Services;
using Newtonsoft.Json.Linq;
using Microsoft.IdentityModel.Tokens;

namespace LaboEventFrontEnd.Pages
{
    public partial class Login
    {
        [Inject]
        public IToastService ToastService { get; set; }
        [Inject]
        public IJSRuntime jsRuntime { get; set; }
        [Inject]
        public AuthenticationStateProvider providerService { get; set; }
        [Inject]
        public NavigationManager Nav { get; set; }
        public LoginForm MyForm { get; set; }
        public HttpClient client { get; set; }
        private string ApiUrl = "https://localhost:7080/api/";
        private string Token { get; set; }
        protected override void OnInitialized()
        {            
            MyForm = new LoginForm();
            client = new HttpClient();
            client.BaseAddress = new Uri(ApiUrl);
        }

        public async void SubmitLogin()
        {
            try
            {
                string json = JsonConvert.SerializeObject(MyForm);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                using (HttpResponseMessage message = await client.PostAsync("Auth/login", content))
                {
                    if (message.IsSuccessStatusCode)
                    {
                        string token = message.Content.ReadAsStringAsync().Result;                        
                        await jsRuntime.InvokeVoidAsync("localStorage.setItem", "token", token);
                        ((MyStateProvider)providerService).NotifyUserChanged();
                        ToastService.ShowSuccess("Vous êtes connecté.");
                        Nav.NavigateTo("/");
                    }
                    else
                    {
                        ToastService.ShowError("Une erreur est survenue, veuillez réessayer.");
                    }
                    //if(message.StatusCode == System.Net.HttpStatusCode.OK) { }
                }
            }
            catch (Exception ex)
            {
                ToastService.ShowError(ex.Message);
            }
        }
    }
}
