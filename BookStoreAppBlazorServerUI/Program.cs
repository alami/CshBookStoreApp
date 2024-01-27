using Blazored.LocalStorage;
using BookStoreAppBlazorServerUI.Components;
using BookStoreAppBlazorServerUI.Configurations;
using BookStoreAppBlazorServerUI.Providers;
using BookStoreAppBlazorServerUI.Services;
using BookStoreAppBlazorServerUI.Services.Authentication;
using BookStoreAppBlazorServerUI.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddHttpClient<IClient, Client>(cl => cl.BaseAddress = new Uri("https://localhost:443"));

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();

builder.Services.AddScoped<ApiAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(p=>
   p.GetRequiredService<ApiAuthenticationStateProvider>());

builder.Services.AddAutoMapper(typeof(MapperConfig));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
