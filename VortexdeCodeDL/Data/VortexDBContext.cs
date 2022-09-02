using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VortexdeCodeDL.Entitys;
using VortexdeCodeDL.UnitOfWork;

namespace VortexdeCodeDL.Data
{
    public class VortexDBContext: IdentityDbContext<IdentityUser>
    {
        
        public VortexDBContext(DbContextOptions<VortexDBContext> options)
            : base(options)
        {
                    
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .Property(e => e.FirstName)
                .HasMaxLength(250);

            modelBuilder.Entity<ApplicationUser>()
                .Property(e => e.LastName)
                .HasMaxLength(250);
            modelBuilder.Entity<ApplicationUser>()
                .Property(e => e.RefreshToken)
                .HasMaxLength(250);
            modelBuilder.Entity<ApplicationUser>()
               .Property(e => e.RefreshTokenExpiryTime);
               
            

        }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }

        
    }
}
