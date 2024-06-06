using BaseLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<SystemRole> SystemRoles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RefreshTokenInfo> RefreshTokenInfos { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<UserLesson> UserLessons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure many-to-many relationship between ApplicationUser and Lesson
            modelBuilder.Entity<UserLesson>()
                .HasKey(ul => new { ul.UserId, ul.LessonId });

            modelBuilder.Entity<UserLesson>()
                .HasOne(ul => ul.User)
                .WithMany(u => u.UserLessons)
                .HasForeignKey(ul => ul.UserId);

            modelBuilder.Entity<UserLesson>()
                .HasOne(ul => ul.Lesson)
                .WithMany(l => l.UserLessons)
                .HasForeignKey(ul => ul.LessonId);
        }
    }
}
