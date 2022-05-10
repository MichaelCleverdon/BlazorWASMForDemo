using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace BlazorWASMForDemo.Services
{
    public class CustomAuthorizationMessageHandler : AuthorizationMessageHandler
    {
        public CustomAuthorizationMessageHandler(IAccessTokenProvider provider, NavigationManager navigation) : base(provider, navigation)
        {
            ConfigureHandler(
                authorizedUrls: new[] { "https://7z47kpfpzb.execute-api.us-west-2.amazonaws.com", "https://localhost:7278" }
            );
        }
    }
}
