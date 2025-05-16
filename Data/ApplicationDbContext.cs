using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using VSHCTwebApp.Components.Models;

namespace VSHCTwebApp.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Competence> Competence { get; set; }
        public DbSet<UserCompetence> UserCompetence { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Competence>().ToTable("Competence");

            builder.Entity<UserCompetence>(entity =>
            {
                // Составной первичный ключ
                entity.HasKey(uc => new { uc.UserId, uc.CompetenceId });

                // Настройка связей
                entity.HasOne(uc => uc.User)
                    .WithMany(u => u.UserCompetences)
                    .HasForeignKey(uc => uc.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(uc => uc.Competence)
                    .WithMany(c => c.UserCompetences)
                    .HasForeignKey(uc => uc.CompetenceId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Конфигурация для Competence
            builder.Entity<Competence>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Name).IsRequired();
                entity.Property(c => c.Category).HasConversion<string>();

                entity.HasData(
                    new Competence { Id = 1, Name = "C#", Category = CompetenceCategory.ProgrammingLanguage },
                    new Competence { Id = 2, Name = "JavaScript", Category = CompetenceCategory.ProgrammingLanguage },
                    new Competence { Id = 3, Name = "ASP.NET Core", Category = CompetenceCategory.Framework },
                    new Competence { Id = 4, Name = "React", Category = CompetenceCategory.Framework },
                    new Competence { Id = 5, Name = "SQL", Category = CompetenceCategory.Database },
                    new Competence { Id = 6, Name = "PostgreSQL", Category = CompetenceCategory.Database },
                    new Competence { Id = 7, Name = "Docker", Category = CompetenceCategory.DevOps },
                    new Competence { Id = 8, Name = "Kubernetes", Category = CompetenceCategory.DevOps },
                    new Competence { Id = 9, Name = "PHP", Category = CompetenceCategory.ProgrammingLanguage },
                    new Competence { Id = 10, Name = "Blueprint", Category = CompetenceCategory.ProgrammingLanguage },
                    new Competence { Id = 11, Name = "GOLANG", Category = CompetenceCategory.ProgrammingLanguage },
                    new Competence { Id = 12, Name = "Rust", Category = CompetenceCategory.ProgrammingLanguage },
                    new Competence { Id = 13, Name = "Flatter", Category = CompetenceCategory.ProgrammingLanguage },
                    new Competence { Id = 14, Name = "Dart", Category = CompetenceCategory.ProgrammingLanguage },
                    new Competence { Id = 15, Name = "R Lang", Category = CompetenceCategory.ProgrammingLanguage },
                    new Competence { Id = 16, Name = "Java", Category = CompetenceCategory.ProgrammingLanguage },
                    new Competence { Id = 17, Name = "HTML", Category = CompetenceCategory.ProgrammingLanguage },
                    new Competence { Id = 18, Name = "CSS", Category = CompetenceCategory.ProgrammingLanguage },
                    new Competence { Id = 19, Name = "C++", Category = CompetenceCategory.ProgrammingLanguage },
                    new Competence { Id = 20, Name = "Next", Category = CompetenceCategory.ProgrammingLanguage },
                    new Competence { Id = 21, Name = "Julia", Category = CompetenceCategory.ProgrammingLanguage },
                    new Competence { Id = 22, Name = "TypeScript", Category = CompetenceCategory.ProgrammingLanguage },
                    new Competence { Id = 23, Name = "Python", Category = CompetenceCategory.ProgrammingLanguage },
                    new Competence { Id = 24, Name = "SWIFT", Category = CompetenceCategory.ProgrammingLanguage },
                    new Competence { Id = 25, Name = "KOTLIN", Category = CompetenceCategory.ProgrammingLanguage },
                    new Competence { Id = 26, Name = "XAML", Category = CompetenceCategory.ProgrammingLanguage },
                    new Competence { Id = 27, Name = "Scss", Category = CompetenceCategory.ProgrammingLanguage },
                    new Competence { Id = 28, Name = "Ruby", Category = CompetenceCategory.ProgrammingLanguage },
                    new Competence { Id = 29, Name = "Unreal Engine GameMode", Category = CompetenceCategory.Framework },
                    new Competence { Id = 30, Name = "SpringBoot", Category = CompetenceCategory.Framework },
                    new Competence { Id = 31, Name = "Keras", Category = CompetenceCategory.Framework },
                    new Competence { Id = 32, Name = "Scikit Learn", Category = CompetenceCategory.Framework },
                    new Competence { Id = 33, Name = "Pandas", Category = CompetenceCategory.Framework },
                    new Competence { Id = 34, Name = "TensorFlow", Category = CompetenceCategory.Framework },
                    new Competence { Id = 35, Name = "PyTorch", Category = CompetenceCategory.Framework },
                    new Competence { Id = 36, Name = "Vue", Category = CompetenceCategory.Framework },
                    new Competence { Id = 37, Name = "PhalconPHP", Category = CompetenceCategory.Framework },
                    new Competence { Id = 38, Name = "FastAPI", Category = CompetenceCategory.Framework },
                    new Competence { Id = 39, Name = "Flutter", Category = CompetenceCategory.Framework },
                    new Competence { Id = 40, Name = "1C", Category = CompetenceCategory.Framework },
                    new Competence { Id = 41, Name = "ReactJS", Category = CompetenceCategory.Framework },
                    new Competence { Id = 42, Name = "NestJS", Category = CompetenceCategory.Framework },
                    new Competence { Id = 43, Name = "Node.js", Category = CompetenceCategory.Framework },
                    new Competence { Id = 44, Name = "Next.js", Category = CompetenceCategory.Framework },
                    new Competence { Id = 45, Name = ".NET MAUI", Category = CompetenceCategory.Framework },
                    new Competence { Id = 46, Name = ".NET 6.0", Category = CompetenceCategory.Framework },
                    new Competence { Id = 47, Name = "Django", Category = CompetenceCategory.Framework },
                    new Competence { Id = 48, Name = "Unreal Engine", Category = CompetenceCategory.Framework },
                    new Competence { Id = 49, Name = "NumPy", Category = CompetenceCategory.Framework },
                    new Competence { Id = 50, Name = "ReactNative", Category = CompetenceCategory.Framework },
                    new Competence { Id = 51, Name = "Flask", Category = CompetenceCategory.Framework },
                    new Competence { Id = 52, Name = "Tailwind", Category = CompetenceCategory.Framework },
                    new Competence { Id = 53, Name = "Bootstrap", Category = CompetenceCategory.Framework },
                    new Competence { Id = 54, Name = "Ruby on Rails", Category = CompetenceCategory.Framework },
                    new Competence { Id = 55, Name = "Jest", Category = CompetenceCategory.Framework },
                    new Competence { Id = 56, Name = "Mocha", Category = CompetenceCategory.Framework },
                    new Competence { Id = 57, Name = "Cypress", Category = CompetenceCategory.Framework },
                    new Competence { Id = 58, Name = "Selenium", Category = CompetenceCategory.Framework },
                    new Competence { Id = 59, Name = "SQLite", Category = CompetenceCategory.Database },
                    new Competence { Id = 60, Name = "FireBase", Category = CompetenceCategory.Database },
                    new Competence { Id = 61, Name = "Redis", Category = CompetenceCategory.Database },
                    new Competence { Id = 62, Name = "MySQL", Category = CompetenceCategory.Database },
                    new Competence { Id = 63, Name = "TypeORM", Category = CompetenceCategory.Database },
                    new Competence { Id = 64, Name = "SQL1", Category = CompetenceCategory.Database },
                    new Competence { Id = 65, Name = "MongoDB", Category = CompetenceCategory.Database },
                    new Competence { Id = 66, Name = "Elasticsearch", Category = CompetenceCategory.DevOps },
                    new Competence { Id = 67, Name = "Prometheus", Category = CompetenceCategory.DevOps },
                    new Competence { Id = 68, Name = "Grafana", Category = CompetenceCategory.DevOps },
                    new Competence { Id = 69, Name = "Git", Category = CompetenceCategory.DevOps }
                );
            });
        }
    }
}
