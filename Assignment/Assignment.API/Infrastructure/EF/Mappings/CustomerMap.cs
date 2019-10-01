using Assignment.API.Core.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace Assignment.API.Infrastructure.EF.Mappings {

    public static class CustomerMap {

        public static ModelBuilder MapCustomer(this ModelBuilder modelBuilder) {

            var entity = modelBuilder.Entity<Customer>();
            entity.ToTable("Customers");
            entity.Property(c => c.Id).ValueGeneratedOnAdd();
            entity.Property(c => c.Name).HasMaxLength(30);
            entity.Property(c => c.ContactEmail).HasMaxLength(25);
            entity.Property(c => c.MobileNo).HasMaxLength(10);
            entity.Property(c => c.CreatedDate);
            entity.Property(c => c.UpdatedDate);
            entity.HasMany(c => c.Transactions).WithOne(c => c.Customer).HasForeignKey(c => c.CustomerId);
            return modelBuilder;
        }
    }
}
