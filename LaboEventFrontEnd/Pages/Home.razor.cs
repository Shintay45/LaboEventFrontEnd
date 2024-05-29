
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace LaboEventFrontEnd.Pages
{
    public partial class Home
    {
        [Inject]
        IJSRuntime Js {  get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await Js.InvokeVoidAsync("initializeMainJs");
            }
        }

    }
}
