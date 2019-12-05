using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TimeSheet.Models;

namespace TimeSheet.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Department> Department { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Timesheet> Timesheet { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProjectDepartment>().HasKey(pd => new { pd.projectId, pd.departmentId});
            modelBuilder.Entity<Project>().HasKey(p => new { p.projectId });
            modelBuilder.Entity<Department>().HasKey(d => new { d.departmentId});
            modelBuilder.Entity<Timesheet>().HasKey(d => new { d.timesheetId });


            modelBuilder.Entity<ProjectDepartment>()
                .HasOne(pr => pr.project)
                .WithMany(p => p.projectDepartment)
                .HasForeignKey(pr => pr.projectId);
            modelBuilder.Entity<ProjectDepartment>()
                .HasOne(dep => dep.department)
                .WithMany(d => d.projectDepartment)
                .HasForeignKey(did => did.departmentId);

            modelBuilder.Entity<Department>()
                .HasOne(d => d.project)
                .WithMany(e => e.ownerDepartments);

            modelBuilder.Entity<Timesheet>()
                .HasOne(a => a.relatedProject)
                .WithMany(b => b.relatedTimesheets);
        }
    }
}
