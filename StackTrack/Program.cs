using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Supabase;
using StackTrack;
using MudBlazor.Services;
using StackTrack.Models;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();
builder.Services.AddSingleton<SupabaseLoginResponse>();
// Correct Supabase client registration
builder.Services.AddScoped(sp =>
{
    var url = "https://xrpfkqjdtwbslcrnztbd.supabase.co"; // Direct string value
    var key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InhycGZrcWpkdHdic2xjcm56dGJkIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NTM3MDAxOTgsImV4cCI6MjA2OTI3NjE5OH0.3johaDis8LMEgYwQb_SfaS0VEhSGTeiK41X9Nilqd54";

    var options = new SupabaseOptions
    {
        AutoConnectRealtime = false, //Flase because of localhosting.
        AutoRefreshToken = true
    };

    var client = new Client(url, key, options);

    // Initialize the client
    try
    {
        client.InitializeAsync().GetAwaiter().GetResult();
    }
    catch (Exception ex)
    {
        Console.Error.WriteLine($"Failed to initialize Supabase client: {ex.Message}");
    }

    return client;
});

await builder.Build().RunAsync();