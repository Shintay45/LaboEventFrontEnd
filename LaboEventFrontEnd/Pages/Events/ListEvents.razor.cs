
using Blazored.Toast.Services;
using LaboEventFrontEnd.Models;
using Microsoft.AspNetCore.Components;

namespace LaboEventFrontEnd.Pages.Events
{
    public partial class ListEvents
    {
        [Inject]
        public HttpClient Client { get; set; }
        [Inject]
        public IToastService ToastService { get; set; }
        [Inject]
        public NavigationManager Nav { get; set; }

        public List<EventComplete> ListEvent { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                HttpResponseMessage response = await Client.GetAsync("Event");
                if (response.IsSuccessStatusCode)
                {
                    
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
