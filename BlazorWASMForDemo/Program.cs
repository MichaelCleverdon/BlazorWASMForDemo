using BlazorWASMForDemo;
using RazorComponentLibrary.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RazorComponentLibrary;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<CustomAuthorizationMessageHandler>();
builder.Services.AddHttpClient("Default", httpClient =>
{
    httpClient.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});//.AddHttpMessageHandler<CustomAuthorizationMessageHandler>();
builder.Services.AddAntDesign();
builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Auth0", options.ProviderOptions);
    options.ProviderOptions.AdditionalProviderParameters.Add("audience", builder.Configuration["Auth0:Audience"]);
    options.ProviderOptions.DefaultScopes.Add("email");
});

builder.Services.AddScoped<IFoodApi, FoodApi>();
//builder.Services.AddScoped<AuthorizationMessageHandler>(sp => 
//sp.GetRequiredService<AuthorizationMessageHandler>()
//.ConfigureHandler(authorizedUrls: new [] {builder.Configuration.GetValue<string>("AWSEndpoint")}));

builder.Services.AddHttpClient<FoodApi>("AWS", httpClient => {
    httpClient.BaseAddress = builder.Configuration.GetValue<Uri>("AWSEndpoint");
}).AddHttpMessageHandler<CustomAuthorizationMessageHandler>();
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("AWS"));

await builder.Build().RunAsync();
