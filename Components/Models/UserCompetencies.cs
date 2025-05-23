using System.ComponentModel.DataAnnotations.Schema;
using VSHCTwebApp.Data;

namespace VSHCTwebApp.Components.Models
{
    public class UserCompetencies
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public List<string> TechStack { get; set; } = new();
        public List<string> ProgrammingLanguages { get; set; } = new();
    }
}
