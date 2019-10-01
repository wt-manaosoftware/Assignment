using Assignment.API.Core.Helpers.Enum;
using Assignment.API.Core.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.API.Core.DomainModels {

    public class Transaction : EntityBase {

        public DateTimeOffset TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public TransactionStatus Status { get; set; }
        public Customer Customer { get; set; }
        public long CustomerId { get; set; }

        public TransactionDTO ToDTO() {
            TransactionDTO result = new TransactionDTO() {
                Id = this.Id,
                TransactionDate = this.TransactionDate,
                Amount = this.Amount,
                CurrencyCode = this.CurrencyCode,
                Status = this.Status,
            };

            return result;
        }
    }
}
