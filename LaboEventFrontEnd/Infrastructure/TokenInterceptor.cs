using Microsoft.JSInterop;

namespace LaboEventFrontEnd.Infrastructure
{
    public class TokenInterceptor : DelegatingHandler
    {
        private IJSRuntime js;
        public TokenInterceptor(IJSRuntime Js)
        {
            js = Js;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string token = await js.InvokeAsync<string>("localStorage.getItem", "token");
            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Add("Authorization", "Bearer " + token);
            }
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
