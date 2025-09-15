using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using StudentOS.Web;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Root components
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// API taban adresi
var apiBase = "http://localhost:7117/";

// LocalStorage + Auth
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();

// Custom message handler (token’i her isteðe ekleyecek)
builder.Services.AddScoped<TokenAuthorizationMessageHandler>();
builder.Services.AddScoped(sp =>
{
    var handler = sp.GetRequiredService<TokenAuthorizationMessageHandler>();
    return new HttpClient(handler) { BaseAddress = new Uri(apiBase) };
});

// AuthStateProvider
builder.Services.AddScoped<JwtAuthStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp =>
    sp.GetRequiredService<JwtAuthStateProvider>());

// Uygulama servisleri
builder.Services.AddScoped<AuthService>();

await builder.Build().RunAsync();
