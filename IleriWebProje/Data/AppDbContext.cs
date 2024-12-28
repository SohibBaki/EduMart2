using IleriWebProje.Models;
using Microsoft.EntityFrameworkCore;

namespace IleriWebProje.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mentors_Skills>().HasKey(ms => new
            {
                ms.Id,
                ms.SkillID
            }); 

            modelBuilder.Entity<Mentors_Skills>()
                .HasOne(s => s.Skill)
                .WithMany(sm => sm.Mentors_Skills)
                .HasForeignKey(s => s.SkillID);

            modelBuilder.Entity<Mentors_Skills>()
                .HasOne(s => s.Mentor)
                .WithMany(sm => sm.Mentors_Skills)
                .HasForeignKey(s => s.Id);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Mentors> Mentors { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<Mentors_Skills> Mentors_Skills { get; set; }
        public DbSet<Platforms> Platforms { get; set; }
        public DbSet<Skill_Organizers> Skill_Organizers { get; set; }
    }
}
