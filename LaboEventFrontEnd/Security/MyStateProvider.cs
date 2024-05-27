using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace LaboEventFrontEnd.Security
{
    public class MyStateProvider : AuthenticationStateProvider
    {
        private readonly IJSRuntime jSRuntime;
        public MyStateProvider(IJSRuntime jS)
        {
            jSRuntime = jS;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string token = await jSRuntime.InvokeAsync<string>("localStorage.getItem", "token");

            if (!string.IsNullOrEmpty(token))
            {
                System.IdentityModel.Tokens.Jwt.JwtSecurityToken jwt = new JwtSecurityToken(token);
                ClaimsIdentity currentUser = new ClaimsIdentity(jwt.Claims, "JwtAuth");

                return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(currentUser)));
            }
            ClaimsIdentity anonymousUser = new ClaimsIdentity();
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonymousUser)));
        }

        public void NotifyUserChanged()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
