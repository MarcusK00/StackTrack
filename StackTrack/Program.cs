using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Supabase;
using StackTrack;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//Adding Supabase to builder.
builder.Services.AddScoped(sp =>
{

    var url = Environment.GetEnvironmentVariable("https://xrpfkqjdtwbslcrnztbd.supabase.co"); // Project URL
    var key = Environment.GetEnvironmentVariable("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InhycGZrcWpkdHdic2xjcm56dGJkIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NTM3MDAxOTgsImV4cCI6MjA2OTI3NjE5OH0.3johaDis8LMEgYwQb_SfaS0VEhSGTeiK41X9Nilqd54"); //Anon Api Key

    var options = new SupabaseOptions
    {
        AutoConnectRealtime = true
    };

    var client = new Client(url!, key!, options);

    // initialize the client before anyone tries to use it
    client.InitializeAsync().GetAwaiter().GetResult();
    return client;
});

await builder.Build().RunAsync();
