namespace VSHCTwebApp.Components.Models
{
    public enum ProjectStatus
    {
        New,        // Новый
        Approved,   // Подтвержден
        NeedRevision,// Нужно редактирование
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
        public string CreatedByEmail { get; set; } = string.Empty;
        public ProjectStatus Status { get; set; }
        public string? TakenByTeamId { get; set; } = string.Empty;
        public string? TakenByTeamName { get; set; } = string.Empty;

        public DateTime? AvailableUntil { get; set; } // Срок доступности
        public bool IsManuallyMadeAvailable { get; set; } // Флаг ручного открытия

        public int ApprovalCount { get; set; } // Счетчик подтверждений
        public string ApprovedByExperts { get; set; } = ""; // Список экспертов
    }
}
