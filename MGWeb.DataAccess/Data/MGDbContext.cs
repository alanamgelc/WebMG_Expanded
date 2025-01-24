using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MG.Models;


namespace WebMG.Data
{
    public class MGDbContext : IdentityDbContext
    {
        public MGDbContext(DbContextOptions<MGDbContext> options) : base(options) { }
        
        public DbSet<Center> Centers { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<AttendCard> AttendCards { get; set; }
        public DbSet<Emp> Emps { get; set; }
        public DbSet<Fam> Fams { get; set; }
        public DbSet<Par> Pars { get; set; }
        public DbSet<Stu> Stus { get; set; }
        public DbSet<TimeCard> TimeCards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Center>().HasData(
                new Center { Id=1,Name="Chapel", DisplayOrder=1},
                 new Center { Id = 2, Name = "Parmelee", DisplayOrder = 2 }
                );

            base.OnModelCreating(modelBuilder);
            // AttendCard -> Stu relationship
            modelBuilder.Entity<AttendCard>()
                .HasOne(ac => ac.Stu)
                .WithMany(s => s.AttendCards)
                .HasForeignKey(ac => ac.StuId)
                .OnDelete(DeleteBehavior.Restrict);  // Prevent cascading delete

            // AttendCard -> Par relationship
            modelBuilder.Entity<AttendCard>()
                .HasOne(ac => ac.Par)
                .WithMany()  // No navigation property in Par
                .HasForeignKey(ac => ac.ParId)
                .OnDelete(DeleteBehavior.SetNull);  // Set foreign key to null on delete

            ////try this first
            //// AttendCard -> Par relationship
            //modelBuilder.Entity<AttendCard>()
            //    .HasOne(ac => ac.Emp)
            //    .WithMany()  // No navigation property in Par
            //    .HasForeignKey(ac => ac.EmpId)
            //    .OnDelete(DeleteBehavior.SetNull);  // Set foreign key to null on delete

            //try this next
            modelBuilder.Entity<AttendCard>()
          .HasOne(ac => ac.Emp)
          .WithMany(s => s.AttendCards)
          .HasForeignKey(ac => ac.EmpId)
          .OnDelete(DeleteBehavior.Restrict);  // Prevent cascading delete

            //// AttendCard -> Emp relationship
            //modelBuilder.Entity<AttendCard>()
            //    .HasOne(ac => ac.Emp)
            //    .WithMany()  // No navigation property in Emp
            //    .HasForeignKey(ac => ac.EmpId)
            //    .OnDelete(DeleteBehavior.Restrict);  // Prevent cascading delete


            // Configure the one-to-many relationship between Par and AttendCard
            modelBuilder.Entity<Par>()
                .HasMany(p => p.AttendCards)
                .WithOne(a => a.Par)  // Assuming AttendCard has a Par navigation property
                .HasForeignKey(a => a.ParId)  // Ensure ParId exists in AttendCard class
                .OnDelete(DeleteBehavior.SetNull);  // Adjust based on your needs


            // Employee -> TimeCard relationship
            modelBuilder.Entity<TimeCard>() // Assuming you have a TimeCard class set up
                .HasOne(tc => tc.Emp) // Assuming TimeCard has a property Emp
                .WithMany(e => e.TimeCards)
                .HasForeignKey(tc => tc.EmpId) // Ensure you have EmpId in TimeCard
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete 



            // Configure the one-to-many relationship between Fam and Stu
            modelBuilder.Entity<Fam>()
                .HasMany(f => f.Stus);  
               

            // Configure the foreign key relationship between Fam and Par
            modelBuilder.Entity<Fam>()
                .HasOne(f => f.Par)
                .WithMany()  // Assuming Par does not have a collection of Fam
                .HasForeignKey(f => f.ParId)
                .OnDelete(DeleteBehavior.Restrict);  // Adjust based on your needs

 

            // Define the relationship if needed
            modelBuilder.Entity<Stu>()
                .HasOne(s => s.Fam)
                .WithMany(f => f.Stus)
                .HasForeignKey(s => s.FamId);
        }
    }

}