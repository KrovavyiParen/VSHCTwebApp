using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VSHCTwebApp.Data;

namespace VSHCTwebApp.Components.Models;

public class Response
{
    [Key]
    public int Id { get; set; }

    public int VacancyId { get; set; }

    [ForeignKey("VacancyId")]
    public Vacancy? Vacancy { get; set; }  // Делаем nullable

    public string? UserId { get; set; }  // Делаем nullable

    [ForeignKey("UserId")]
    public ApplicationUser? User { get; set; }  // Делаем nullable

    public DateTime ResponseDate { get; set; } = DateTime.UtcNow;

    [Required(ErrorMessage = "Сообщение обязательно")]
    public string? Message { get; set; }  // Делаем nullable
}