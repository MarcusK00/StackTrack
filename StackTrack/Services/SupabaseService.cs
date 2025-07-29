using Supabase;
using Microsoft.JSInterop;

namespace StackTrack.Services
{
    public class SupabaseService
    {
        private readonly Client _supabaseClient;
        private readonly IJSRuntime _jsRuntime;

        public SupabaseService(IJSRuntime jsRuntime)
        {
            var url = "https://xrpfkqjdtwbslcrnztbd.supabase.co"; // Replace with your Supabase URL
            var key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InhycGZrcWpkdHdic2xjcm56dGJkIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NTM3MDAxOTgsImV4cCI6MjA2OTI3NjE5OH0.3johaDis8LMEgYwQb_SfaS0VEhSGTeiK41X9Nilqd54"; // Replace with your Supabase anon key

            var options = new SupabaseOptions
            {
                AutoRefreshToken = true,
            };

            _supabaseClient = new Client(url, key, options);
            _jsRuntime = jsRuntime;
        }

        public Client GetClient() => _supabaseClient;
    }
}