using LaboEventFrontEnd.Security;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Blazored.Toast.Services;

namespace LaboEventFrontEnd.Pages
{

    public partial class Logout
    {
        [Inject]
        public IJSRuntime jsRuntime { get; set; }
        [Inject]
        public AuthenticationStateProvider providerService { get; set; }
        [Inject]
        public NavigationManager nav { get; set; }
        [Inject]
        public IToastService ToastService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await jsRuntime.InvokeVoidAsync("localStorage.clear");
            ((MyStateProvider)providerService).NotifyUserChanged();
            ToastService.ShowSuccess("Vous avez été déconnecté avec succès.");
            nav.NavigateTo("/");
        }
    }
}

