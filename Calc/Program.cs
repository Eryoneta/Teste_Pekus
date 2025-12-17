using Calc.Components;

var builder = WebApplication.CreateBuilder(args);

// Blazor
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

// Calc API
// builder.Services.AddHttpClient("API", client => {
//     client.BaseAddress = new Uri("http://pekus.ddns.net/calcapi/api/");
// });
builder.Services.AddScoped<CalculadoraAPI>();

var app = builder.Build();

if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();
app.MapStaticAssets();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
