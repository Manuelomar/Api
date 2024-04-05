using Microsoft.EntityFrameworkCore;
using PermitPequests.Domain.Entities;

namespace PermitPequests.Infraestructure.Persistence.Context
{
    public interface IApplicationDbContext : IDbContext { }
    public class ApplicationDbContext : BaseDbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionType> PermissionTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Permission>()
                .HasOne(p => p.PermissionType) 
                .WithMany() 
                .HasForeignKey(p => p.PermissionTypeId); 

        
        }

    }
}
