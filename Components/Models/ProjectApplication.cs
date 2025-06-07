using System.ComponentModel.DataAnnotations;

namespace VSHCTwebApp.Components.Models
{
    public enum ProjectApplicationStatus
    {
        Pending,
        Approved,
        Rejected
    }

    public class ProjectApplication
    {
        [Key]
        public int Id { get; set; }
        public int ProjectId { get; set; } = 0;
        public string TeamId { get; set; } = string.Empty;
        public string TeamName { get; set; } = string.Empty;
        public ProjectApplicationStatus Status { get; set; } = ProjectApplicationStatus.Pending;
        public DateTime ApplicationDate { get; set; } = DateTime.Now;
        public string Message { get; set; } = string.Empty;
    }
}
