using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VSHCTwebApp.Data;

namespace VSHCTwebApp.Components.Models;

public class Response
{
    public int Id { get; set; }

    [Required]
    public int VacancyId { get; set; }

    [ForeignKey("VacancyId")]
    public Vacancy Vacancy { get; set; }  // Не должно быть nullable

    [Required]
    public string UserId { get; set; }  // Не должно быть nullable

    [ForeignKey("UserId")]
    public ApplicationUser User { get; set; }  // Не должно быть nullable

    [Required]
    public DateTime ResponseDate { get; set; } = DateTime.UtcNow;

    [Required(ErrorMessage = "Сообщение обязательно")]
    [StringLength(500)]
    public string Message { get; set; }
}