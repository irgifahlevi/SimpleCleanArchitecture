using EmployeeManagement.Domain;
using EmployeeManagement.Domain.Common;
using Microsoft.Data.SqlClient;
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
            try
            {
                foreach (var entry in ChangeTracker.Entries<BaseModel>())
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Entity.CreatedAt = DateTime.Now;
                        entry.Entity.CreatedBy = "SYSTEM";
                        entry.Entity.RowStatus = (short)EnumTypes.Active;
                    }
                    else
                    {
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "SYSTEM";
                    }

                    
                }

                return base.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateException ex)
            {
                // Handle the specific exception when data would be truncated
                var errorMessage = "Error saving changes: " + ex.Message;
                if (ex.InnerException is SqlException sqlException && sqlException.Number == 8152)
                {
                    errorMessage += "\nTruncated value: " + sqlException.Errors[0].Message;
                }

                // Log or handle the error appropriately
                Console.WriteLine(errorMessage);
                throw; // Rethrow the exception to maintain expected behavior
            }
        }
        
    }
}
