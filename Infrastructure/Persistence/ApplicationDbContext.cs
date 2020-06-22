using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<SiteHandler> SiteHandlers { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public Task<int> SaveChangesAsync()
        {
            //foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            //{
            //    switch (entry.State)
            //    {
            //        case EntityState.Added:
            //            entry.Entity.CreatedBy = _currentUserService.UserId;
            //            entry.Entity.Created = _dateTime.Now;
            //            break;
            //        case EntityState.Modified:
            //            entry.Entity.LastModifiedBy = _currentUserService.UserId;
            //            entry.Entity.LastModified = _dateTime.Now;
            //            break;
            //    }
            //}

            return base.SaveChangesAsync();
        }
    }
}
