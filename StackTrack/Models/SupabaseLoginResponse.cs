namespace StackTrack.Models
{
    public class SupabaseLoginResponse
    {
        public Supabase.Gotrue.User? CurrentUser { get; set; }
        public Supabase.Gotrue.Session? CurrentSession { get; set; }
    }
}
