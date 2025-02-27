using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTaskTracker.Infrastructure.Data
{
    public class TaskTrackerContext : DbContext
    {
        public TaskTrackerContext(DbContextOptions<TaskTrackerContext> options)
        : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<UserBoard> UserBoards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserBoard>()
                .HasKey(ub => new { ub.IdUser, ub.IdBoard });

            modelBuilder.Entity<UserBoard>()
                .HasOne(ub => ub.User)
                .WithMany(u => u.UserBoards)
                .HasForeignKey(ub => ub.IdUser);

            modelBuilder.Entity<UserBoard>()
                .HasOne(ub => ub.Board)
                .WithMany(b => b.UserBoards)
                .HasForeignKey(ub => ub.IdBoard);

            modelBuilder.Entity<Section>()
                .HasOne(s => s.Board)
                .WithMany(b => b.Sections)
                .HasForeignKey(s => s.IdBoard);

            modelBuilder.Entity<Card>()
                .HasOne(c => c.Section)
                .WithMany(s => s.Cards)
                .HasForeignKey(c => c.IdSection);

            modelBuilder.Entity<Card>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.IdUser)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
