using Assignment.API.Core.DomainModels;
using Assignment.API.Infrastructure.EF.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.API.Infrastructure.EF {

    public class DBContext : DbContext {

        public DBContext(DbContextOptions opetion) : base(opetion) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.MapCustomer();
            modelBuilder.MapTransaction();
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges() {
            AddEntityData();
            return base.SaveChanges();
        }

        private void AddEntityData() {
            if (this.ChangeTracker != null && this.ChangeTracker.Entries() != null) {
                var entities = this.ChangeTracker.Entries().Where(x => x.Entity is EntityBase && (x.State == EntityState.Added || x.State == EntityState.Modified)).ToList();

                foreach (var entity in entities) {
                    if (entity.State == EntityState.Added) {
                        ((EntityBase)entity.Entity).CreatedDate = DateTime.UtcNow;
                        ((EntityBase)entity.Entity).UpdatedDate = DateTime.UtcNow;
                    } else
                        ((EntityBase)entity.Entity).UpdatedDate = DateTime.UtcNow;
                }
            }
        }

    }
}
