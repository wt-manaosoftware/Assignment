using Assignment.API.Core.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.API.Infrastructure.EF.Mappings {

    public static class TransactionMap {

        public static ModelBuilder MapTransaction(this ModelBuilder modelBuilder) {
            var entity = modelBuilder.Entity<Transaction>();
            entity.ToTable("Transactions");
            entity.Property(c => c.Id).ValueGeneratedOnAdd();
            entity.Property(c => c.CurrencyCode);
            entity.Property(c => c.Amount);
            entity.Property(c => c.Status);
            entity.Property(c => c.TransactionDate);
            entity.Property(c => c.CreatedDate);
            entity.Property(c => c.UpdatedDate);
            entity.Property(c => c.CustomerId);
            return modelBuilder;
        }
    }
}
