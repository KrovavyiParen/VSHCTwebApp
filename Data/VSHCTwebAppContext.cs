using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VSHCTwebApp.Components.Models;

namespace VSHCTwebApp.Data
{
    public class VSHCTwebAppContext : DbContext
    {
        public VSHCTwebAppContext (DbContextOptions<VSHCTwebAppContext> options)
            : base(options)
        {
        }
        public DbSet<Like> Likes { get; set; }
        public DbSet<VSHCTwebApp.Components.Models.Note> Note { get; set; } = default!;
        public DbSet<VSHCTwebApp.Components.Models.Project> Project { get; set; } = default!;
        public DbSet<Command> Commands { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Response> Responses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Response>()
                .HasOne(r => r.Vacancy)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict); // Или Cascade в зависимости от логики

            modelBuilder.Entity<Response>()
                .HasOne(r => r.User)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
