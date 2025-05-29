namespace VSHCTwebApp.Models
{
    public class UserProfile
    {
        public string Id { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string? Competencies { get; set; }
        public string? Portfolio { get; set; }
    }
}
