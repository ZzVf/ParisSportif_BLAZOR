using ParisSportif_BLAZOR.Components;
using ParisSportif_BLAZOR.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("API", client =>
{
    client.BaseAddress = new Uri("https://localhost:7034");
});

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<MatchService>();
builder.Services.AddSingleton<BetService>();
builder.Services.AddSingleton<ClientService>();
builder.Services.AddSingleton<ClubService>();
builder.Services.AddSingleton<LigueService>();
builder.Services.AddScoped<ImageCleanupService>();
builder.Services.AddHostedService<ImageScheduleCleanupWorker>();

var app = builder.Build();

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
