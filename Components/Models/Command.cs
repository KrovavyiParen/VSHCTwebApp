using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VSHCTwebApp.Components.Models
{
    public class Command
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Название команды обязательно")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Название должно быть от 3 до 100 символов")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "Описание не должно превышать 500 символов")]
        public string Description { get; set; }

        public bool IsActive { get; set; } = false; // true - "В работе", false - "В поиске"
        public bool IsPublic { get; set; } = true; // true - "Открытая", false - "Закрытая"
        public List<string> TechStack { get; set; } = new();
        public List<string> ProgrammingLanguages { get; set; } = new();

        public string TeamLeaderEmail { get; set; } = string.Empty;
        public string TeamLeaderFirstName { get; set; } = string.Empty;
        public string TeamLeaderLastName { get; set; } = string.Empty;

        public ICollection<TeamMember> Members { get; set; } = new List<TeamMember>();
    }
}