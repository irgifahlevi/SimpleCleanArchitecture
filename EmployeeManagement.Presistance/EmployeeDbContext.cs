using EmployeeManagement.Domain;
using EmployeeManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Presistance
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeeDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Employee> Employees { get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseModel>())
            {
                entry.Entity.LastModifiedDate = DateTime.Now;
                entry.Entity.LastModifiedBy = "SYSTEM";

                if(entry.State == EntityState.Added) 
                { 
                    entry.Entity.CreatedAt = DateTime.Now;
                    entry.Entity.CreatedBy = "SYSTEM";
                    entry.Entity.RowStatus = (short)EnumTypes.Active;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        
    }
}
