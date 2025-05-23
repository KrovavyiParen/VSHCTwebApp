using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Text.Json;
using VSHCTwebApp.Components.Models;

namespace VSHCTwebApp.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<UserCompetencies> UserCompetencies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserCompetencies>(entity =>
            {
                entity.HasKey(e => e.Id);

                // явно указываем св€зь с ApplicationUser
                entity.HasOne<ApplicationUser>()
                      .WithMany()
                      .HasForeignKey(e => e.UserId)
                      .IsRequired();

                entity.Property(e => e.TechStack)
                    .HasConversion(
                        v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                        v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null));

                entity.Property(e => e.ProgrammingLanguages)
                    .HasConversion(
                        v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                        v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null));
            });
        }
    }
}
