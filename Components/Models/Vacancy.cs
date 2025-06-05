using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VSHCTwebApp.Components.Models;

public class Vacancy
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Название вакансии обязательно")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Название должно быть от 3 до 100 символов")]
    public string Name { get; set; }

    [StringLength(500, ErrorMessage = "Описание не должно превышать 500 символов")]
    public string Description { get; set; }


    public string TeamLeaderEmail { get; set; } = string.Empty;
    public string TeamLeaderFirstName { get; set; } = string.Empty;
    public string TeamLeaderLastName { get; set; } = string.Empty;

    public int? CommandId { get; set; }

    [ForeignKey("CommandId")]
    public Command? Command { get; set; }
}