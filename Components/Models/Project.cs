namespace VSHCTwebApp.Components.Models
{
    public enum ProjectStatus
    {
        Available,  // Свободен
        InProgress, // В работе
        Completed   // Завершен
    }
    public class Project
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Problem { get; set; } = string.Empty;
        public string Solution { get; set; } = string.Empty;
        public string Result { get; set; } = string.Empty;
        public string DescrNeededResurses { get; set; } = string.Empty;
        public string StackTech { get; set; } = string.Empty;

        public string CreatedBy { get; set; } = string.Empty;

        public string ConfermedBy { get; set; } = string.Empty;
        public ProjectStatus Status { get; set; }
        public string? TakenByTeamId { get; set; } = string.Empty;
        public string? TakenByTeamName { get; set; } = string.Empty;

    }
}
