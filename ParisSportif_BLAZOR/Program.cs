using ParisSportif_BLAZOR.Components;
using ParisSportif_BLAZOR.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("API", client =>
{
    client.BaseAddress = new Uri("https://localhost:7034/");
});

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

builder.Services.AddScoped<MatchService>();
builder.Services.AddScoped<BetService>();
builder.Services.AddScoped<ClientService>();
builder.Services.AddScoped<ClubService>();
builder.Services.AddScoped<LigueService>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
